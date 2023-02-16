using UnityEngine;

public class AntiAlign : SteeringBehaviour
{
    public Align align;
    private Agent npcVirtual;

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

        if (npcVirtual == null)
            npcVirtual = Instantiate(target);

        npcVirtual.gameObject.SetActive(false);
        if (target.Orientation > 180)
            npcVirtual.Orientation = target.Orientation - 180;
        else
            npcVirtual.Orientation = target.Orientation + 180;

        align.target = npcVirtual;
        return align.GetSteering(agent);
    }
}