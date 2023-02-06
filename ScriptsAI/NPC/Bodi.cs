using UnityEngine;

public class Bodi : MonoBehaviour
{

    [SerializeField] protected float _mass = 1;
    [SerializeField] protected float _maxSpeed = 1;
    [SerializeField] protected float _maxRotation = 1;
    [SerializeField] protected float _maxAcceleration = 1;
    [SerializeField] protected float _maxAngularAcc = 1;
    [SerializeField] protected float _maxForce = 1;

    protected Vector3 _acceleration; // aceleración lineal
    protected float _angularAcc;  // aceleración angular
    protected Vector3 _velocity; // velocidad lineal
    protected float _rotation;  // velocidad angular
    protected float _speed;  // velocidad escalar
    protected float _orientation;  // 'posición' angular
    // Se usará transform.position como 'posición' lineal

    /// Un ejemplo de cómo construir una propiedad en C#
    /// <summary>
    /// Mass for the NPC
    /// </summary>
    public float Mass
    {
        get { return _mass; }
        set { _mass = Mathf.Max(0, value); }
    }

    // CONSTRUYE LAS PROPIEDADES SIGUENTES. PUEDES CAMBIAR LOS NOMBRE A TU GUSTO
    // Lo importante es controlar el set
    public float MaxForce
    {
        get { return _maxForce; }
        set { _maxForce = Mathf.Max(0, value); }
    }
    public float MaxSpeed
    {
        get { return _maxSpeed; }
        set { _maxSpeed = Mathf.Max(0, value); }
    }
    public Vector3 Velocity
    {
        get
        {
            if (_velocity == null)
                return new Vector3();
            else
                return new Vector3(_velocity);
        }
        set
        {
            if (value.magnitude() <= .1) _velocity = new Vector3();
            else _velocity = new Vector3(value);
        }
    }
    // public float MaxRotation
    // public float Rotation. 
    // public float MaxAcceleration
    // public Vector3 Acceleration
    // public float AngularAcc
    // public Vector3 Position. Recuerda. Esta es la única propiedad que trabaja sobre transform.
    public Vector3 Position
    {
        get { return transform.position; }
        set { transform.position = value; }
    }

    // public float Orientation
    // public float Speed  

    // TE PUEDEN INTERESAR LOS SIGUIENTES MÉTODOS.
    // Añade todos los que sean referentes a la parte física.

    // public float Heading()
    //      Retorna el ángulo heading en (-180, 180) en grado o radianes. Lo que consideres
    // public static float MapToRange(float rotation, Range r)
    //      Retorna un ángulo de (-180, 180) a (0, 360) expresado en grado or radianes
    // public float MapToRange(Range r)
    //      Retorna la orientación de este bodi, un ángulo de (-180, 180), a (0, 360) expresado en grado or radianes
    // public float PositionToAngle()
    //      Retorna el ángulo de una posición usando el eje Z como el primer eje
    // public Vector3 OrientationToVector()
    //      Retorna un vector a partir de una orientación usando Z como primer eje
    // public Vector3 VectorHeading()  // Nombre alternativo
    //      Retorna un vector a partir de una orientación usando Z como primer eje
    // public float GetMiniminAngleTo(Vector3 rotation)
    //      Determina el menor ángulo en 2.5D para que desde la orientación actual mire en la dirección del vector dado como parámetro
    // public void ResetOrientation()
    //      Resetea la orientación del bodi
    // public float PredictNearestApproachTime(Bodi other, float timeInit, float timeEnd)
    //      Predice el tiempo hasta el acercamiento más cercano entre este y otro vehículo entre B y T (p.e. [0, Mathf.Infinity])
    // public float PredictNearestApproachDistance3(Bodi other, float timeInit, float timeEnd)

}
