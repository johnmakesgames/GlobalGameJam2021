using UnityEngine;

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

    /// <summary>
    /// Is a trick currently happening?
    /// </summary>
    private bool isPerformingTrick = false;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            PerformTrick();
        }
    }

    private void PerformTrick()
    {
        if(!isPerformingTrick)
        {
            EventTrickStart?.Invoke();

            // Animate.

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
        }
    }
}
