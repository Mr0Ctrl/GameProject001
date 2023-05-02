using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Herd Behavior")]
public class HerdBehavior : SheepBehavior {
    Vector3 shForce;
    Vector3 center;
    public float radius = 5f;//bu degiskeni herd den cekacegim. herdrange-1

    public override Vector3 CalculateMove(SheepAgent agent, List<Transform> context, SheepM sheep)
    {
        shForce = GameObject.Find("herd").GetComponent<HerdBrain>().shForce;
        center = GameObject.Find("herd").GetComponent<Transform>().position;

        Vector3 centerOffset = center - agent.transform.position ;
        float t = centerOffset.magnitude / (radius);// 1 

        if (t < 1)
        {
            return  shForce + centerOffset.normalized * Mathf.Pow(t, 2)/2;
        }
        
        return agent.transform.forward/2;//Vector3.zero;

    }
}
