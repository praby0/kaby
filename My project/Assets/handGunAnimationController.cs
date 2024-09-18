using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handGunAnimationController : MonoBehaviour
{
    public Animator anim;
    public FirstPersonController firstPersonController;
    // Start is called before the first frame update
    void Start()
    {
        anim.SetTrigger("idle");
    }

    // Update is called once per frame
    void Update()
    {
        if(firstPersonController.isWalking == true)
        {
            anim.SetBool("isRunning", false);
            anim.SetBool("isWalking",true);
            if(firstPersonController.isSprinting == true)
            {
                print("running");
                anim.SetBool("isWalking", false);
                anim.SetBool("isRunning", false);
            }
        }
        else
        {
            anim.SetBool("isWalking", false);
            anim.SetBool("isRunning", true);
            anim.SetTrigger("idle");
        }
    }
}
