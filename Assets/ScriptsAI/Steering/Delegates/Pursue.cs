using UnityEngine;

public class Pursue : SteeringBehaviour
{
    public Seek seek;
    private Agent npcVirtualTemp;
    public Agent npcVirtual;
    public float maxPrediction = 10;

    void Start()
    {
        this.nameSteering = "Pursue";
    }

    public override Steering GetSteering(Agent agent)
    {
        Vector3 direction = target.Position - agent.Position;
        float distance = direction.magnitude;
        float speed = agent.Velocity.magnitude;

        float prediction;
        if (speed <= distance / maxPrediction)
            prediction = maxPrediction;
        else
            prediction = distance / speed;

        if (npcVirtualTemp == null)
            npcVirtualTemp = Instantiate(npcVirtual);
        npcVirtualTemp.Position = target.Position;
        npcVirtualTemp.Position += target.Velocity * prediction;
        seek.target = npcVirtualTemp;

        return seek.GetSteering(agent);
    }
}
