using System.Collections;
using System.Collections.Generic;
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

    private bool loc_reached = true;


    private void Update()
    {
        if(!player_info.canSeePlayer)
        {
            StartCoroutine(Patrol()); //let him be if not
            If_Reached();
        }
        else if(player_info.canSeePlayer)
        {
            Chase();
            If_Reached();
        }
        while(loc_reached)
        {
            Random_Number();
        }

    }

    //movement when player not spotted
    private IEnumerator Patrol()
    {
        transform.position = Vector3.MoveTowards(transform.position, fin_location, speed * Time.deltaTime); //move towards the random value with (speed) velocity
        yield return new WaitForSecondsRealtime(2f);

    }
    //run towards player
    private void Chase()
    {
        transform.position = Vector3.MoveTowards(transform.position, player_info.playerRef.transform.position, speed * Time.deltaTime);
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


}
