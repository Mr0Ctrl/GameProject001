using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ContexFilter : ScriptableObject
{
    // Start is called before the first frame update
    public abstract List<Transform> Filter(SheepAgent agent, List<Transform> original);
}
