using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    public float PlayerSpeedModifier = 0.01f;
    public float jumpHeight = 0.5f;
    public Animator playerAnimator;

    private CharacterController playerController;
    private bool playerGrounded;
    private bool playerAnimating = false;
    private bool playerDig = false;
    private bool playerShake = false;
    private Vector3 playerVelocity;
    private enum AnimationState { Idle, Walking, Running, Shaking, Digging, Jumping, Attacking, Sniffing, WaggingTail, Sleeping, Petting, Falling, DefaultState }
    AnimationState CurrentState;
    AnimationState PreviousState;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<CharacterController>();
        CurrentState = AnimationState.Idle;
        PreviousState = AnimationState.DefaultState;
    }

    private void FixedUpdate()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerGrounded = playerController.isGrounded;
        if (playerGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")) * PlayerSpeedModifier;
        playerController.Move(move);

        if (move != Vector3.zero)
        {
            transform.forward = move;
            //base on speed, walking or running
            CurrentState = AnimationState.Walking;
            //playerAnimator.ResetTrigger("Idle");
            //playerAnimator.SetTrigger("Walking");
        }


        if (Input.GetKeyDown(KeyCode.Space) && playerGrounded)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -1.0f * -9.8f);
            CurrentState = AnimationState.Jumping;
        }

        playerVelocity.y += -9.8f * Time.deltaTime;

        //if (playerVelocity.y < 0.0f)
            //CurrentState = AnimationState.Falling;

        playerController.Move(playerVelocity);


        if(CurrentState != PreviousState)
        {
            switch (CurrentState)
            {
                case AnimationState.Walking:
                    playerAnimator.ResetTrigger("Idle");
                    playerAnimator.SetTrigger("Walking");
                    break;

                case AnimationState.Idle:
                    playerAnimator.ResetTrigger("Walking");
                    playerAnimator.SetTrigger("Idle");
                    break;

                case AnimationState.Jumping:
                    break;

                case AnimationState.Falling:
                    break;
            }
        }

        Debug.Log(CurrentState);

        PreviousState = CurrentState;

        // Action: Sniff, Shake, WagTail(maybe), (being)Pet , Attack, digging
        // Movement: Walk, Idle, Run(maybe),  Sleep(AFK)

        //if (CurrentState != PreviousState)
        //{
            
        //    switch (PreviousState)
        //    {
        //        case AnimationState.Walking:
        //            playerAnimator.ResetTrigger("Walking");
        //            break;

        //        case AnimationState.Running:
        //            playerAnimator.ResetTrigger("Running");
        //            break;

        //        case AnimationState.Jumping:
        //            playerAnimator.ResetTrigger("Jumping");
        //            break;

        //        case AnimationState.Falling:
        //            playerAnimator.ResetTrigger("Falling");
        //            break;

        //        case AnimationState.Idle:
        //            playerAnimator.ResetTrigger("Idle");
        //            break;

        //        case AnimationState.Digging:
        //            playerAnimator.ResetTrigger("Digging");
        //            break;

        //        case AnimationState.Attacking:
        //            playerAnimator.ResetTrigger("Attacking");
        //            break;

        //        case AnimationState.Petting:
        //            playerAnimator.ResetTrigger("Petting");
        //            break;

        //        case AnimationState.Shaking:
        //            playerAnimator.ResetTrigger("Shaking");
        //            break;

        //        case AnimationState.Sleeping:
        //            playerAnimator.ResetTrigger("Sleeping");
        //            break;

        //        case AnimationState.Sniffing:
        //            playerAnimator.ResetTrigger("Sniffing");
        //            break;

        //        case AnimationState.WaggingTail:
        //            playerAnimator.ResetTrigger("WaggingTail");
        //            break;
        //    }

        //    switch (CurrentState)
        //    {
        //        case AnimationState.Walking:
        //            playerAnimator.SetTrigger("Walking");
        //            break;

        //        case AnimationState.Running:
        //            playerAnimator.SetTrigger("Running");
        //            break;

        //        case AnimationState.Jumping:
        //            playerAnimator.SetTrigger("Jumping");
        //            break;

        //        case AnimationState.Falling:
        //            playerAnimator.SetTrigger("Falling");
        //            break;

        //        case AnimationState.Idle:
        //            playerAnimator.SetTrigger("Idle");
        //            break;

        //        case AnimationState.Digging:
        //            playerAnimator.SetTrigger("Digging");
        //            break;

        //        case AnimationState.Attacking:
        //            playerAnimator.SetTrigger("Attacking");
        //            break;

        //        case AnimationState.Petting:
        //            playerAnimator.SetTrigger("Petting");
        //            break;

        //        case AnimationState.Shaking:
        //            playerAnimator.SetTrigger("Shaking");
        //            break;

        //        case AnimationState.Sleeping:
        //            playerAnimator.SetTrigger("Sleeping");
        //            break;

        //        case AnimationState.Sniffing:
        //            playerAnimator.SetTrigger("Sniffing");
        //            break;

        //        case AnimationState.WaggingTail:
        //            playerAnimator.SetTrigger("WagginTail");
        //            break;
        //    }

        //}

        //PreviousState = CurrentState;

        //Action Based Animations

        //if (Input.GetKey(KeyCode.Alpha1)) //hold key down
        //{

        //    playerAnimator.SetTrigger("Shaking");
        //    CurrentState = AnimationState.Shaking;
        //}
        //else
        //{
        //    playerAnimator.ResetTrigger("Shaking");
        //}

        //if (Input.GetKey(KeyCode.Alpha2)) //hold key down
        //{
        //    playerAnimator.SetTrigger("Digging");
        //    CurrentState = AnimationState.Digging;
        //}
        //else
        //{
        //    playerAnimator.ResetTrigger("Digging");
        //}

        //if (Input.GetKey(KeyCode.Alpha3)) //hold key down
        //{
        //    playerAnimator.SetTrigger("Attacking");
        //    CurrentState = AnimationState.Attacking;
        //}
        //else
        //{
        //    playerAnimator.ResetTrigger("Attacking");
        //}

        //if (Input.GetKey(KeyCode.Alpha4)) //hold key down
        //{
        //    playerAnimator.SetTrigger("Sniffing");
        //    CurrentState = AnimationState.Sniffing;
        //}
        //else
        //{
        //    playerAnimator.ResetTrigger("Sniffing");
        //}

        //if (Input.GetKey(KeyCode.Alpha5)) //hold key down
        //{
        //    playerAnimator.SetTrigger("Petting");
        //    CurrentState = AnimationState.Petting;
        //}
        //else
        //{
        //    playerAnimator.ResetTrigger("Petting");
        //}

        //if (Input.GetKey(KeyCode.Alpha6)) //hold key down
        //{
        //    playerAnimator.SetTrigger("WaggingTail");
        //    CurrentState = AnimationState.WaggingTail;
        //}
        //else
        //{
        //    playerAnimator.ResetTrigger("WaggingTail");
        //}

    }
}
