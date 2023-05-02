using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SheepBehavior : ScriptableObject
{

    public abstract Vector3 CalculateMove(SheepAgent agent, List<Transform> context, SheepM flock);


}
