using UnityEngine;

/// <summary>
/// Makes an <see cref="AIDecision"/> based on the value of a <see cref="Vibe"/>.
/// </summary>
[CreateAssetMenu(menuName = "GGJ 2021/AI/Decision/Vibe Score Test")]
public class VibeScoreAIDecision : AIDecision
{
    protected enum Operator
    {
        Equal,
        GreaterThanOrEqual,
        LessThanOrEqual
    }

    [SerializeField]
    private Vibe targetVibe = null;

    [SerializeField]
    [Range(0.0f, 1.0f)]
    private float value = 0.0f;

    [SerializeField]
    private Operator operation;

    private VibeTracker vibeTracker = null;

    public override void Initialize(CreatureAIController controller)
    {
        base.Initialize(controller);

        vibeTracker = controller.GetComponent<VibeTracker>();
    }

    public override bool Decide(CreatureAIController controller)
    {
        if(vibeTracker.GetVibeValue(targetVibe, out float vibeValue))
        {
            switch (operation)
            {
                case Operator.Equal:
                    return value == vibeValue;
                case Operator.GreaterThanOrEqual:
                    return vibeValue >= value;
                case Operator.LessThanOrEqual:
                    return vibeValue <= value;
            }
        }


        Debug.LogWarning($"{name} failed due to unrecognized vibe.");
        return false;
    }
}
