using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]

public class SheepAgent : MonoBehaviour
{
    Collider sBase;
    MenuUi menuUi;

    SheepM agentSheep;
    public SheepM AgentSeep { get { return agentSheep; } }

    Collider agentCollider;
    public Collider AgentCollider { get { return agentCollider; } }

    //Singelton 


    void Start()
    {
        agentCollider = GetComponent<Collider>();
        sBase = GameObject.Find("Base").GetComponent<Collider>();
        menuUi = GameObject.Find("Canvas").GetComponent<MenuUi>();
        
        
    }


    public void Initilaze(SheepM flock)
    {
        agentSheep = flock;
    }

    // anlamadim burayi
    public void Move(Vector3 velocity)
    {
        if (velocity != Vector3.zero)
        {
            transform.forward = velocity;
            transform.position += velocity * Time.deltaTime;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        menuUi.point++;
        gameObject.SetActive(false);
    }
}
