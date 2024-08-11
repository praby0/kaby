using System.Collections;
using UnityEngine;

public class PianoDetect : MonoBehaviour
{
    public GameObject player;

    public LayerMask targetMask;

    public LayerMask obstructionMask;
    public float radius;
    [Range(0,360)]
   
    public float angle;
   
    public bool aggro;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
            Debug.Log("Script activated");
        StartCoroutine(visibilityChecks());
    }
    private IEnumerator visibilityChecks()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.5f);
            playerVisibility();
        }
    }

    void playerVisibility()
    {
        Collider[] objCollision = Physics.OverlapSphere(transform.position, radius, targetMask);

        if(objCollision.Length != 0)
        {
            Transform target = objCollision[0].transform;
            Vector3 targetDirection = (target.position - transform.position).normalized;

            if(Vector3.Angle(transform.forward, targetDirection) < angle / 2)
            {
                float targetDistance = Vector3.Distance(transform.position, target.position);

                if(Physics.Raycast(transform.position, targetDirection, targetDistance, obstructionMask))
                {
                    aggro = false;
                }
                else
                {
                    aggro = true;
                }
            }
            else
            {
                aggro = false;
            }
        }
        else if(aggro)
        {
            aggro = false;
        }
    }
}
