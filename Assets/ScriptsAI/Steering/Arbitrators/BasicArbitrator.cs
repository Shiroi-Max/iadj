using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AgentNPC))]
public class BasicArbitrator : Arbitrator
{
    public override Steering getSteering(List<SteeringBehaviour> listSteerings, Agent agent)
    {
        Steering steer = new Steering();

        foreach (SteeringBehaviour behavior in listSteerings)
            if (behaviourWeights.ContainsKey(behavior.NameSteering))
            {
                Steering steerTemp = behavior.GetSteering(agent);
                steer.linear += behaviourWeights[behavior.NameSteering] * steerTemp.linear;
                steer.angular += behaviourWeights[behavior.NameSteering] * steerTemp.angular;
            }

        if (steer.linear.magnitude > agent.MaxAcceleration)
            steer.linear = steer.linear.normalized * agent.MaxAcceleration;

        if (Mathf.Abs(steer.angular) > agent.MaxAngularAcc)
            steer.angular = agent.MaxAngularAcc * Mathf.Sign(steer.angular);

        return steer;
    }
}