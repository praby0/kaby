using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightOn : MonoBehaviour
{
    public Light light;
    public flashOnoff flashOnOf;
    // Start is called before the first frame update
    void Start()
    {
        light.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(flashOnOf.flashOnOff == true)
        {
            light.enabled = true;
        }
        else if(!flashOnOf.flashOnOff == true)
        {
            light.enabled = false;
        }
    }
}
