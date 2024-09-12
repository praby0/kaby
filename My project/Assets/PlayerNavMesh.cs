using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class PlayerNavMesh : MonoBehaviour
{
    // Start is called before the first frame update
    public GuardMovements guardMovements;
    private NavMeshAgent navMeshAgent;
    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    public void Update()
    {
        navMeshAgent.destination = guardMovements.fin_location;
        gameObject.transform.position = new Vector3(navMeshAgent.transform.position.x,1,navMeshAgent.transform.position.z);
        print(navMeshAgent.destination);
        if(gameObject.transform.position == guardMovements.fin_location)
        {
            guardMovements.loc_reached = true;
        }
    }
}
