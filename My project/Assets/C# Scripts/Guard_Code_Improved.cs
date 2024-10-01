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
    public CameraClass nearest_Camera;

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
        else if(nearest_Camera.player_spotted)
        {
            agent.SetDestination(nearest_Camera.player.transform.position);
        }
        else if(!nearest_Camera.player_spotted && nearest_Camera.player_leave)
        {
            agent.SetDestination(nearest_Camera.Last_locaiton);
            nearest_Camera.player_leave = false;
        }
        if(agent.velocity == new Vector3(0,0,0))
        {
            fin_Location = NewDestination();
            agent.SetDestination(fin_Location);
        }
    }



    Vector3 NewDestination()
    {

        x = Random.Range(transform.position.x-10,transform.position.x + 10);
        y = 1;
        z = Random.Range(transform.position.z-10,transform.position.z + 10);

        return new Vector3(x,y,z);

    }

}
