using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentNPC : Agent
{
    [SerializeField] protected Steering steer;
    public ArbitratorManager arbitratorManager;
    private List<SteeringBehaviour> listSteerings;

    protected void Awake()
    {
        this.steer = new Steering();
        listSteerings = new List<SteeringBehaviour>();

        foreach (SteeringBehaviour st in GetComponents(typeof(SteeringBehaviour)))
        {
            listSteerings.Add(st);
        }
    }

    void Start()
    {
        this.Velocity = Vector3.zero;
    }

    public virtual void Update()
    {
        ApplySteering(Time.deltaTime);
    }

    private void ApplySteering(float deltaTime)
    {
        Acceleration = this.steer.linear;
        AngularAcc = this.steer.angular;
        if (this.GetComponent<Brain>().Status == Status.Stopped)
            return;
        Position = Position + Velocity * deltaTime;
        Orientation = Orientation + Rotation * deltaTime;
        Velocity = Velocity + Acceleration * deltaTime;
        Rotation = Rotation + AngularAcc * deltaTime;
  
        transform.rotation = new Quaternion();
        transform.Rotate(Vector3.up, Orientation);
    }

    public virtual void LateUpdate()
    {
        Steering kinematicFinal = new Steering();

        this.steer = new Steering();
        Arbitrator arbitrator = arbitratorManager.Actual;
        kinematicFinal = arbitrator.getSteering(listSteerings, this);

        this.steer = kinematicFinal;
    }
}
