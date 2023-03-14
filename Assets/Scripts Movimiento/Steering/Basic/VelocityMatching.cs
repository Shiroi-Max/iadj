using UnityEngine;

public class VelocityMatching : SteeringBehaviour
{

    [SerializeField] private float timeToTarget = .1f;

    void Start()
    {
        this.nameSteering = "VelocityMatching";
    }

    public override Steering GetSteering(Agent agent)
    {
        Steering steer = new Steering();
        if (target == null) return steer;

        steer.linear = (target.Velocity - agent.Velocity) / timeToTarget;
        if (steer.linear.magnitude > agent.MaxAcceleration)
            steer.linear = steer.linear.normalized * agent.MaxAcceleration;

        return steer;
    }
}