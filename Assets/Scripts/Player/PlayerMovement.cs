using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    public float PlayerSpeedModifier = 0.01f;
    public float jumpHeight = 0.5f;
    public PlayerAnimation.PlayerAnimationState CurrentState;
    public Vector3 DirectionToDigZone;

    private CharacterController playerController;
    private bool playerGrounded;
    private Vector3 playerVelocity;

    public bool AbleToDig = false;
    private bool Alive = true;
    private GameObject[] DigZones;
    public GameObject CurrentDigZone;
    private GameObject NearestDigZone;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<CharacterController>();
        CurrentState = PlayerAnimation.PlayerAnimationState.Idle;
        DigZones = GameObject.FindGameObjectsWithTag("Diggable");
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


        if(AbleToDig)
        {
            //Pop up with "Press 'E' to Dig"
        }


        // Context Based Actions : WagTail, Pet, Shake, Dig

        if(Input.GetKey(KeyCode.E))
        {
            // Determine which Action to perform
            //Wag, Pet, Shake, Dig

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

            if (Input.GetKey(KeyCode.Alpha5))
            {
                CurrentState = PlayerAnimation.PlayerAnimationState.Shaking;
            }

            if (AbleToDig)
            {
                CurrentState = PlayerAnimation.PlayerAnimationState.Digging;

                Destroy(CurrentDigZone);
                
                DigZones = GameObject.FindGameObjectsWithTag("Diggable"); //Not Currently Updating on Dig Zone removal

                AbleToDig = false;
            }
        }

        Debug.Log(DigZones.Length);
        // Not Context based Actions : Attack & Sniff (B for bark in audio)

        if (Input.GetKey(KeyCode.Alpha1))
        {
            CurrentState = PlayerAnimation.PlayerAnimationState.Attacking;
        }

        if (Input.GetKey(KeyCode.Alpha2))
        {       
            CurrentState = PlayerAnimation.PlayerAnimationState.Sniffing;

            FindNearestDigZone();
        }

        
        if (!Alive) // if health == 0
        {
            CurrentState = PlayerAnimation.PlayerAnimationState.Dead;
        }


        //Debug.Log(CurrentState);
        //Debug.Log(playerVelocity.y); //Player Velocity.Y is the only thing affected so can only be used to calculate jump // move.y unaffected

    }


   void FindNearestDigZone()
   {
        NearestDigZone = DigZones[0];
        float nearestDistance = (NearestDigZone.transform.position - transform.position).magnitude;
        float newDistance;
        foreach(GameObject g in DigZones)
        {
            newDistance = (g.transform.position - transform.position).magnitude;

            if(newDistance < nearestDistance)
            {
                nearestDistance = newDistance;
                NearestDigZone = g;
            }
        }

        DirectionToDigZone = (NearestDigZone.transform.position - transform.position);
        DirectionToDigZone.Normalize();
   }

}
