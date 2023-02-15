using UnityEngine;
using UnityEngine.SocialPlatforms;

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
    public float MaxSpeed
    {
        get { return _maxSpeed; }
        set { _maxSpeed = Mathf.Max(0, value); }
    }
    public float MaxRotation
    {
        get { return _maxRotation; }
        set { _maxRotation = Mathf.Max(0, value); }
    }
    public float MaxAcceleration
    {
        get { return _maxAcceleration; }
        set { _maxAcceleration = Mathf.Max(0, value); }
    }
    public float MaxAngularAcc
    {
        get { return _maxAngularAcc; }
        set { _maxAngularAcc = Mathf.Max(0, value); }
    }
    public float MaxForce
    {
        get { return _maxForce; }
        set { _maxForce = Mathf.Max(0, value); }
    }
    public Vector3 Acceleration
    {
        get { return _acceleration; }
        set
        {
            if (value.magnitude <= .01) _acceleration = new Vector3(0, 0, 0);
            else _acceleration = value;
        }
    }
    public float AngularAcc
    {
        get { return _angularAcc; }
        set
        {
            if (Mathf.Abs(value) <= .01) _angularAcc = 0;
            else _angularAcc = value;
        }
    }
    public Vector3 Velocity
    {
        get { return _velocity; }
        set
        {
            if (value.magnitude <= .01) _velocity = new Vector3(0, 0, 0);
            else if (value.magnitude > _maxSpeed) _velocity = value.normalized * _maxSpeed;
            else _velocity = value;
        }
    }
    public float Rotation
    {
        get { return _rotation; }
        set
        {
            if (Mathf.Abs(value) <= .01) _rotation = 0;
            else _rotation = value;
        }
    }
    public float Speed
    {
        get { return _speed; }
        set
        {
            if (Mathf.Abs(value) <= .1) _speed = 0;
            else _speed = value;
        }
    }
    public Vector3 Position
    {
        get { return transform.position; }
        set { transform.position = value; }
    }
    public float Orientation
    {
        get { return _orientation; }
        set { _orientation = value; }
    }

    // TE PUEDEN INTERESAR LOS SIGUIENTES MÉTODOS.
    // Añade todos los que sean referentes a la parte física.

    // public float Heading()
    //      Retorna el ángulo heading en (-180, 180) en grado o radianes. Lo que consideres
    public static float MapToRange(float rotation, Range r)
    {
        float min = r.from;
        float max = min + r.count;
        if (rotation < max)
            return rotation;
        return rotation - max + min;
    }

    // public float MapToRange(Range r)
    //      Retorna la orientación de este bodi, un ángulo de (-180, 180), a (0, 360) expresado en grado or radianes
    // public float PositionToAngle()
    //      Retorna el ángulo de una posición usando el eje Z como el primer eje
    public Vector3 OrientationToVector()
    {
        return new Vector3(-Mathf.Sin(_orientation), 0, Mathf.Cos(_orientation));
    }
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
