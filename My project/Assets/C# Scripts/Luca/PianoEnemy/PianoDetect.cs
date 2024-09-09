using System.Collections;
using UnityEngine;

public class PianoDetect : MonoBehaviour
{
    public GameObject player;

    public LayerMask targetMask;
    public LayerMask obstructionMask;
    
    public float noiseRadius;
    public float aggroRadius;
   
   [Range(0, 360)]
    public float angle;
   
    public bool aggro;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(VisibilityChecks());
    }

    IEnumerator VisibilityChecks()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.2f);
            InAudioRange();
            PianoAggro();
            InAggroRange();
        }
    }

    public bool InAudioRange() // This bool method is called in PianoAudio.cs, along with the next one
    {
        Collider[] objAudio = Physics.OverlapSphere(transform.position, noiseRadius, targetMask);

        if(objAudio.Length != 0)
        {
            //Debug.Log("Player in range");
            return true;
        }
        else
        {
            //Debug.Log("Player not in range");
            return false;
        }
    }

     public bool InAggroRange()
    {
        if(aggro)
        {
            //Debug.Log("Aggro noise activated");
            return true;
        }
        else
        {
            //Debug.Log("Aggro noise deactivated");
            return false;
        }
    }

    void PianoAggro()
    {
        Collider[] objCollision = Physics.OverlapSphere(transform.position, aggroRadius, targetMask);

        if(objCollision.Length != 0)
        {
            Transform target = objCollision[0].transform;
            Vector3 targetDirection = (target.position - transform.position).normalized;

            if(Vector3.Angle(transform.forward, targetDirection) < angle / 2)
            {
                float targetDistance = Vector3.Distance(transform.position, target.position);

                if(!Physics.Raycast(transform.position, targetDirection, targetDistance, obstructionMask))
                {
                    aggro = true;
                }
                else
                {
                    aggro = false;
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