using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// SINGLETON
/// Put this on the player to handle basic movement
/// </summary>

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    //PlayerMovement is a singleton. It can be accessed from anywhere in the scene via PlayerMovement.Instance.()
    private static PlayerMovement _instance;
    public static PlayerMovement Instance { get { return _instance; } }

    //variables to handle player movement
    private Rigidbody rigidBody;
    private Vector3 input;

    public float speed;

    void Awake()
    {
        //singleton pattern
        if (_instance != null && _instance != this)
            Destroy(this.gameObject);
        else
            _instance = this;
    }

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
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

    public void SetPosition(Vector3 newPos, Vector3 newRotation)
    {
        this.gameObject.transform.position = newPos;
        this.gameObject.transform.eulerAngles = newRotation;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Ramp")
        {
            speed = 14;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "Ramp")
        {
            speed = 7;
        }
    }
}