using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiAlign : SteeringBehaviour
{
    public Align align;
    private Agent npcv;

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

        if (npcv == null)
            npcv = Instantiate(target);

        npcv.gameObject.SetActive(false);
        if (target.Orientation > 180)
            npcv.Orientation = target.Orientation - 180;
        else
            npcv.Orientation = target.Orientation + 180;

        align.target = npcv;
        return align.GetSteering(agent);
    }
}