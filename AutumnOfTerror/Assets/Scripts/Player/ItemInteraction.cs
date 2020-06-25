using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteraction : MonoBehaviour
{
    private bool canPickup = false;
    private GameObject holdingObject;
    public Transform destination;
    
    void Start()
    {
        //destination = this.gameObject.transform.GetChild(1);
    }

    // Update is called once per frame
    void Update()
    {
        CheckForObject();
    }

    //check if player is within range of an item that can be picked up 
    void CheckForObject()
    {
        Ray myRay = new Ray(transform.position, transform.forward);
        float rayDistance = 8f;

        Debug.DrawRay(myRay.origin, myRay.direction * rayDistance, Color.blue);

        RaycastHit rayHit = new RaycastHit();
        GameObject item = null;

        if (Physics.SphereCast(myRay, 0.5f, out rayHit, rayDistance))
        {
            //if it hits then you can pick up the item
            if (rayHit.collider.gameObject.tag == "Pickupable Item")
            {
                Debug.Log("Encountering an item that can be picked up");
                item = rayHit.collider.gameObject;
                canPickup = true;
            }
        }
        else
        {
            canPickup = false;
        }

        if (canPickup && holdingObject == null && Input.GetKeyDown(KeyCode.E) && item != null)
        {
            Pickup(item);
        }
        else if (holdingObject != null && Input.GetKeyDown(KeyCode.E))
        {
            Drop(holdingObject);
        }
    }

    void Pickup(GameObject item)
    {
        holdingObject = item;
        Debug.Log(item.name);
        item.GetComponent<Rigidbody>().useGravity = false;
        item.GetComponent<Rigidbody>().isKinematic = true;

        item.GetComponent<BoxCollider>().enabled = false;

        destination.GetComponent<BoxCollider>().enabled = true;

        item.transform.position = destination.position;

        item.transform.parent = destination.gameObject.transform;
    }

    public void Drop(GameObject item)
    {
        item.GetComponent<Rigidbody>().useGravity = true;
        item.GetComponent<Rigidbody>().isKinematic = false;

        item.GetComponent<BoxCollider>().enabled = true;

        destination.GetComponent<BoxCollider>().enabled = false;
        item.transform.parent = null;           //unparent player
        holdingObject = null;                   //set holding to empty
    }
}
