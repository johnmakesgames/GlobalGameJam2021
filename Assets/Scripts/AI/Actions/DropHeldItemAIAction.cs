using UnityEngine;

[CreateAssetMenu(menuName = "GGJ 2021/AI/Action/Drop Held Item")]
public class DropHeldItemAIAction : AIAction
{
    private AIHeldItem heldItemComponent = null;

    public override void Initialize(CreatureAIController controller)
    {
        base.Initialize(controller);

        heldItemComponent = controller.GetComponent<AIHeldItem>();
    }

    public override void Act(CreatureAIController controller)
    {
        if (heldItemComponent != null)
        {
            if (heldItemComponent.IsHoldingItem)
            {
                heldItemComponent.DropHeldItem();
            }
        }
    }
}
