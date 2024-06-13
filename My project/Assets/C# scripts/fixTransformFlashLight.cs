using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fixTransformFlashLight : MonoBehaviour
{
    public float posBeforeX;
    public float posBeforeY;
    public float posBeforeZ;
    public PickUpItems pickUpItems;
    // Start is called before the first frame update
    void Start()
    {
        posBeforeX = transform.position.x;
        posBeforeY = transform.position.y;
        posBeforeZ = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y > 0 && transform.position.y < 2)
        {
            posBeforeX = transform.position.x;
            posBeforeY = transform.position.y;
            posBeforeZ = transform.position.z;
            
        }
        while(transform.position.y < 0)
        {
            transform.position = new Vector3(posBeforeX,posBeforeY+.1f,posBeforeZ);
            Debug.Log("I saved ur ass boi");
        }
    }
}
