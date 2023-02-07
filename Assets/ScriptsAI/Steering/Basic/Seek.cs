using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : SteeringBehaviour
{

    // Declara las variables que necesites para este SteeringBehaviour
    public Agent target;

    void Start()
    {
        this.nameSteering = "Pon su nombre";
    }


    public override Steering GetSteering(Agent agent)
    {
        Steering steer = new Steering();
        // Calcula el steering.
        Vector3 v = target.Position - agent.Position;
        v = v.normalized * agent.MaxAcceleration;
        steer.linear = v;
        steer.angular = 0;
        // Retornamos el resultado final.
        return steer;
    }
}