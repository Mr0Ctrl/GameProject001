using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepM : MonoBehaviour
{
    #region variable
    public SheepAgent agentPrefab;

    List<SheepAgent> agents = new List<SheepAgent>();

    public SheepBehavior behavior;

    public bool spawn = true;

    [Range(3, 500)]
    public int startingCount = 250;
    const float AgentDensity = 0.7f;

    [Range(0f, 10f)]
    public float driveFactor = 10f;

    [Range(0f, 50f)]
    public float maxSpeed = 5f;

    [Range(0, 10f)]
    public float neighborRadius = 1.5f;

    [Range(0f, 1f)]
    public float avoidanceRadiusMultiplier = 0.5f;


    float squareMaxSpeed;
    float squareNeighborRadius;
    float squareAvoidanceRadius;
    public float AvoidanceRadius;

    Vector3 location;

    #endregion



    void Start()
    {
        squareMaxSpeed = maxSpeed * maxSpeed;
        squareNeighborRadius = neighborRadius * neighborRadius;
        squareAvoidanceRadius = squareNeighborRadius * avoidanceRadiusMultiplier;


        for (int i = 0; i < startingCount; i++)//koyun spawnla
        {
            location = Random.insideUnitCircle * startingCount * AgentDensity;
            location.z = location.y;
            location.y = transform.position.y;

            SheepAgent newAgent = Instantiate(
                agentPrefab,
                location,
                Quaternion.Euler(Vector3.up * Random.Range(0f, 360f)),
                transform
                );
            newAgent.name = "Sheep" + i;
            newAgent.Initilaze(this);
            agents.Add(newAgent);

        }
        
            StartCoroutine(Spawn(startingCount));

    }

    IEnumerator Spawn(int a)
    {   
        int turn = a;
        while (spawn)
        {
            yield return new WaitForSeconds(5f);
            //Debug.Log("Koyun Geldi");
            location = Random.insideUnitCircle * startingCount * AgentDensity;
            location.z = location.y;
            location.y = transform.position.y;

            SheepAgent newAgent = Instantiate(
                agentPrefab,
                location,
                Quaternion.Euler(Vector3.up * Random.Range(0f, 360f)),
                transform
                );
            newAgent.name = "Sheep" + a;
            newAgent.Initilaze(this);
            agents.Add(newAgent);
            a++;

        }

    }


    void Update()
    {

        // itere et ve her elaman için hareket hesapla
        foreach (SheepAgent agent in agents)
        {
            if (!agent.gameObject.activeSelf)
            {
                location = Random.insideUnitCircle * startingCount * AgentDensity;
                location.z = location.y;
                location.y = transform.position.y;

                agent.transform.position = location;
                agent.gameObject.SetActive(true);
            }
            

            List<Transform> context = GetNearbyObjects(agent);

            //context listesinin elaman sayisina gore renk degistiriyor

            Vector3 move = behavior.CalculateMove(agent, context, this);
            move *= driveFactor;

            if (move.sqrMagnitude > squareMaxSpeed)
            {
                move = move.normalized * maxSpeed;
            }
            agent.Move(move);
            agent.GetComponentInChildren<Renderer>().material.color = Color.Lerp(Color.white, Color.black, move.magnitude / 5f);


            
        }

        //Sheep uret
    }

    List<Transform> GetNearbyObjects(SheepAgent agent)
    {
        List<Transform> context = new List<Transform>();

        // belirli  merkez noktsi ve yari capi icerisindeki tum nesneler
        Collider[] contextColliders = Physics.OverlapSphere(agent.transform.position, neighborRadius);

        foreach (Collider c in contextColliders)
        {
            if (c != agent.AgentCollider)
            {
                context.Add(c.transform);
            }
        }
        return context;
    }
}
