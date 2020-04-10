using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Flocking/AvoidanceBehaviour")]
public class AvoidanceBehaviour : FilterFlockBehaviour
{
    public override Vector2 CalculateMovement(Agent agent, List<Transform> objectsAround, Flocking flock)
    {
        // if no neighbors, no fix needed, return zero
        if (objectsAround.Count == 0)
            return Vector2.zero;

        // add all point, calculate the average point between them
        //var avoidanceMovement = objectsAround.Aggregate(
        //    Vector2.zero,
        //    (current, t) => current + (Vector2)t.transform.up
        //);
        var avoidanceMovement = Vector2.zero;
        var nAvoid = 0;
        List<Transform> filterContext = (filter == null)
            ? objectsAround
            : filter.filter(agent, objectsAround);
        for (var i = 0; i < filterContext.Count; i++)
        {
            if (Vector2.SqrMagnitude(filterContext[i].position - agent.transform.position) < flock.SquareDistance)
            {
                nAvoid++;
                avoidanceMovement += (Vector2) (agent.transform.position - filterContext[i].position);
            }
        }

        if (nAvoid >= 0)
        {
            avoidanceMovement /= nAvoid;
        }

        return avoidanceMovement;
    }
}
