using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Flocking/AlignmentBehaviour")]
public class AlignmentBehaviour : FilterFlockBehaviour
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
        List<Transform> filterContext = (filter == null)
            ? objectsAround
            : filter.filter(agent, objectsAround);
        for (var i = 0; i < filterContext.Count; i++)
        {
            alignmentMovement += (Vector2)filterContext[i].transform.up;
        }
        alignmentMovement /= filterContext.Count;

        return alignmentMovement;
    }
}
