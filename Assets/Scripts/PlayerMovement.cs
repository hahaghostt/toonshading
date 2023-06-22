using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;
    public float rotationSpeed; 
    public float rotation = 0.0f; 

    Rigidbody rigidBody;
/* 
    public Transform self;
    public float turn_speed = 1f;
    */ 
 
    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }
 
    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); 
        float verticalInput=Input.GetAxis("Vertical"); 

        if (DialogueManager.isActive == true) 
           return; 

        //rotation = rotation - Input.GetAxis("Vertical") * rotationSpeed;
        //transform.rotation = Quaternion.Euler(new Vector3(0.0f, rotation, 0.0f));

        /*
        Vector3 targetDirection = new Vector3(self.position.x + inputH, self.position.y, self.position.z + inputV);
        float singleStep = speed * Time.deltaTime;

        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

        self.rotation = Quaternion.LookRotation(newDirection);
        */ 

        /* 
        player_Direction = transform.rotation * new Vector3(player_Horizontal, 0.0f, player_Vertical);
        */ 

        // Calculates the direction the player is moving 
        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput); 
        movementDirection.Normalize(); 
        transform.Translate(movementDirection * speed * Time.deltaTime, Space.World); 

        if (movementDirection != Vector3.zero) 
        {
        // Direction of where the player looks the character will rotation 
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up); 
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime); 
        }

        
    }
}