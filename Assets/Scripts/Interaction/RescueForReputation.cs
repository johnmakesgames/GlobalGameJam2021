using UnityEngine;

public class RescueForReputation : MonoBehaviour, IInteractable
{
    [Tooltip("The prefab spawned for the rescued human AI.")]
    [SerializeField]
    private CreatureAIController rescuedHumanPrefab = null;

    [Tooltip("The amount of reputation gained for rescuing.")]
    [SerializeField]
    private float reputationReward = 0.25f;

    [Tooltip("Required reference to the awe vibe.")]
    [SerializeField]
    private Vibe aweVibe = null;

    public string GetInteractionText(InteractionController controller)
    {
        return "Rescue";
    }

    public void Interact(InteractionController controller)
    {
        // Find the player reputation component.
        PlayerReputation playerReputation = controller.GetComponent<PlayerReputation>();
        if(playerReputation != null)
        {
            playerReputation.AddReputation(reputationReward);
        }

        // Spawn the rescued AI.
        CreatureAIController rescuedHuman = Instantiate(rescuedHumanPrefab);
        rescuedHuman.transform.position = transform.position;

        // Give the human max awe so they cheer up.
        VibeMessageHandler vibeMessageHandler = rescuedHuman.GetComponent<VibeMessageHandler>();
        vibeMessageHandler.VibeMessage(aweVibe, float.MaxValue, true);

        // Clean up.
        Destroy(gameObject);
    }

    public bool IsInteractionAllowed(InteractionController controller)
    {
        return true;
    }
}
