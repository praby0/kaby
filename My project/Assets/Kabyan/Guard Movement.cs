using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardMovement : MonoBehaviour
{
    private Vector3 ranPoint;
    public POV guardInfo;

    private void Update()
    {
        while(!guardInfo.canSeePlayer)
        {
            PatrolArea();
        }
        while(guardInfo.canSeePlayer)
        {
            ChasePlayer();
        }
    }

    private void ChasePlayer()
    {
        
    }

    private void PatrolArea()
    {
        
    }

    private Vector3 RanPoint()
    {
        float x_Val = Random.Range(0, 5);
        float z_Val = Random.Range(0,5);
        Vector3 vec = new Vector3(x_Val,0,z_Val);
        return vec;
    }

}
