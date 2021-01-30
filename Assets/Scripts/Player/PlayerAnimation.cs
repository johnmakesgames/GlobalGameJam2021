using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField]
    public Animator playerAnimator;
    public PlayerMovement playerMovement;
    public PlayerAnimationState CurrentAnimationState;


    public enum PlayerAnimationState { Idle, Walking, Running, Shaking, Digging, Jumping, Falling, Attacking, Sniffing, WaggingTail, Sleeping, Petting, Dead }
    private ParticleSystem sniffParticles;
    private PlayerAnimationState PreviousState;

    // Start is called before the first frame update
    void Start()
    {
        //sniffParticles = GetComponent<ParticleSystem>();
        sniffParticles = GetComponentInChildren<ParticleSystem>();
        sniffParticles.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        CurrentAnimationState = playerMovement.CurrentState;

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
                Sniff();
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

           // Debug.Log(CurrentAnimationState);

            PreviousState = CurrentAnimationState;
        }
    }

    void Sniff() //sniff Particles
    {
        Debug.Log(playerMovement.DirectionToDigZone);
        //Debug.Log(sniffParticles.shape.rotation);

        if (playerMovement.DirectionToDigZone != Vector3.zero)
        {

            //set direction of sniff particles
            GameObject.Find("SniffParticles").GetComponent<Transform>().rotation = (Quaternion.Euler(playerMovement.DirectionToDigZone));
            //sniffParticles.shape.rotation.Set(playerMovement.DirectionToDigZone.x, playerMovement.DirectionToDigZone.y, playerMovement.DirectionToDigZone.z);
            
            //Sniff
            if (sniffParticles.isStopped)
                sniffParticles.Play();
        }

        

        //Debug.Log(playerMovement.DirectionToDigZone);
        

    }

    void ResetAnimationTrigger()
    {
        if (sniffParticles.isPlaying)
            sniffParticles.Stop();

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
