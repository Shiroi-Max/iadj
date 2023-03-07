using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Status
{
    Stopped,
    Basic,
    Formation,
    Following
}

public class Brain : MonoBehaviour
{
    public Status status;

    public void Update()
    {
        AgentNPC agent = this.GetComponent<AgentNPC>();
        if (status == Status.Basic && agent.Acceleration.magnitude == 0 && agent.AngularAcc == 0)
            status = Status.Stopped;
        if (status == Status.Stopped && (agent.Acceleration.magnitude != 0 || agent.AngularAcc != 0))
            status = Status.Basic;
    }

    public void StartFormation(AgentNPC leader, int slotNumber)
    {
        if (status == Status.Formation) return;
        
        Formation formation = this.GetComponent<Formation>();
        formation.Leader = leader;
        formation.SlotNumber = slotNumber;
        status = Status.Formation;
    }

    public void BreakFormation()
    {
        if (status != Status.Formation) return;

        Formation formation = this.GetComponent<Formation>();
        formation.Leader = null;
        status = Status.Basic;
    }

    public void FollowFormation(AgentNPC leader)
    {
        if (status != Status.Formation) return;
        
        this.GetComponent<LeaderFollowing>().target = leader;
        this.GetComponent<ArbitratorManager>().StartFollowing();
        status = Status.Following;
    }
}