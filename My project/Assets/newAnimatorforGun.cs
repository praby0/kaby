using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newAnimatorforGun : MonoBehaviour
{
    public Animator anim;
    public FirstPersonController firstPersonController;
    public PickUpItems pickUpItems;
    public GameObject gameObject;
    public Transform gunPos;
    // Start is called before the first frame update
    void Start()
    {
        anim.SetBool("isEquipped",false);
    }

    // Update is called once per frame
    void Update()
    {
        if (pickUpItems.holdingGun == true)
        {
            anim.SetBool("isEquipped",true);
        }


    }
}
