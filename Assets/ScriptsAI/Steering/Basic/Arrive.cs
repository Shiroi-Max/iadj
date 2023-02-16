using UnityEngine;

public class Arrive : SteeringBehaviour
{
    public float timeToTarget = 5;

    void Start()
    {
        this.nameSteering = "Arrive";
    }

    public override Steering GetSteering(Agent agent)
    {
        Steering steer = new Steering();

        if (target == null) return steer;

        Vector3 direction = target.Position - agent.Position;
        float distance = direction.magnitude;
        if (distance >= agent.InteriorRadius)
        {
            float targetSpeed;
            if (distance > agent.ArrivalRadius)
                targetSpeed = agent.MaxSpeed;
            else
                targetSpeed = agent.MaxSpeed * distance / agent.ArrivalRadius;

            Vector3 targetVelocity = direction.normalized * targetSpeed;
            steer.linear = (targetVelocity - agent.Velocity) / timeToTarget;

            if (steer.linear.magnitude > agent.MaxAcceleration)
                steer.linear = steer.linear.normalized * agent.MaxAcceleration;
        }
        else if (agent.Velocity.magnitude > .01)
            steer.linear = agent.Velocity * -1;

        return steer;
    }
}