using UnityEngine;


[RequireComponent(typeof(AgentNPC))]
public class SteeringBehaviour : MonoBehaviour
{
    protected string nameSteering = "no steering";
    public Agent target = null;

    public string NameSteering
    {
        set { nameSteering = value; }
        get { return nameSteering; }
    }

    public void NewTarget(Agent target)
    {
        if (this.target != null && this.target.CompareTag("NPC Virtual"))
            Destroy(this.target.gameObject);
        this.target = target;
    }

    public virtual Steering GetSteering(Agent agent)
    {
        return null;
    }
}
