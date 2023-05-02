using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Flock/Behavior/Composite")]

public class CompositeBehavior : SheepBehavior
{
    public SheepBehavior[] behaviors;
    public float[] weights;

    Vector3 currentVelocity;

    public override Vector3 CalculateMove(SheepAgent agent, List<Transform> context, SheepM sheep)
    {
        

        if (weights.Length != behaviors.Length)
        {
            Debug.LogError("Data mismatch in" + name, this);
            return Vector3.zero;
        }

        Vector3 move = Vector3.zero;
        for (int i = 0; i < behaviors.Length; i++)
        {
            Vector3 partialMove = behaviors[i].CalculateMove(agent, context, sheep) * weights[i];

            if (partialMove != Vector3.zero)
            {
                /*
                if (partialMove.sqrMagnitude > weights[i] * weights[i])// bu fonksiyon ne boka yariyor
                {
                    partialMove.Normalize();
                    partialMove *= weights[i];
                }*/

                move += partialMove;

            }
        }
        move.y = 0;

        return move;
    }
}

