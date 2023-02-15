using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Face : SteeringBehaviour
{
    public Align align;
    private Agent npcvtemp;
    public Agent npcv;


    void Start()
    {
        this.nameSteering = "Face";
    }

    public override Steering GetSteering(Agent agent)
    {
        if (target == null) return new Steering();

        Vector3 direction = target.Position - agent.Position;
        if (direction.magnitude == 0) return new Steering();


        if (npcvtemp == null)
            npcvtemp = Instantiate(npcv);
        npcvtemp.Orientation = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        align.target = npcvtemp;

        return align.GetSteering(agent);
    }
}
