using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEditor.Callbacks;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UIElements;

public class PickUpItems : MonoBehaviour
{
    public GameObject player;
    GameObject[] items;
    public Transform holdPos;

    public float throwForce; //force at which the object is thrown at
    public float pickUpRange = 4f; //how far the player can pickup the object from
    private GameObject heldObj; //object which we pick up

    private Rigidbody heldObjRb; //rigidbody of object we pick up
    public bool holdingObj = false;
    private bool canDrop = true; //this is needed so we don't throw/drop object when rotating the object
    public FlashLightStateManager fLS;
    void Update()
    {
        items = GameObject.FindGameObjectsWithTag("items");//finds all items with tag items
        if (Input.GetKeyDown(KeyCode.E)) //change E to whichever key you want to press to pick up
        {
            if (heldObj == null) //if currently not holding anything
            {
                //perform raycast to check if player is looking at object within pickuprange
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickUpRange))
                {
                    //make sure pickup tag is attached
                    if (hit.transform.gameObject.tag == "items")
                    {
                        //pass in object hit into the PickUpObject function
                        PickUpObject(hit.transform.gameObject);
                        fLS.objectEquipped = hit.transform.gameObject.name;
                        holdingObj = true;
                    }
                }
            }
            else
            {
                if(canDrop == true)
                {
                    DropObject();
                    holdingObj = false;
                }
            }
        }
        if (heldObj != null) //if player is holding object
        {
            MoveObject(); //keep object position at holdPos
            if (Input.GetKeyDown(KeyCode.Q) && canDrop == true) //q is used to throw, change this if you want another button to be used)
            {
                ThrowObject();
                holdingObj = false;
            }

        }
    }
    void PickUpObject(GameObject pickUpObj)
    {
        if (pickUpObj.GetComponent<Rigidbody>()) //make sure the object has a RigidBody
        {
            heldObj = pickUpObj; //assign heldObj to the object that was hit by the raycast (no longer == null)
            heldObjRb = pickUpObj.GetComponent<Rigidbody>(); //assign Rigidbody
            heldObjRb.useGravity = false;
            heldObjRb.isKinematic = true;
            heldObjRb.transform.parent = holdPos.transform; //parent object to holdposition
            foreach(GameObject g in items)// goes through all items and makes sure the item equipped cant mess with them otherwise it tweaks
            {
                Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), g.GetComponent<Collider>(), true);
            }
            Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), true);
        }
    }
    void DropObject()
    {
        //re-enable collision with player
        Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), false);
        foreach(GameObject g in items) // this cancels the effect on top
        {
            Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), g.GetComponent<Collider>(), false);
        }
        heldObjRb.isKinematic = false;
        heldObjRb.useGravity = true;
        heldObj.transform.parent = null; //unparent object
        heldObj = null; //undefine game object
    }
    void MoveObject()
    {
        heldObj.transform.position = holdPos.transform.position;
        heldObj.transform.rotation = holdPos.rotation;
    }
    void ThrowObject()
    {
        //same as drop function, but add force to object before undefining it
        Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), false);
        foreach(GameObject g in items)
        {
            Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), g.GetComponent<Collider>(), false);
        }
        heldObjRb.isKinematic = false;
        heldObjRb.useGravity = true;
        heldObj.transform.parent = null;
        heldObjRb.AddForce(transform.forward / (heldObjRb.mass) * throwForce);
        heldObj = null;
    }
}
