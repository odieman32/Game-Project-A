using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed; //float for movement speed

    public float groundDrag; //float to set ground drag

    public float jumpForce; //float to set jump force
    public float jumpCooldown; // float sets jump cool down
    public float airMultiplier; //float sets air multiplier
    bool readyToJump = true; //bool to say if player is ready to jump

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space; //jump key set to space

    [Header("Ground Check")]
    public float playerHeight; //float for player height
    public LayerMask whatIsGround; //layer mask for the ground
    bool grounded; //bool to tell if player is grounded

    public Transform orientation; //transform for orientation

    float horizontalInput; //horizontal input variable
    float verticalInput; //vertical input variable

    Vector3 moveDirection; //vertor for moving direction

    Rigidbody rb; //player rigid body variable

    private void Start()
    {
        rb = GetComponent<Rigidbody>(); //gets player rigidbody
        rb.freezeRotation = true;
    }

    private void Update()
    {
        //send a raycast to check if the player is on the ground
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);
        MyInput(); //calls my input function
        SpeedControl(); //call speed control functions

        //if statement to handle drag
        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;
    }


    private void FixedUpdate()
    {
        //fixed update calls move player function
        MovePlayer();
    }

    private void MyInput()
    {
        //variables for the horizontal and vertical input
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        //if statement to control when to jump
        if(Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    private void MovePlayer()
    {
        //calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        //on ground
        if (grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

        //in air
        else if(!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatvel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        
        //limit velocity if needed
        if (flatvel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatvel.normalized * moveSpeed; //calculates max velocity if faster than set move speed
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z); //applies max velocity
        }
    }

    private void Jump()
    {
        //reset y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        //resets jump to true
        readyToJump = true;
    }
}
