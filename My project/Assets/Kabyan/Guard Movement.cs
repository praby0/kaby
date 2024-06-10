using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class GuardMovement : MonoBehaviour
{
    public POV player_info;
    public float min_X;
    public float max_X;
    public float min_Z;
    public float max_Z;
    public float y_Value;
    public float speed;

    private void Update()
    {
        while(player_info.canSeePlayer)
        {
            Chase(); //chase player if spotted
        }
        while(!player_info.canSeePlayer)
        {
            StartCoroutine(Patrol()); //let him be if not
        }
    }

    //movement when player not spotted
    private IEnumerator Patrol()
    {
        WaitForSeconds wait = new WaitForSeconds(2f);

        while(true)
        {
        transform.position = Vector3.MoveTowards(transform.position, Random_Number(), speed * Time.deltaTime); //move towards the random value with (speed) velocity
        yield return wait; //this allows the guard to travel a bit until new location is determined
        }
    }
    //run towards player
    private void Chase()
    {
        StartCoroutine(Chill());
        transform.position = Vector3.MoveTowards(transform.position, player_info.playerRef.transform.position, speed * Time.deltaTime);
    }
    //gets random vector value to move towards
    private Vector3 Random_Number()
    {

        float ran_X = Random.Range(min_X, max_X);
        float ran_Z = Random.Range(min_Z, max_Z);
        return new Vector3(ran_X,y_Value,ran_Z);

    }
    //just waits for whatever value of wait it is(in case code runs slow)
    private IEnumerator Chill()
    {
        WaitForSeconds wait = new WaitForSeconds(.2f);
        yield return wait;
    }


}
