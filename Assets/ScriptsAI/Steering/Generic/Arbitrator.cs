using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AgentNPC))]
public class Arbitrator : MonoBehaviour
{
    protected Dictionary<string, float> behaviourWeights;
    // public string[] behaviourName;
    // public float[] behaviourWeight;

    public void Start()
    {
        // behaviourWeights = new Dictionary<string, float>();
        // for (int i = 0; i < behaviourName.Length; i++)
        //     behaviourWeights.Add(behaviourName[i], behaviourWeight[i]);
    }

    public virtual Steering getSteering(List<SteeringBehaviour> listSteerings, Agent agent)
    {
        return null;
    }
}