using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Flock/Behavior/StayInRadiusBehavior")]
public class StayInRadiusBehavior : SheepBehavior
{
    public Vector3 center;
    public float radius = 15f;

    public override Vector3 CalculateMove(SheepAgent agent, List<Transform> context, SheepM sheep)
    {
        Vector3 centerOffset = center - agent.transform.position;
        float t = centerOffset.magnitude / radius;
        if (t < 0.9f)
        {
            return Vector3.zero;
        }
        return centerOffset * t * t /5;
    }
}
