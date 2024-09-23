using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handGunAnimationController : MonoBehaviour
{
    public Animator anim;
    public FirstPersonController firstPersonController;
    public PickUpItems pickUpItems;
    public GameObject gameObject;
    public Transform gunPos;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (pickUpItems.holdingGun == true)
        {

            if (firstPersonController.isSprinting == true)
            {
                
                anim.SetBool("idle", false);
                anim.SetBool("isWalking", false);
                anim.SetBool("isRunning", true);

            }
            else if (firstPersonController.isWalking == true)
            {

                anim.SetBool("idle", false);
                anim.SetBool("isRunning", false);
                anim.SetBool("isWalking", true);

            }
            else
            { 

                anim.SetBool("isWalking", false);
                anim.SetBool("isRunning", false);
                transform.position = gunPos.transform.position;
                transform.rotation = gunPos.rotation;
                anim.SetBool("idle",true);

            }

        }
        else
        {

            anim.SetBool("isWalking", false);
            anim.SetBool("isRunning", false);

        }
    }
}