using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoDetect : MonoBehaviour
{
    public float radius;
    [Range(0,360)]
    public float angle;

    public GameObject player;

    public LayerMask targetMask;

    public LayerMask obstructionMask;

    public bool aggro;

    
    // Start is called before the first frame update
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
            Debug.Log("Script activated");
        StartCoroutine(visibilityChecks());
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    private IEnumerator visibilityChecks()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.1f);
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
                
            }

        }
    }

}
