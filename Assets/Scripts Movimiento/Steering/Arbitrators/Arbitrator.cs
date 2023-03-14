using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
class BehaviourData
{
    public string name;
    public float weight;
}

[RequireComponent(typeof(AgentNPC))]
public class Arbitrator : MonoBehaviour
{
    [SerializeField] private List<BehaviourData> behaviourWeightsList;
    protected Dictionary<string, float> behaviourWeights;

    public void Start()
    {
        behaviourWeights = new Dictionary<string, float>();
        for (int i = 0; i < behaviourWeightsList.Count; i++)
            behaviourWeights.Add(behaviourWeightsList[i].name, behaviourWeightsList[i].weight);
    }

    public virtual Steering getSteering(List<SteeringBehaviour> listSteerings, Agent agent)
    {
        return null;
    }
}