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
    public Camera playerCamera;

    private CharacterController playerController;
    private bool playerGrounded;
    private Vector3 playerVelocity;

    public bool AbleToDig = false;
    private bool Alive = true;
    private GameObject[] DigZones;
    public GameObject CurrentDigZone;
    private GameObject NearestDigZone;
    private PlayerTricks playerTricks = null;

    private void Awake()
    {
        playerTricks = GetComponent<PlayerTricks>();  
    }

    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<CharacterController>();
        CurrentState = PlayerAnimation.PlayerAnimationState.Idle;
    }

    private void FixedUpdate()
    {
        playerGrounded = playerController.isGrounded;

        if (playerGrounded)
            CurrentState = PlayerAnimation.PlayerAnimationState.Idle;

        if (playerGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 moveDirection = new Vector3(0, 0, 0);

        if (!playerTricks.IsPerformingTrick)
        {
            if (Input.GetKey(KeyCode.W))
            {
                // move in the direction of camera
                moveDirection = playerCamera.transform.forward;
            }

            if (Input.GetKey(KeyCode.S))
            {
                // reverse S
                moveDirection = -playerCamera.transform.forward;
            }

            if (Input.GetKey(KeyCode.A))
            {
                // Move Camera Left
                moveDirection = -playerCamera.transform.right;
            }

            if (Input.GetKey(KeyCode.D))
            {
                // Move Camera Right
                moveDirection = playerCamera.transform.right;

            }
        }

        moveDirection.y = 0;

        moveDirection *= Time.deltaTime * PlayerSpeedModifier;
        playerController.Move(moveDirection);


        if (moveDirection != Vector3.zero)
        {
            transform.forward = moveDirection;
            CurrentState = PlayerAnimation.PlayerAnimationState.Walking;
        }

        if (Input.GetKeyDown(KeyCode.Space) && playerGrounded)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -1.0f * -9.8f);
            CurrentState = PlayerAnimation.PlayerAnimationState.Jumping; //Make sure this goes  Jump --> Fall --> Idle  or state machine will get stuck
        }

        playerVelocity.y += -9.8f * Time.deltaTime;

        playerController.Move(playerVelocity);

        if (Input.GetKey(KeyCode.E))
        {
            if (AbleToDig)
            {
                CurrentState = PlayerAnimation.PlayerAnimationState.Digging;

                var digScript = (Diggable)CurrentDigZone.gameObject.GetComponent("Diggable");
                digScript.BeDug();

                //Destroy(CurrentDigZone);

                DigZones = GameObject.FindGameObjectsWithTag("Diggable");

                AbleToDig = false;
            }
        }

        //Debug.Log(DigZones.Length);
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

        //if (Input.GetKey(KeyCode.Alpha6))
        //{
        //    CurrentState = PlayerAnimation.PlayerAnimationState.Trick;
        //}

        if (!Alive) // if health == 0
        {
            CurrentState = PlayerAnimation.PlayerAnimationState.Dead;
        }


        //Debug.Log(CurrentState);
        //Debug.Log(playerVelocity.y); //Player Velocity.Y is the only thing affected so can only be used to calculate jump // move.y unaffected
    }

    // Update is called once per frame
    void Update()
    {
        

    }


   void FindNearestDigZone()
   {
        DigZones = GameObject.FindGameObjectsWithTag("Diggable");
        //Debug.Log(DigZones.Length);

        if (DigZones.Length > 0)
        {
            NearestDigZone = DigZones[0];
            float nearestDistance = (NearestDigZone.transform.position - transform.position).magnitude;
            float newDistance;
            foreach (GameObject g in DigZones)
            {
                newDistance = (g.transform.position - transform.position).magnitude;

                if (newDistance < nearestDistance)
                {
                    nearestDistance = newDistance;
                    NearestDigZone = g;
                }
            }

            DirectionToDigZone = (NearestDigZone.transform.position - transform.position);
            DirectionToDigZone.Normalize();
        }
        else
        {
            DirectionToDigZone = Vector3.zero;
        }
        
   }

}
