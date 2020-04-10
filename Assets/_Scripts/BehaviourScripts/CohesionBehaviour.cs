using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Flocking/CohesionBehaviour")]
public class CohesionBehaviour : FilterFlockBehaviour
{
    // Smoothe the movement 
    Vector2 currentVelocity;
    public float smoothTimeMovement = 0.7f;

    public override Vector2 CalculateMovement(Agent agent, List<Transform> objectsAround, Flocking flock)
    {
        // if no neighbors, no fix needed, return zero
        if (objectsAround.Count == 0)
            return Vector2.zero;

        // add all point, calculate the average point between them
        //var cohesionMovement = objectsAround.Aggregate(
        //    Vector2.zero,
        //    (current, t) => current + (Vector2) t.position
        //);
        var cohesionMovement = Vector2.zero;
        List<Transform> filterContext = (filter == null) 
                ? objectsAround 
                : filter.filter(agent, objectsAround);
        for (var i = 0; i < filterContext.Count; i++)
        {
            cohesionMovement += (Vector2)filterContext[i].position;
        }
        cohesionMovement /= objectsAround.Count;
        
        // create offset from position
        cohesionMovement -= (Vector2) agent.transform.position;
        cohesionMovement = Vector2.SmoothDamp(
                agent.transform.up,
                cohesionMovement,
                ref currentVelocity,
                smoothTimeMovement
        );
        return cohesionMovement;
    }
}
