using System.Linq;
using UnityEngine;

public class Separation : SteeringBehaviour
{
    public float threshold;
    public float decayCoefficient;

    void Start()
    {
        this.nameSteering = "Separation";
    }

    public override Steering GetSteering(Agent agent)
    {
        Steering steer = new Steering();
        Collider[] hitColliders = Physics.OverlapSphere(agent.Position, threshold);
        GameObject[] targets = hitColliders.Select(target => target.gameObject).ToArray();

        foreach (GameObject target in targets)
        {
            if (!target.CompareTag("NPC")) continue;
        
            Vector3 direction = target.GetComponent<AgentNPC>().Position - agent.Position;
            float distance = direction.magnitude;
            float strength = Mathf.Min(decayCoefficient / (distance * distance), agent.MaxAcceleration);
            steer.linear -= strength * direction.normalized;
        }

        return steer;
    }
}