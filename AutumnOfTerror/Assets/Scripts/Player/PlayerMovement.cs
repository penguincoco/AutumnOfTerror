using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//usage: put this on a cube with a Rigidbody
//intent: control all aspects of player movement including: directional movement, jumping, picking up items 

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    //variables to handle player movement
    Rigidbody rigidBody;
    Vector3 input;
    bool isGrounded;
    public float jumpForce;

    private float speed;

    //public AudioSource footstepPlayer;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();

        speed = 5f;
    }

    void Update()
    {
        //handle basic player movement with WASD/arrow keys 
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        input = horizontal * transform.right;
        input += vertical * transform.forward;
    }

    void FixedUpdate()
    {
        rigidBody.velocity = new Vector3(input.x * speed, rigidBody.velocity.y, input.z * speed);
    }
}