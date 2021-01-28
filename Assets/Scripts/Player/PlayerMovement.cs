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
    private enum AnimationState { Idle, Walking, Running, Shaking, Digging, Jumping, Attacking, Sniffing, WaggingTail, Sleeping, Petting }
    AnimationState CurrentState;
    AnimationState PreviousState;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<CharacterController>();
        CurrentState = AnimationState.Idle;
    }

    private void FixedUpdate()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PreviousState = CurrentState;
        
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
            playerAnimator.SetTrigger("Walking");
        }

        if (Input.GetKeyDown(KeyCode.Space) && playerGrounded)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -1.0f * -9.8f);
            CurrentState = AnimationState.Jumping;
        }

        playerVelocity.y += -9.8f * Time.deltaTime;
        playerController.Move(playerVelocity);

        if (Input.GetKey(KeyCode.Alpha1)) //hold key down
        {

            playerAnimator.SetTrigger("Shaking");
            CurrentState = AnimationState.Shaking;
        }
        else
        {
            playerAnimator.ResetTrigger("Shaking");
        }

        if (Input.GetKey(KeyCode.Alpha2)) //hold key down
        {
            playerAnimator.SetTrigger("Digging");
            CurrentState = AnimationState.Digging;
        }
        else
        {
            playerAnimator.ResetTrigger("Digging");
        }

        if (Input.GetKey(KeyCode.Alpha3)) //hold key down
        {
            playerAnimator.SetTrigger("Attacking");
            CurrentState = AnimationState.Attacking;
        }
        else
        {
            playerAnimator.ResetTrigger("Attacking");
        }

        if (Input.GetKey(KeyCode.Alpha4)) //hold key down
        {
            playerAnimator.SetTrigger("Sniffing");
            CurrentState = AnimationState.Sniffing;
        }
        else
        {
            playerAnimator.ResetTrigger("Sniffing");
        }

        if (Input.GetKey(KeyCode.Alpha5)) //hold key down
        {
            playerAnimator.SetTrigger("Petting");
            CurrentState = AnimationState.Petting;
        }
        else
        {
            playerAnimator.ResetTrigger("Petting");
        }

        if (Input.GetKey(KeyCode.Alpha6)) //hold key down
        {
            playerAnimator.SetTrigger("WaggingTail");
            CurrentState = AnimationState.WaggingTail;
        }
        else
        {
            playerAnimator.ResetTrigger("WaggingTail");
        }
        // Action: Sniff, Shake, WagTail(maybe), (being)Pet , Attack, digging
        // Movement: Walk, Idle, Run(maybe),  Sleep(AFK)
    }
}
