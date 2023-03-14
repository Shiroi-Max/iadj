using UnityEngine;

[AddComponentMenu("Steering/InteractiveObject/Agent")]
public class Agent : Bodi
{
    [Tooltip("Radio interior de la IA")]
    [SerializeField] protected float _interiorRadius = 1f;

    [Tooltip("Radio de llegada de la IA")]
    [SerializeField] protected float _arrivalRadius = 3f;

    [Tooltip("Ángulo interior de la IA")]
    [SerializeField] protected float _interiorAngle = 3.0f; // ángulo sexagesimal.

    [Tooltip("Ángulo exterior de la IA")]
    [SerializeField] protected float _exteriorAngle = 8.0f; // ángulo sexagesimal.

    public float InteriorRadius
    {
        get { return _interiorRadius; }
        set { if (value < _arrivalRadius) _interiorRadius = value; }
    }

    public float ArrivalRadius
    {
        get { return _arrivalRadius; }
        set { if (value > _interiorRadius) _arrivalRadius = value; }
    }

    public float InteriorAngle
    {
        get { return _interiorAngle; }
        set { if (value < _exteriorAngle) _interiorAngle = value; }
    }

    public float ExteriorAngle
    {
        get { return _exteriorAngle; }
        set { if (value > _interiorAngle) _exteriorAngle = value; }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _interiorRadius);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _arrivalRadius);
    }
}
