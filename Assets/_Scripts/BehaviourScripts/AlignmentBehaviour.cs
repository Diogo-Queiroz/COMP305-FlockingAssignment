using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Flocking/AlignmentBehaviour")]
public class AlignmentBehaviour : Behaviour
{
    public override Vector2 CalculateMovement(Agent agent, List<Transform> objectsAround, Flocking flock)
    {
        // if no neighbors, no fix needed, maintain alignment
        if (objectsAround.Count == 0)
            return agent.transform.up;

        // add all point, calculate the average point between them
        //var alignmentMovement = objectsAround.Aggregate(
        //    Vector2.zero,
        //    (current, t) => current + (Vector2)t.transform.up
        //);
        var alignmentMovement = Vector2.zero;
        for (var i = 0; i < objectsAround.Count; i++)
        {
            alignmentMovement += (Vector2)objectsAround[i].transform.up;
        }
        alignmentMovement /= objectsAround.Count;

        return alignmentMovement;
    }
}
