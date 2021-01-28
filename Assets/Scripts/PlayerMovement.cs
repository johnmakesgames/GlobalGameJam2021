using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    public float PlayerSpeedModifier = 0.01f;
    public float jumpHeight = 0.5f;

    private CharacterController playerController;
    private bool playerGrounded;
    private Vector3 playerVelocity;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerGrounded = playerController.isGrounded;
        if(playerGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")) * PlayerSpeedModifier;
        playerController.Move(move);

        if(move != Vector3.zero)
        {
            transform.forward = move;
        }

        if(Input.GetKeyDown(KeyCode.Space) && playerGrounded)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -1.0f * -9.8f);
        }

        playerVelocity.y += -9.8f * Time.deltaTime;
        playerController.Move(playerVelocity);
    }
}
