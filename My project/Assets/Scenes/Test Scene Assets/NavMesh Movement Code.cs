using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI;
using UnityEditor.Search;
using UnityEngine.AI;

public class GuardCode : MonoBehaviour
{
    
    [SerializeField]
    Vector3 fin_Location;
    [SerializeField]
    LayerMask groundlayer, playerlayer;
    NavMeshAgent agent;
    [SerializeField]
    float x,y,z;
    float speed = 5;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(agent.velocity == new Vector3(0,0,0))
        {
            fin_Location = NewDestination();
            agent.SetDestination(fin_Location);
            Stop();
        }
        Stop();

    }

    IEnumerator Stop()
    {
        yield return 1f;
    }

    Vector3 NewDestination()
    {

        x = Random.Range(-10,10);
        y = 1;
        z = Random.Range(-10,10);

        return new Vector3(x,y,z);

    }

}
