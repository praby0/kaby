using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraClass : MonoBehaviour
{
    public bool player_spotted;
    public bool player_leave;
    public Vector3 Last_locaiton;
    public LayerMask targetMask;
    public float radius;
    public GameObject cameralight;
    public GameObject player;

    //sets variables false to not mess with guard ai
    void Start()
    {
        player_spotted = false;
        player_leave = false;
        
    }

    //runs spot check constantly
    void Update()
    {
        playerSpotCheck();
    }

    //updates if player in circle or recently left
    void playerSpotCheck()
    {
        bool is_player_in = CheckOverLap();

        if(is_player_in)
        {
            player_spotted = true;
            player_leave = true;
        }
        else if(!is_player_in && player_spotted)
        {
            Last_locaiton = player.transform.position;
            player_spotted = false;
        }
        else
        {
            player_spotted = false;
        }


    }

    //checks if player is inside radius (radius will be shown through editor script)
    bool CheckOverLap()
    {
        Collider[] cameracheck = Physics.OverlapSphere(cameralight.transform.position, radius, targetMask);

        if(cameracheck.Length != 1)
        {
            return true;
        }
        return false;   
    }

}
