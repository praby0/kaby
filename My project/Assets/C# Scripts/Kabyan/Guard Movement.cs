using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.AI;
public class GuardMovements : MonoBehaviour
{
    public POV player_info;
    public float min_X;
    public float max_X;
    public float min_Z;
    public float max_Z;
    public float y_Value;
    public float speed;
    public Vector3 fin_location;
    public characterPositionWhenInPianoRange characterPositionWhenInPianoRange;
    public FirstPersonController firstPersonController;

    public bool loc_reached = true;
    public bool player_revealed = false;

    private float ran_X;
    private float ran_Z;
    private NavMeshAgent navMeshAgent;
    [SerializeField] private GameObject[] gos;
    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        Random_Number();
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Untagged");
    }
    private void Update()
    {
        foreach(GameObject g in gos)
        {
            if(g.transform.position == navMeshAgent.destination)
            {
                loc_reached = true;
            }
        }
        gameObject.transform.position = new Vector3(navMeshAgent.transform.position.x,1,navMeshAgent.transform.position.z);

        if(player_revealed)
        {
            GoToPlayerAtLastLocation();
            if(navMeshAgent.transform.position == player_info.playerRef.transform.position)
            {
                loc_reached = true;
            }
        }
        else if (gameObject.transform.position == fin_location || transform.position.x - fin_location.x >= -2.5 && transform.position.x - fin_location.x <= 0 || transform.position.x - fin_location.x <= 2.5 && transform.position.x - fin_location.x >= 0)
        {
            loc_reached = true;
        }
        if (!player_info.canSeePlayer)
        {
            ChaseXYZToNearPlayer();
            navMeshAgent.destination = fin_location;
            If_Reached();
            navMeshAgent.speed = 4;
        }
        else if(player_info.canSeePlayer)
        {
            Chase();
            navMeshAgent.speed = 5;
        }
        while (loc_reached)
        {
            Random_Number();
        }
        if(min_X>max_X)
        {
            ran_X = Random.Range(min_X, max_X);
        }
        else if(min_Z>max_Z)
        {
            ran_Z = Random.Range(min_Z, max_Z);
        }
    }
    //run towards player
    private void Chase()
    {
        navMeshAgent.destination = player_info.playerRef.transform.position;
        navMeshAgent.transform.LookAt(player_info.playerRef.transform);
    }
    //gets random vector value to move towards
    public void Random_Number()
    {
        ran_X = Random.Range(min_X, max_X);
        ran_Z = Random.Range(min_Z, max_Z);
        fin_location = new Vector3(ran_X,y_Value,ran_Z);
        print("new location: "+fin_location);
        loc_reached = false;

    }
    private void If_Reached()
    {

        if(transform.position == fin_location)
        {
            loc_reached = true;
        }

    }

    private void GoToPlayerAtLastLocation()
    {
        fin_location = characterPositionWhenInPianoRange.playerPosition();
        navMeshAgent.destination = fin_location;
        navMeshAgent.transform.LookAt(fin_location);
    }

    private void ChaseXYZToNearPlayer()
    {
        min_X = characterPositionWhenInPianoRange.playerPos.x;
        min_Z = characterPositionWhenInPianoRange.playerPos.z - 20;
        //print("min x: "+min_X + " min z: " + min_Z + " max x: " + max_X +" max z: "+ max_Z);
    }

}
