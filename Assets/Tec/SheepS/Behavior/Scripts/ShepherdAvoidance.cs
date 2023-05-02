using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Shepherd Avoidance")]
public class ShepherdAvoidance: FilteredSheepBehavior// Kacinma Davranisi
{
    [Range(1f,20f)]
    public float range = 7f;
    public override Vector3 CalculateMove(SheepAgent agent, List<Transform> context, SheepM sheep)
    {
        // if no neighbors
        if (context.Count == 0)
            return Vector3.zero;

        Vector3 avoidanceMove = Vector3.zero;
        int nAvoid = 0;
        List<Transform> filteredContext = (filter == null) ? context : filter.Filter(agent, context);
        foreach (Transform item in filteredContext)
        {
            if (Vector3.SqrMagnitude(item.position-agent.transform.position)< range )//sheep.SquareAvoidanceRadius
            {

                float a = (item.position - agent.transform.position).magnitude;
                Vector3 b = (item.position - agent.transform.position).normalized;

                avoidanceMove += (a - range) * b;
                nAvoid++;
                //avoidanceMove += (agent.transform.position - item.position);
            }
            
        }

        if (nAvoid > 0)
            avoidanceMove /= nAvoid;

        return avoidanceMove;
    }
}
