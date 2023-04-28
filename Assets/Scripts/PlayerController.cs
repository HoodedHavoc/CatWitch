using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Component Character Controller
    public CharacterController controller;

    // Declares movement speed, gravity intensity and jump height
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
   
    // groundCheck for the empty, groundDistance sets distance from CheckSphere to 'ground' layer
    // and LayerMask groundMask is the 'ground' layer
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    
    // velocity declares velocity for falling from height, isGrounded bool checks if object (player) is grounded or not
    Vector3 velocity;
    bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        // Creates a sphere on Empty GameObject that can detect position and distance from all objects in "Ground" layer
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // Calls bool to check velocity. If less than 0, make it -2
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // Gets input for moving on x (default 'w' and 's') and z (default 'a' and 'd')
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Multiply directions right and forward by x and z.
        // right=1 on x, left=-1 on x, forward=1 on z, backward=-1 on z
        Vector3 move = transform.right * x + transform.forward * z;

        // Gets input for jumping (default 'space')
        // Mathf.sqrt is a mthematical equation, calculating the jump height
        // the jump height (3 in this script) is multiplyed 
       if(Input.GetButton("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }
        
        // speed and velocity is based on fixed floats and not by framerate
        controller.Move(move * speed * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
