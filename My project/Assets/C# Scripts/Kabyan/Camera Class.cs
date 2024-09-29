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

    void Start()
    {
        player_spotted = false;
        player_leave = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        playerSpotCheck();
    }

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
