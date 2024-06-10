using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashOnoff : MonoBehaviour
{
    public FlashLightState fls;
    Light light; // this is to access the light in unity
    public bool flashOnOff = false; 
    bool alwaysTurnOff = false;
    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light>(); //gets the light Component
        light.enabled = !light.enabled; //disables light at start/ 1st frame
    }

    // Update is called once per frame
    void Update() 
    {
        if(fls.currentBattery <= 0) //checks if the current battery from FlashLightState is 0 or less
        {
            fls.currentBattery = 0; //sets current battery back to 0
            fls.maxTimeTillBatteryDecrease = 0f; // changes the maxTimeTillBatteryDecrease to 0
            alwaysTurnOff = true; //a bool alwaysTurnOff if there is no battery
            if(light.enabled == true)
            {
                light.enabled = false;//if the light is still on and battery is at 0% then it will turn it off.
            }
        }
        if(Input.GetKeyDown(KeyCode.F) && alwaysTurnOff == false) //if you press F and alwaysTurnOff is false then it will work
        {
            if(flashOnOff == true) // this will make currentBattery decrease by 1 if user tries to spam on and off
            {
                fls.currentBattery--;
            }
            light.enabled = !light.enabled; // it will put the state of the light to the opposite each time both things are true;
            flashOnOff = !flashOnOff; // bool which keeps track of the state of the light.
        }
    }
}
