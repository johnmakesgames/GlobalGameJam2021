using UnityEngine;

[CreateAssetMenu(menuName = "GGJ 2021/AI/Decision/Trade Complete")]
public class TradeCompleteAIDecision : AIDecision
{
    /// <summary>
    /// The <see cref="Trading"/> component attached to the controller.
    /// </summary>
    private Trading trading = null;

    public override void Initialize(CreatureAIController controller)
    {
        base.Initialize(controller);

        trading = controller.GetComponent<Trading>();
    }

    public override bool Decide(CreatureAIController controller)
    {
        return trading.IsTradeComplete;
    }
}
