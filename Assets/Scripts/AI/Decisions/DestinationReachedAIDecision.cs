using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "GGJ 2021/AI/Decision/NAvigation/Reached Destination")]
public class DestinationReachedAIDecision : AIDecision
{
    [Tooltip("The agent must be within this distance of their destination for the decision to pass.")]
    [SerializeField]
    private float acceptableDistance = 1.0f;

    private NavMeshAgent navAgent = null;

    public override void Initialize(CreatureAIController controller)
    {
        base.Initialize(controller);

        navAgent = controller.GetComponent<NavMeshAgent>();
        navAgent.enabled = true;
    }

    public override bool Decide(CreatureAIController controller)
    {
        return Vector3.Distance(controller.transform.position, navAgent.destination) <= acceptableDistance;
    }
}
