using UnityEngine;

[CreateAssetMenu(menuName = "GGJ 2021/AI/Action/Human/Hide In Fear")]
public class HumanHideInFearAIAction : AIAction
{
    private VibeTracker vibeTracker = null;

    public override void Initialize(CreatureAIController controller)
    {
        base.Initialize(controller);

        vibeTracker = controller.GetComponent<VibeTracker>();
    }

    public override void Act(CreatureAIController controller)
    {
    }
}
