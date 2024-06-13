using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightBarController : MonoBehaviour
{
    public FlashLightStateManager baterie;

    public Slider slide;
    

    private void Update()
    {

        Set_Slider(baterie.currentBattery);

    }

    public void Set_Slider(float state)
    {
        slide.value = state;
    }


}
