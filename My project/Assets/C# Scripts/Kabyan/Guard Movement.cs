using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

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

    private bool loc_reached = true;
    public bool player_revealed = false;


    private void Update()
    {
        if(!player_info.canSeePlayer && !player_last_location_reavealed())
        {
            Patrol(); //let him be if not
            If_Reached();
        }
        else if(player_info.canSeePlayer)
        {
            Chase();
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position,goToPlayerLocation(player_last_location_reavealed()),speed*Time.deltaTime);
            transform.LookAt(goToPlayerLocation(player_last_location_reavealed()));
        }
        while(loc_reached)
        {
            Random_Number();
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
    private void Random_Number()
    {

        float ran_X = Random.Range(min_X, max_X);
        float ran_Z = Random.Range(min_Z, max_Z);
        fin_location = new Vector3(ran_X,y_Value,ran_Z);
        loc_reached = false;

    }
    private void If_Reached()
    {

        if(transform.position == fin_location)
        {
            loc_reached = true;
        }

    }

    private bool player_last_location_reavealed()
    {
        if(!player_revealed)
        {
            return false;
        }
        return true;
    }

    private Vector3 goToPlayerLocation(bool found)
    {
        float ran_X = Random.Range(min_X, max_X);
        float ran_Z = Random.Range(min_Z, max_Z);
        if(found)
        {
            return characterPositionWhenInPianoRange.playerPosition(); 
        }
        return new Vector3(ran_X,y_Value,ran_Z);
    }

}
