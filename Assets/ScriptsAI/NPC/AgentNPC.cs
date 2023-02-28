using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentNPC : Agent
{
    // Este será el steering final que se aplique al personaje.
    [SerializeField] protected Steering steer;
    public Arbitrator arbitrator;
    // Todos los steering que tiene que calcular el agente.
    private List<SteeringBehaviour> listSteerings;

    protected void Awake()
    {
        this.steer = new Steering();
        listSteerings = new List<SteeringBehaviour>();

        // Construye una lista con todos las componenen del tipo SteeringBehaviour.
        // La llamaremos listSteerings
        // Puedes usar GetComponents<>()
        foreach (SteeringBehaviour st in GetComponents(typeof(SteeringBehaviour)))
        {
            listSteerings.Add(st);
        }
    }

    // Use this for initialization
    void Start()
    {
        this.Velocity = Vector3.zero;
    }

    // Update is called once per frame
    public virtual void Update()
    {
        // En cada frame se actualiza el movimiento
        ApplySteering(Time.deltaTime);

        // En cada frame podría ejecutar otras componentes IA
    }

    private void ApplySteering(float deltaTime)
    {
        // Actualizar las propiedades para Time.deltaTime según NewtonEuler
        // La actualización de las propiedades se puede hacer en LateUpdate()
        // Velocity
        // Rotation
        // Position
        // Orientation
        Acceleration = this.steer.linear; // cambia este valor si steer son aceleraciones
        AngularAcc = this.steer.angular;
        if (this.GetComponent<Brain>().status == Status.Stopped)
            return;
        Position = Position + Velocity * deltaTime; // Si steer fueran aceleraciones
        Orientation = Orientation + Rotation * deltaTime; // deberás cambiar las expresiones.
        Velocity = Velocity + Acceleration * deltaTime; // steer se interpreta como velocidades.
        Rotation = Rotation + AngularAcc * deltaTime; // Aplicamos Newton-Euler para a=
        // Pasar los valores Position y Orientation a Unity.
        // Posición no es necesario. Ver observación final.
        transform.rotation = new Quaternion(); //Quaternion.identity;
        transform.Rotate(Vector3.up, Orientation);
        // Ni se te ocurra usar cuaterniones para la rotación.
        // Aquí tienes la solución sin cuaterniones.
    }

    public virtual void LateUpdate()
    {
        Steering kinematicFinal = new Steering();

        // Reseteamos el steering final.
        this.steer = new Steering();
        kinematicFinal = arbitrator.getSteering(listSteerings, this);

        // Recorremos cada steering
        // foreach (SteeringBehaviour behavior in listSteerings)
        //     if (behavior.enabled)
        //         kinematicFinal = behavior.GetSteering(this);
        //// La cinemática de este SteeringBehaviour se tiene que combinar
        //// con las cinemáticas de los demás SteeringBehaviour.
        //// Debes usar kinematic con el árbitro desesado para combinar todos
        //// los SteeringBehaviour.
        //// Llamaremos kinematicFinal a la aceleraciones finales de esas combinaciones.

        // A continuación debería entrar a funcionar el actuador para comprobar
        // si la propuesta de movimiento es factible:
        // kinematicFinal = Actuador(kinematicFinal, self)

        // El resultado final se guarda para ser aplicado en el siguiente frame.
        this.steer = kinematicFinal;
    }
}
