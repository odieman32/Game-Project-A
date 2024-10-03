using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCam : MonoBehaviour
{
    [Header("References")]
    public Transform orientation; //public field for orientation
    public Transform Player; //public field for the player
    public Transform PlayerMod; //public vield for the player model
    public Rigidbody rb; //public field for rigid body

    public float roatationSpeed; //roatation speed variable

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //cursor locked
        Cursor.visible = false; //cursor is not visable
    }

    void Update()
    {
        //rotate orientation
        Vector3 viewDir = Player.position - new Vector3(transform.position.x, Player.position.y, transform.position.z);
        orientation.forward = viewDir.normalized;

        //rotate player object
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 inputDir = orientation.forward * verticalInput + orientation.forward * horizontalInput;

        if (inputDir != Vector3.zero)
            PlayerMod.forward = Vector3.Slerp(PlayerMod.forward, inputDir.normalized, Time.deltaTime * roatationSpeed);
    }
}
