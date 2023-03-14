using UnityEngine;

public class LeaderFollowing : SteeringBehaviour
{
    [SerializeField] private Arrive arrive;
    [SerializeField] private Separation separation;
    [SerializeField] private float factor;
    [SerializeField] private Agent npcVirtual;

    private Agent npcVirtualTemp;

    void Start()
    {
        this.nameSteering = "Leader Following";
    }

    public override Steering GetSteering(Agent agent)
    {
        Vector3 direction = target.Velocity.normalized * factor;
        Vector3 position = target.Position - direction;

        if (npcVirtualTemp == null)
            npcVirtualTemp = Instantiate(npcVirtual);
        npcVirtualTemp.Position = position;
        arrive.target = npcVirtualTemp;

        Steering steer = arrive.GetSteering(agent);
        steer.linear += separation.GetSteering(agent).linear;
        return steer;
    }
}