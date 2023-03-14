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
    private Status _status;

    public Status Status
    {
        get { return _status; }
    }

    public void Update()
    {
        AgentNPC agent = this.GetComponent<AgentNPC>();
        if (_status == Status.Basic && agent.Acceleration.magnitude == 0 && agent.AngularAcc == 0)
            _status = Status.Stopped;
        if (_status == Status.Stopped && (agent.Acceleration.magnitude != 0 || agent.AngularAcc != 0))
            _status = Status.Basic;
    }

    public void StartFormation(AgentNPC leader, int slotNumber)
    {
        if (_status == Status.Formation) return;
        
        Formation formation = this.GetComponent<Formation>();
        formation.leader = leader;
        formation.slotNumber = slotNumber;
        _status = Status.Formation;
    }

    public void BreakFormation()
    {
        if (_status != Status.Formation) return;

        Formation formation = this.GetComponent<Formation>();
        formation.leader = null;
        _status = Status.Basic;
    }

    public void FollowFormation(AgentNPC leader)
    {
        if (_status != Status.Formation) return;
        
        this.GetComponent<LeaderFollowing>().target = leader;
        this.GetComponent<ArbitratorManager>().StartFollowing();
        _status = Status.Following;
    }
}