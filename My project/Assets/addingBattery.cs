using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addingBattery : MonoBehaviour
{
    public FlashLightStateManager flashLightStateManager;
    public PickUpItems pickUpItems;
    public bool batteryEquipped = false;
    int batteryNumber;
    float batteryPercentAmount;
    float batteryEffectivness;

    private int maxBatteryPacksOnMap;

    // Start is called before the first frame update
    void Start()
    {
        maxBatteryPacksOnMap = Random.Range(1,4);
    }

    // Update is called once per frame
    void Update()
    {

        if(flashLightStateManager.objectEquipped == "Battery")
        {
            batteryNumber = Random.Range(2,4);
            batteryPercentAmount = Random.Range(25f,91f);
            batteryEffectivness = Random.Range(0.044f,0.094f);
            Debug.Log("Number of batteries: "+batteryNumber+" Battery Percentage: "+batteryPercentAmount+" battery Effectivness: "+batteryEffectivness);
            pickUpItems.DropObject();
            batteryEquipped = true;
            flashLightStateManager.addBattery(batteryEquipped,batteryNumber,batteryPercentAmount,batteryEffectivness);

        }
    }
}
