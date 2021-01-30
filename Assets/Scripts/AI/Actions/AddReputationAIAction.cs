using UnityEngine;

[CreateAssetMenu(menuName = "GGJ 2021/AI/Action/Add Reputation")]
public class AddReputationAIAction : AIAction
{
    [Tooltip("The amount of reputation added/removed.")]
    [SerializeField]
    private float reputationChange = 0.0f;

    [Tooltip("Is the reputation being applied over time?")]
    [SerializeField]
    private bool appliedOverTime = false;

    private AIWorldContext worldContext = null;

    public override void Initialize(CreatureAIController controller)
    {
        base.Initialize(controller);

        worldContext = controller.GetComponent<AIWorldContext>();
    }

    public override void Act(CreatureAIController controller)
    {
        GameObject player = worldContext.GetPlayerGameObject();
        PlayerReputation reputation = player.GetComponent<PlayerReputation>();
        reputation.AddReputation(reputationChange * (appliedOverTime ? Time.deltaTime : 1.0f));
    }
}
