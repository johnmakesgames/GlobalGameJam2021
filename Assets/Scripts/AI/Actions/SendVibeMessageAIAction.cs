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

    [Tooltip("The range selected from to add random variation to the message value.")]
    [SerializeField]
    private Vector2 randomVariationRange = Vector2.zero;

    private VibeMessageHandler vibeMessageHandler = null;

    private float variationValue = 0.0f;

    public override void Initialize(CreatureAIController controller)
    {
        base.Initialize(controller);

        vibeMessageHandler = controller.GetComponent<VibeMessageHandler>();

        variationValue = Mathf.Lerp(randomVariationRange.x, randomVariationRange.y, Random.value);
    }

    public override void Act(CreatureAIController controller)
    {
        float messageMagnitude = value + variationValue;
        vibeMessageHandler.VibeMessage(vibe, messageMagnitude * Time.deltaTime, false);
    }
}
