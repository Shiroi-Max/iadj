using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotAleatoria : MonoBehaviour
{
    public float velocity = 4; // Máxima velocidad
    // Control del tiempo
    public float deltaTime = 0.25f; // Intervalo de tiempo.
    private float time = 0f; // Tiempo acumulado entre frames.
    // Control de la orientación
    public float maxAngle = 360; // Una circunferencia
    private float angle = 0f; // Angulo de orientación actual.
    private float newAngle = 0f; // Nuevo ángulo (será aleatorio)
    void Update()
    {
        time += Time.deltaTime ; // Tiempo acumulado transcurrido
        if (time >= deltaTime ) // Si se alcanzó el intervalo temporal ...
        {
            newAngle = (Random.value - Random.value ) * maxAngle ; // cambiar el ángulo de orientación.
            time = 0; // Vuelta a empezar
        }
        // Linearly interpolates between a and b by t. Especial para ángulos.
        angle = Mathf.LerpAngle(angle, newAngle, Time.deltaTime); // Cambio suave
        // The rotation as Euler angles in degrees. Rotación para esa orientación.
        transform.eulerAngles = new Vector3(0, angle, 0);
        // Movimiento lineal
        transform.position += transform.forward * velocity * Time.deltaTime;
    }
}
