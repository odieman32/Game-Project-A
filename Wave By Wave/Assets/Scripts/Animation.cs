using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    Animator animator;
    int isWalkingHash;
    int isJumpingHash;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("IsWalking");
        isJumpingHash = Animator.StringToHash("IsJumping");
    }

    // Update is called once per frame
    void Update()
    {
        bool isWalking = animator.GetBool(isWalkingHash);
        bool isJumping = animator.GetBool(isJumpingHash);

        // Check for any movement input (W, A, S, D)
        bool forwardPress = Input.GetKey(KeyCode.W);
        bool backwardPress = Input.GetKey(KeyCode.S);
        bool leftPress = Input.GetKey(KeyCode.A);
        bool rightPress = Input.GetKey(KeyCode.D);

        // Check if any movement key is pressed
        bool movementPress = forwardPress || backwardPress || leftPress || rightPress;

        // Check for jump input
        bool spaceJump = Input.GetKey(KeyCode.Space);

        // If player is not walking and presses a movement key
        if (!isWalking && movementPress)
        {
            animator.SetBool(isWalkingHash, true);
        }
        // If player is walking and stops pressing movement keys
        if (isWalking && !movementPress)
        {
            animator.SetBool(isWalkingHash, false);
        }

        // Jumping logic
        if (!isJumping && spaceJump)
        {
            animator.SetBool(isJumpingHash, true);
        }
        if (isJumping && !spaceJump)
        {
            animator.SetBool(isJumpingHash, false);
        }
    }
}
