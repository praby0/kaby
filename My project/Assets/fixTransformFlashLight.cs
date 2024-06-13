using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fixTransformFlashLight : MonoBehaviour
{
    Vector3 posBefore;
    // Start is called before the first frame update
    void Start()
    {
        posBefore = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < 0)
        {
            transform.position = posBefore;
        }
    }
}
