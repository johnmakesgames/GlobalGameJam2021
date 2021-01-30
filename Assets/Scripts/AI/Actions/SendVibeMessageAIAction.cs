using UnityEngine;

/// <summary>
/// <see cref="AIAction"/> that sends a vibe message each frame while running.
/// </summary>
[CreateAssetMenu(menuName = "GGJ 2021/AI/Action/Vibe/Send Vibe Message")]
public class SendVibeMessageAIAction : AIAction
{
    [Tooltip("The vibe key for the message.")]
    [SerializeField]
    private Vibe vibe = null;

    [Tooltip("The value sent with the message.")]
    [SerializeField]
    private float value = 0.0f;

    private VibeMessageHandler vibeMessageHandler = null;

    public override void Initialize(CreatureAIController controller)
    {
        base.Initialize(controller);

        vibeMessageHandler = controller.GetComponent<VibeMessageHandler>();
    }

    public override void Act(CreatureAIController controller)
    {
        vibeMessageHandler.VibeMessage(vibe, value * Time.deltaTime, false);
    }
}
