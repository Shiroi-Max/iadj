using UnityEngine;

public class Seek : SteeringBehaviour
{
    void Start()
    {
        this.nameSteering = "Seek";
    }

    public override Steering GetSteering(Agent agent)
    {
        Steering steer = new Steering();

        if (target == null) return steer;

        Vector3 direction = target.Position - agent.Position;
        steer.linear = direction.normalized * agent.MaxAcceleration;

        return steer;
    }
}