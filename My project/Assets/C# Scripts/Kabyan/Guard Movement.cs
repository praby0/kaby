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

    private bool loc_reached = true;
    public bool player_revealed = false;

    private float ran_X;
    private float ran_Z;
    private NavMeshAgent navMeshAgent;
    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        Random_Number();
    }
    private void Update()
    {
        if(loc_reached == false)
        {
            //navMeshAgent.destination = fin_location;
        }
        if(player_revealed)
        {
            GoToPlayerAtLastLocation();
        }
        if(!player_info.canSeePlayer)
        {
            ChaseXYZToNearPlayer();
            Patrol(); //let him be if not
            If_Reached();
        }
        else if(player_info.canSeePlayer)
        {
            Chase();
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

    //movement when player not spotted
    private void Patrol()
    {
        transform.position = Vector3.MoveTowards(transform.position, fin_location, speed * Time.deltaTime); //move towards the random value with (speed) velocity
        transform.LookAt(fin_location);
    }
    //run towards player
    private void Chase()
    {
        transform.position = Vector3.MoveTowards(transform.position, player_info.playerRef.transform.position, speed * Time.deltaTime);
        transform.LookAt(player_info.playerRef.transform);
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
        transform.position = Vector3.MoveTowards(transform.position, fin_location, speed * Time.deltaTime);
        transform.LookAt(fin_location);
        If_Reached();
    }

    private void ChaseXYZToNearPlayer()
    {
        min_X = characterPositionWhenInPianoRange.playerPos.x;
        min_Z = characterPositionWhenInPianoRange.playerPos.z;
        //print("min x: "+min_X + " min z: " + min_Z + " max x: " + max_X +" max z: "+ max_Z);
    }

}
