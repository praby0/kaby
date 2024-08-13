using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class FlashLightStateManager : MonoBehaviour
{
    public string objectEquipped;
    public float batteryOnStart = 100f;
    public float currentBattery;

    public float startAmountToMax = 0.0f;
    public float maxAmoutToBeReached = 4.0f;
    bool disableLight = false;
    public Light lightToShow;
    public Light lightForFlash;
    public float percentOfBatteryToBeDecreased = 1.0f; 
    public float percentDecreasedPerTick = 0.00001f;
    public PickUpItems pickUp;
    // Start is called before the first frame update
    void Start()
    {
        currentBattery = batteryOnStart;
        lightToShow.enabled = false;
        lightForFlash.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        currentBattery -= percentDecreasedPerTick;
        if(Input.GetKeyDown(KeyCode.F) && disableLight == false && pickUp.equipped == true && objectEquipped =="flashlight")
        {
            lightToShow.enabled = !lightToShow.enabled;
            lightForFlash.enabled = !lightForFlash.enabled;
            if(lightToShow.enabled == true || lightForFlash.enabled == true) 
            {
                currentBattery--;                
            }
        }
        if(lightToShow.enabled == true && disableLight == false)
        {
            startAmountToMax += Time.deltaTime;
            if(startAmountToMax > maxAmoutToBeReached)
            {
                currentBatteryToBeDecreased(currentBattery);
                startAmountToMax = 0.0f;
            }
        }

    }

    private void currentBatteryToBeDecreased(float amount)
    {
        if(amount > 0)
        {
            currentBattery -= percentOfBatteryToBeDecreased;
            if (amount <= 80)
            {
                maxAmoutToBeReached = 3.0f;
            }
            if(amount <=  50)
            {
                maxAmoutToBeReached = 2.0f;
            }
            if(amount <= 10)
            {
                maxAmoutToBeReached = 1.0f;
                lightToShow.intensity = (float) lightToShow.intensity - .25f;
                lightToShow.range = (float) lightToShow.range - 0.5f;
            }
            
        }
        else
        {
            disableLight = true;
            lightToShow.enabled = false;
            lightForFlash.enabled = false;
        }

    }

}
