using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    public float PlayerSpeedModifier = 0.01f;
    public float jumpHeight = 0.5f;
    PlayerAnimation.PlayerAnimationState CurrentState;

    private CharacterController playerController;
    private bool playerGrounded;
    private bool playerAnimating = false;
    private bool playerDig = false;
    private bool playerShake = false;
    private Vector3 playerVelocity;
    

    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<CharacterController>();
        CurrentState = PlayerAnimation.PlayerAnimationState.Idle;
    }

    private void FixedUpdate()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerGrounded = playerController.isGrounded;

        if (playerGrounded)
            CurrentState = PlayerAnimation.PlayerAnimationState.Idle;

        if (playerGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")) * PlayerSpeedModifier;
        playerController.Move(move);

        if (move != Vector3.zero)
        {
            transform.forward = move;
            CurrentState = PlayerAnimation.PlayerAnimationState.Walking;
        }

        if (Input.GetKeyDown(KeyCode.Space) && playerGrounded)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -1.0f * -9.8f);
            CurrentState = PlayerAnimation.PlayerAnimationState.Jumping; //Make sure this goes  Jump --> Fall --> Idle  or state machine will get stuck
        }

        playerVelocity.y += -9.8f * Time.deltaTime;

        playerController.Move(playerVelocity);


        // For Testing All Actions Animations On keys 1 - 4

        if (Input.GetKey(KeyCode.Alpha1))
        {
            //Attack
            CurrentState = PlayerAnimation.PlayerAnimationState.Attacking;
        }

        if (Input.GetKey(KeyCode.Alpha2))
        {
            //Sniff
            CurrentState = PlayerAnimation.PlayerAnimationState.Sniffing;
        }

        if (Input.GetKey(KeyCode.Alpha3))
        {
            //Wag Tail
            CurrentState = PlayerAnimation.PlayerAnimationState.WaggingTail;
        }

        if (Input.GetKey(KeyCode.Alpha4))
        {
            //Be Pet
            CurrentState = PlayerAnimation.PlayerAnimationState.Petting;
        }


        Debug.Log(CurrentState);
        //Debug.Log(move); //Player Velocity.Y is the only thing affected so can only be used to calculate jump // move.y unaffected

    }
}
