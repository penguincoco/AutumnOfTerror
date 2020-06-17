using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PickupableItem : MonoBehaviour
{

    private Rigidbody rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            rigidBody.constraints = RigidbodyConstraints.FreezeRotationX;
            rigidBody.constraints = RigidbodyConstraints.FreezeRotationY;
            rigidBody.constraints = RigidbodyConstraints.FreezeRotationZ;
            rigidBody.constraints = RigidbodyConstraints.FreezePosition; 
        }
        
    }
}
