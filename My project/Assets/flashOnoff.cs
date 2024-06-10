using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashOnoff : MonoBehaviour
{
    public FlashLightState fls;
    Light light;
    public bool flashOnOff = false; 
    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light>();
        light.enabled = !light.enabled;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            if(flashOnOff == true)
            {
                fls.currentBattery--;
            }
            light.enabled = !light.enabled;
            flashOnOff = !flashOnOff;
        }
    }
}
