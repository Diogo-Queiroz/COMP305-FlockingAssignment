using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FlockFilter/Same")]
public class SameFlockFilter : FilterFlocking
{
    public override List<Transform> filter(Agent agent, List<Transform> original)
    {
        var filtered = new List<Transform>();

        // ReSharper disable once ForCanBeConvertedToForeach
        for (var i = 0; i < original.Count; i++)
        {
            var iAgent = original[i].GetComponent<Agent>();
            if (iAgent != null && iAgent.AgentFlocking == agent.AgentFlocking)
            {
                filtered.Add(original[i]);
            }
        }

        return filtered;
    }
}
