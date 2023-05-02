using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Aligmet")]
public class AligmentBehavior : FilteredSheepBehavior// Hizalama davranisi
{
    public override Vector3 CalculateMove(SheepAgent agent, List<Transform> context, SheepM sheep)
    {
        // if no neighbors
        if (context.Count == 0)
            return Vector3.zero;//agent.transform.forward;

        Vector3 aligmentMove = Vector3.zero;
        List<Transform> filteredContext = (filter == null) ? context : filter.Filter(agent, context);
        foreach (Transform item in filteredContext)
        {
            aligmentMove += item.transform.forward;
        }

        aligmentMove /= context.Count;

        //aligmetMove -= (Vector2)agent.transform.position;

        return aligmentMove;
    }
}
