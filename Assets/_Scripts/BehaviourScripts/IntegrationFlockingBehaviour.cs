using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flocking/Integration")]
public class IntegrationFlockingBehaviour : Behaviour
{
    public Behaviour[] behavious;
    public float[] scalars;

    public override Vector2 CalculateMovement(Agent agent, List<Transform> objectsAround, Flocking flock)
    {
        if (behavious.Length != scalars.Length)
        {
            Debug.LogError($"Data not the same size {name}", this);
            return Vector2.zero;
        }

        Vector2 move = Vector2.zero;

        for (int i = 0; i < behavious.Length; i++)
        {
            Vector2 partialMove = behavious[i].CalculateMovement(agent, objectsAround, flock) * scalars[i];

            if (partialMove != Vector2.zero)
            {
                if (partialMove.sqrMagnitude > scalars[i] * scalars[i])
                {
                    partialMove.Normalize();
                    partialMove *= scalars[i];
                }

                move += partialMove;
            }
        }

        return move;

    }
}
