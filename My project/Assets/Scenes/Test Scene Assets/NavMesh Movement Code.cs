using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI;
using UnityEditor.Search;
using UnityEngine.AI;
using UnityEngine.Rendering;

public class GuardCode : MonoBehaviour
{
    
    [SerializeField]
    Vector3 fin_Location;
    NavMeshAgent agent;
    [SerializeField]
    float x,y,z;
    public POV fov;

    void Start()
    {
        Cursor.visible = false;
        agent = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        if(fov.canSeePlayer)
        {
            agent.SetDestination(fov.playerRef.transform.position);
        }
        if(agent.velocity == new Vector3(0,0,0))
        {
            fin_Location = NewDestination();
            agent.SetDestination(fin_Location);
            Stop();
        }
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
