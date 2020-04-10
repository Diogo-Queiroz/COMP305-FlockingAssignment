using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FlockFilter/Obstacle")]
public class ObstacleFlockFilter : FilterFlocking
{
    public LayerMask obstacleLayer;

    public override List<Transform> filter(Agent agent, List<Transform> original)
    {
        var filtered = new List<Transform>();

        // ReSharper disable once ForCanBeConvertedToForeach
        for (var i = 0; i < original.Count; i++)
        {
            if (obstacleLayer == obstacleLayer)// | (1 << original[i].gameObject.layer)))
            {
                filtered.Add(original[i]);
            }
        }

        return filtered;
    }
}
