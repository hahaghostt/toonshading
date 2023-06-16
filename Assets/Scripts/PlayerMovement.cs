using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;
    public float rotationSpeed = 3; 
    public float rotation = 0.0f; 

    Rigidbody rigidBody;
 
    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }
 
    void FixedUpdate()
    {
        float inputH = Input.GetAxis("Horizontal");
        float inputV = Input.GetAxis("Vertical");
        rotation = rotation + Input.GetAxis("Vertical") * rotationSpeed;
        transform.rotation = Quaternion.Euler(new Vector3(0.0f, rotation, 0.0f));
        rigidBody.velocity = new Vector3(inputH * speed, rigidBody.velocity.y, inputV * speed);
        
    }
}