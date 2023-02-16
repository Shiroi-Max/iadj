using UnityEngine;

public class Face : SteeringBehaviour
{
    public Align align;
    private Agent npcVirtualTemp;
    public Agent npcVirtual;


    void Start()
    {
        this.nameSteering = "Face";
    }

    public override Steering GetSteering(Agent agent)
    {
        if (target == null) return new Steering();

        Vector3 direction = target.Position - agent.Position;
        if (direction.magnitude == 0) return new Steering();


        if (npcVirtualTemp == null)
            npcVirtualTemp = Instantiate(npcVirtual);
        npcVirtualTemp.Orientation = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        align.target = npcVirtualTemp;

        return align.GetSteering(agent);
    }
}
