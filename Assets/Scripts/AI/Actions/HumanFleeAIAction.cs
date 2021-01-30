using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "GGJ 2021/AI/Action/Human/Flee")]
public class HumanFleeAIAction : AIAction
{
    [Tooltip("The distance from the AI controller the flee point is set to.")]
    [SerializeField]
    private float fleeDistance = 30.0f;

    [SerializeField]
    private float fleeSpeed = 8.0f;

    private AIWorldContext worldContext = null;
    private NavMeshAgent navAgent = null;

    private Vector3 fleeDestination = Vector3.zero;

    public override void Initialize(CreatureAIController controller)
    {
        base.Initialize(controller);

        worldContext = controller.GetComponent<AIWorldContext>();
        navAgent = controller.GetComponent<NavMeshAgent>();

        // Find the player and the vector from them to us.
        GameObject player = worldContext.GetPlayerGameObject();

        // Calculate the general direction in which to run.
        Vector3 playerToUs = controller.transform.position - player.transform.position;
        playerToUs.y = 0.0f;
        playerToUs.Normalize();
        Vector3 point = controller.transform.position + (playerToUs * 1.5f);
        point += Random.insideUnitSphere;
        Vector3 fleeDirection = point - controller.transform.position;
        fleeDirection.Normalize();

        // Find a valid nav-mesh point to flee too.
        Vector3 fleeLocation = controller.transform.position + (fleeDirection * fleeDistance);
        NavMeshQueryFilter filter = new NavMeshQueryFilter();
        filter.areaMask = (1 << NavMesh.GetAreaFromName("Walkable"));
        NavMesh.SamplePosition(fleeLocation, out NavMeshHit hit, fleeDistance * 2.0f, filter);
        fleeDestination = hit.position;

        // Enable nav-agent and start fleeing.
        navAgent.enabled = true;
        navAgent.SetDestination(fleeDestination);
        navAgent.speed = fleeSpeed;
    }

    public override void Act(CreatureAIController controller)
    {
    }

    protected override void OnStateExit(CreatureAIController controller)
    {
        base.OnStateExit(controller);

        navAgent.enabled = false;
    }
}
