using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BehaviourData
{
    public string name;
    public float weight;
}

[RequireComponent(typeof(AgentNPC))]
public class Arbitrator : MonoBehaviour
{
    protected Dictionary<string, float> behaviourWeights;
    public List<BehaviourData> behaviourWeightsList;

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