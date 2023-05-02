using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Filter/Same Flock")]
public class SameFlockFilter : ContexFilter
{
    public override List<Transform> Filter(SheepAgent agent, List<Transform> original)
    {
        List<Transform> filtered = new List<Transform>();
        foreach (var item in original)
        {
            SheepAgent itemAgent = item.GetComponent<SheepAgent>();
            if (itemAgent != null && itemAgent.AgentSeep == agent.AgentSeep)
            {
                filtered.Add(item);
            }
        }
        return filtered;
    }
}
