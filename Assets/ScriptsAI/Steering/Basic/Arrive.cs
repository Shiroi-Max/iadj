using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrive : SteeringBehaviour
{

    // Declara las variables que necesites para este SteeringBehaviour
    public float arriveTime = 5;

    void Start()
    {
        this.nameSteering = "Pon su nombre";
    }

    public override Steering GetSteering(Agent agent)
    {
        Steering steer = new Steering();
        steer.angular = 0;

        if (target != null)
        {
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
                steer.linear = (targetVelocity - agent.Velocity) / arriveTime;

                if (steer.linear.magnitude > agent.MaxAcceleration)
                    steer.linear = steer.linear.normalized * agent.MaxAcceleration;

                return steer;
            }
        }
        steer.linear = Vector3.zero;
        return steer;
    }
}