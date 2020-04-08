using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flocking/Screen Boundaries")]
public class ScreenBoundaries : Behaviour
{
    public Vector2 center;
    public float radius = 16f;
    
    public override Vector2 CalculateMovement(Agent agent, List<Transform> objectsAround, Flocking flock)
    {
        Vector2 offset = center - (Vector2) agent.transform.position;
        float t = offset.magnitude / radius;

        if (t < 0.9f)
        {
            return Vector2.zero;
        }

        return offset * t * t;
    }
}
