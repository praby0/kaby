using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class PickUpItems : MonoBehaviour
{
    public GameObject player;
    FirstPersonController firstPersonController;
    GameObject[] items;
    GameObject[] playerMass;
    public Transform holdPos;
    public Transform gunHoldPos;
    public addingBattery addingBattery;
    public handGunAnimationController handGunAnim;

    private float PlayerWeight;

    public float throwForce; //force at which the object is thrown at
    public float pickUpRange = 4f; //how far the player can pickup the object from
    private GameObject heldObj; //object which we pick up

    private Rigidbody heldObjRb; //rigidbody of object we pick up
    public bool holdingObj = false;
    private bool canDrop = true; //this is needed so we don't throw/drop object when rotating the object
    public bool Drop = false;
    public bool holdingGun = false;
    public FlashLightStateManager fLS;
    void Start()
    {
        playerMass = GameObject.FindGameObjectsWithTag("Player");
        PlayerWeight = playerMass[0].GetComponent<Rigidbody>().mass;
        print("Player Weight: " + PlayerWeight);
        firstPersonController = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();
    }
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
            if(pickUpObj.name == "Fake_Gun")
            {
                handGunAnim.gameObject.SetActive(true);
                Destroy(pickUpObj);
            }
            else
            {
                handGunAnim.gameObject.SetActive(false);
                PlayerWeight = pickUpObj.GetComponent<Rigidbody>().mass + PlayerWeight;
                if (pickUpObj.GetComponent<Rigidbody>().mass > 1 && pickUpObj.GetComponent<Rigidbody>().mass < 6)
                {
                    firstPersonController.walkSpeed = (firstPersonController.walkSpeed / PlayerWeight) + playerMass[0].GetComponent<Rigidbody>().mass;
                    firstPersonController.sprintSpeed = (firstPersonController.sprintSpeed / PlayerWeight) + playerMass[0].GetComponent<Rigidbody>().mass;
                    print("walk speed(after): " + firstPersonController.walkSpeed);
                    print("run speed(after): " + firstPersonController.sprintSpeed);
                }
                else if (pickUpObj.GetComponent<Rigidbody>().mass >= 6)
                {
                    firstPersonController.walkSpeed = (firstPersonController.walkSpeed / PlayerWeight) + playerMass[0].GetComponent<Rigidbody>().mass - 2;
                    firstPersonController.sprintSpeed = (firstPersonController.sprintSpeed / PlayerWeight) + playerMass[0].GetComponent<Rigidbody>().mass - 2;
                    print("walk speed(after): " + firstPersonController.walkSpeed);
                    print("run speed(after): " + firstPersonController.sprintSpeed);
                }
                else
                {
                    firstPersonController.walkSpeed = firstPersonController.walkSpeed / PlayerWeight;
                    firstPersonController.sprintSpeed = firstPersonController.sprintSpeed / PlayerWeight;
                    print("walk speed(after): " + firstPersonController.walkSpeed);
                    print("run speed(after): " + firstPersonController.sprintSpeed);
                }
                print("Objects mass: " + pickUpObj.GetComponent<Rigidbody>().mass + " players mass(with Object): " + PlayerWeight);
                heldObj = pickUpObj; //assign heldObj to the object that was hit by the raycast (no longer == null)
                heldObjRb = pickUpObj.GetComponent<Rigidbody>(); //assign Rigidbody
                heldObjRb.useGravity = false;
                heldObjRb.isKinematic = true;
                heldObjRb.transform.parent = holdPos.transform; //parent object to holdposition
                foreach (GameObject g in items)// goes through all items and makes sure the item equipped cant mess with them otherwise it tweaks
                {
                    Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), g.GetComponent<Collider>(), true);
                }
                Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), true);
            }
        }
    }
    public void DropObject()
    {
        handGunAnim.gameObject.SetActive(false);
        holdingGun = false;
        PlayerWeight -= heldObjRb.mass;
        firstPersonController.walkSpeed = 5;
        firstPersonController.sprintSpeed =7;
        addingBattery.batteryEquipped = false;
        fLS.objectEquipped = "";
        fLS.flashlightBatteryManagerGUI.SetActive(false);
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
        if(heldObj.gameObject.name == "Pistol_D")
        {
            holdingGun = true;
        }
        else
        {
            holdingGun = false;
            heldObj.transform.position = holdPos.transform.position;
            heldObj.transform.rotation = holdPos.rotation;
        }
    }
    void ThrowObject()
    {
        handGunAnim.gameObject.SetActive(false);
        holdingGun = false;
        PlayerWeight -= heldObjRb.mass;
        firstPersonController.walkSpeed = 5;
        firstPersonController.sprintSpeed =7;
        addingBattery.batteryEquipped = false;
        fLS.objectEquipped = "";
        fLS.flashlightBatteryManagerGUI.SetActive(false);
        //same as drop function, but add force to object before undefining it
        Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), false);
        foreach(GameObject g in items)
        {
            Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), g.GetComponent<Collider>(), false);
        }
        heldObjRb.isKinematic = false;
        heldObjRb.useGravity = true;
        heldObj.transform.parent = null;
        if(heldObjRb.mass > 3)
        {
            heldObjRb.AddForce(transform.forward / (heldObjRb.mass*0.094f) * throwForce);
        }
        else
        {
            heldObjRb.AddForce(transform.forward / (heldObjRb.mass) * throwForce);
        }
        heldObj = null;
    }
}
