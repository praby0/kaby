using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.UIElements;

public class PickUpItems : MonoBehaviour
{
    public bool equipped;
    public static bool slotFull;

    public GameObject[] goi;
    public Vector3 diffFromPlayerToObject;
    void Start()
    {
        goi = GameObject.FindGameObjectsWithTag("items");
        
    }

    // Update is called once per frame
    private void Update()
    {
        foreach (GameObject g in goi)
        {
            if(g != null)
            {
                diffFromPlayerToObject = g.transform.position - transform.position;
                float currdiff = diffFromPlayerToObject.sqrMagnitude;
                if(!equipped && currdiff < 2 && Input.GetKeyDown(KeyCode.E) && !slotFull)
                {
                    pickUp(g);
                    print("pick-up");
                }
                if(equipped && Input.GetKeyDown(KeyCode.Q))
                {
                    drop(g);
                    print("drop");
                }
            }
        }
    }

    private void pickUp(GameObject a)
    {
        equipped = true;
        slotFull = true;

    }
    private void drop(GameObject a)
    {
        equipped = false;
        slotFull = false;

    }
}
