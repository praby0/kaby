using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightState : MonoBehaviour
{
    public float startingBattery = 100;
    public flashOnoff flash_on_off;
    public float currentBattery;
    public float timeTillBatteryDecrease = 0.0f;
    public float maxTimeTillBatteryDecrease = 5.0f;
    float decreaseperTick = 0.00001f;
    // Start is called before the first frame update
    void Start()
    {
        currentBattery = startingBattery;
    }

    // Update is called once per frame
    void Update()
    {
        currentBattery -= decreaseperTick;
        if(flash_on_off.flashOnOff == true) //flashlight is on
        {
            timeTillBatteryDecrease += Time.deltaTime; //if it is this will tick until its max capacity of time is reached
            if(timeTillBatteryDecrease > maxTimeTillBatteryDecrease)
            {
                BatteryPerTick(currentBattery); //it will go into the batteryPerTick func and it requires a float value to go inside it.
                timeTillBatteryDecrease = 0; //it will reset once the time is fully finished
            }
        }
    }
    private void BatteryPerTick(float currentB)
    {
        if(currentB > 80) // if the current Battery is greater than 80% it will just do current Battery - 1
        {
            currentBattery--;
        }
        else // if it is lower than the maxTime will be decreased to 2 seconds and current battery will still go -1 but it will happen faster.
        {
            maxTimeTillBatteryDecrease = 2.0f; //changes the maxTime to 2 seconds.
            currentBattery--;
        }
    }
}
