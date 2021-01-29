using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField]
    public Animator playerAnimator;
    public PlayerAnimationState CurrentAnimationState;

    public enum PlayerAnimationState { Idle, Walking, Running, Shaking, Digging, Jumping, Falling, Attacking, Sniffing, WaggingTail, Sleeping, Petting, Dead }
   
    private PlayerAnimationState PreviousState;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(CurrentAnimationState != PreviousState)
        {
            ResetAnimationTrigger();

            ///     Movement Based States

            // if moving under this speed
            if(CurrentAnimationState == PlayerAnimationState.Walking)
            {
                playerAnimator.SetTrigger("Walking");
            }
            else if(CurrentAnimationState == PlayerAnimationState.Running) // Not Currently
            {
                playerAnimator.SetTrigger("Running");
            }
            else if(CurrentAnimationState == PlayerAnimationState.Idle) // if not moving
            {
                playerAnimator.SetTrigger("Idle");
            }

            // if no input recieved in a min
            if (CurrentAnimationState == PlayerAnimationState.Sleeping)
                playerAnimator.SetTrigger("Sleeping");


            ///     Action Based States

            if (CurrentAnimationState == PlayerAnimationState.Jumping)
            {
                //if playerVelocity.y > 0
                playerAnimator.SetTrigger("Jumping");
            }
            else if (CurrentAnimationState == PlayerAnimationState.Falling)
            {
                //if playerVelocity.y < 0
                playerAnimator.SetTrigger("Falling");
            }


            // Context Based for Actions 
            // Attacking, Sniffing, WaggingTail, Petting, Shaking, Digging
            // use whatevere you are holding, Interact 

            if (CurrentAnimationState == PlayerAnimationState.Attacking)
            {
                playerAnimator.SetTrigger("Attacking");
            }

            if (CurrentAnimationState == PlayerAnimationState.Sniffing)
            {
                playerAnimator.SetTrigger("Sniffing");
            }

            if (CurrentAnimationState == PlayerAnimationState.WaggingTail)
            {
                playerAnimator.SetTrigger("WaggingTail");
            }

            if (CurrentAnimationState == PlayerAnimationState.Petting)
            {
                playerAnimator.SetTrigger("Petting");
            }

            if(CurrentAnimationState == PlayerAnimationState.Shaking)
            {
                playerAnimator.SetTrigger("Shaking");
            }

            if(CurrentAnimationState == PlayerAnimationState.Digging)
            {
                playerAnimator.SetTrigger("Digging"); // Change this animation
            }

            if(CurrentAnimationState == PlayerAnimationState.Dead)
            {
                playerAnimator.SetTrigger("Dead");
            }

            PreviousState = CurrentAnimationState;
        }
    }

    void ResetAnimationTrigger()
    {
        switch (PreviousState)
        {
            case PlayerAnimationState.Walking:
                playerAnimator.ResetTrigger("Walking");
                break;

            case PlayerAnimationState.Running:
                playerAnimator.ResetTrigger("Running");
                break;

            case PlayerAnimationState.Jumping:
                playerAnimator.ResetTrigger("Jumping");
                break;

            case PlayerAnimationState.Falling:
                playerAnimator.ResetTrigger("Falling");
                break;

            case PlayerAnimationState.Idle:
                playerAnimator.ResetTrigger("Idle");
                break;

            case PlayerAnimationState.Digging:
                playerAnimator.ResetTrigger("Digging");
                break;

            case PlayerAnimationState.Attacking:
                playerAnimator.ResetTrigger("Attacking");
                break;

            case PlayerAnimationState.Petting:
                playerAnimator.ResetTrigger("Petting");
                break;

            case PlayerAnimationState.Shaking:
                playerAnimator.ResetTrigger("Shaking");
                break;

            case PlayerAnimationState.Sleeping:
                playerAnimator.ResetTrigger("Sleeping");
                break;

            case PlayerAnimationState.Sniffing:
                playerAnimator.ResetTrigger("Sniffing");
                break;

            case PlayerAnimationState.WaggingTail:
                playerAnimator.ResetTrigger("WaggingTail");
                break;
        }
    }
    }
