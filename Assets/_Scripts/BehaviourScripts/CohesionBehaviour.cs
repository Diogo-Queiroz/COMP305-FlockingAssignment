using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Flocking/CohesionBehaviour")]
public class CohesionBehaviour : Behaviour
{
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
        for (var i = 0; i < objectsAround.Count; i++)
        {
            cohesionMovement += (Vector2)objectsAround[i].position;
        }
        cohesionMovement /= objectsAround.Count;
        
        // create offset from position
        cohesionMovement -= (Vector2) agent.transform.position;
        return cohesionMovement;
    }
}
