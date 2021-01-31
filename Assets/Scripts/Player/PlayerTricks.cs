using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerTricks : MonoBehaviour
{
    /// <summary>
    /// Broadcast when the player starts performing a trick.
    /// </summary>
    public System.Action EventTrickStart = null;

    /// <summary>
    /// Broadcast when the player finishes performing a trick.
    /// </summary>
    public System.Action EventTrickFinish = null;

    [Tooltip("The awe vibe.")]
    [SerializeField]
    private Vibe aweVibe = null;

    [Tooltip("The value of the awe vibe sent out for performing a trick.")]
    [SerializeField]
    private float aweMagnitudePerTrick = 0.1f;

    [Tooltip("Radius of the tricks sphere of influence for vibe messages.")]
    [SerializeField]
    private float trickVibeRadius = 5.0f;

    [Tooltip("How long does a trick last?")]
    [SerializeField]
    private float trickDuration = 1.0f;

    /// <summary>
    /// Is a trick currently happening?
    /// </summary>
    public bool IsPerformingTrick { get; private set; } = false;

    /// <summary>
    /// Reference to the attached <see cref="PlayerMovement"/> component.
    /// </summary>
    private PlayerMovement playerMovement = null;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();    
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            PerformTrick();
        }

        if (IsPerformingTrick)
        {
            playerMovement.CurrentState = PlayerAnimation.PlayerAnimationState.Trick;
        }
    }

    private void PerformTrick()
    {
        if(!IsPerformingTrick)
        {
            EventTrickStart?.Invoke();

            // Find nearby collisions within the tricks influence range.
            Collider[] collisions = Physics.OverlapSphere(transform.position, trickVibeRadius);
            foreach(Collider collider in collisions)
            {
                // Send awe messages.
                VibeMessageHandler vibeMessageHandler = collider.GetComponent<VibeMessageHandler>();
                if(vibeMessageHandler != null)
                {
                    vibeMessageHandler.VibeMessage(aweVibe, aweMagnitudePerTrick, true);
                }
            }

            IsPerformingTrick = true;
            Invoke("StopPerformingTrick", trickDuration);
        }
    }

    private void StopPerformingTrick()
    {
        IsPerformingTrick = false;
    }
}
