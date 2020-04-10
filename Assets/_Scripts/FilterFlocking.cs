using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FilterFlocking : ScriptableObject
{
    public abstract List<Transform> filter(Agent agent, List<Transform> original);
}
