using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI;
using UnityEditor.Search;
using UnityEngine.AI;

public class GuardCode : MonoBehaviour
{
    
    [SerializeField]
    Vector3 fin_Location;
    [SerializeField]
    LayerMask groundlayer, playerlayer;
    public NavMeshAgent agent;




    void start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        
        //check if agent has reached final location
        //if true gets new location


    }
}
