using UnityEngine;

public class AntiAlign : SteeringBehaviour
{
    [SerializeField] private Align align;
    [SerializeField] private Agent npcVirtual;

    private Agent npcVirtualTemp;

    void Start()
    {
        this.nameSteering = "AntiAlign";
    }

    public override Steering GetSteering(Agent agent)
    {
        if (target == null)
        {
            Steering steer = new Steering();
            return steer;
        }

        if (npcVirtualTemp == null)
            npcVirtualTemp = Instantiate(npcVirtual);
        if (target.Orientation > 180)
            npcVirtualTemp.Orientation = target.Orientation - 180;
        else
            npcVirtualTemp.Orientation = target.Orientation + 180;
        align.target = npcVirtualTemp;

        return align.GetSteering(agent);
    }
}