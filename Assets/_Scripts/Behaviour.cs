using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Behaviour : ScriptableObject
{
    public abstract Vector2 CalculateMovement(Agent agent, List<Transform> objectsAround, Flocking flock);
}
