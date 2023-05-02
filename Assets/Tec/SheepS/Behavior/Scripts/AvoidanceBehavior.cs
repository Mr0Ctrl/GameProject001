using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Avoidance")]
public class AvoidanceBehavior : FilteredSheepBehavior// Kacinma Davranisi // tam istedigim gibi degil
{
    private Vector3 avoid;

    public override Vector3 CalculateMove(SheepAgent agent, List<Transform> context, SheepM sheep)
    {
        // if no neighbors
        if (context.Count == 0)
            return agent.transform.forward;//Vector3.zero;

        Vector3 avoidanceMove = Vector3.zero;
        int nAvoid = 0;

        List<Transform> filteredContext = (filter == null) ? context : filter.Filter(agent, context);
        foreach (Transform item in filteredContext)
        {
            avoid = item.position - agent.transform.position;
            if (avoid.magnitude < sheep.AvoidanceRadius)//tm daha iyi oldu bu matematigi kullan
            {
                Debug.Log(agent.name);
                nAvoid++;
                avoidanceMove += (-avoid).normalized*(sheep.AvoidanceRadius-avoid.magnitude);
            }
            
        }

        if (nAvoid > 0)
            avoidanceMove /= nAvoid;

        return avoidanceMove;
    }
}
