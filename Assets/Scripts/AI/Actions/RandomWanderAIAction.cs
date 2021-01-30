using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "GGJ 2021/AI/Action/Random Wander")]
public class RandomWanderAIAction : AIAction
{
    [SerializeField]
    private float walkSpeed = 3.0f;

    private NavMeshAgent navMeshAgent = null;
    private AIWorldContext worldContext = null;

    private GameObject previousPedestrianNode = null;

    public override void Initialize(CreatureAIController controller)
    {
        base.Initialize(controller);

        navMeshAgent = controller.GetComponent<NavMeshAgent>();
        worldContext = controller.GetComponent<AIWorldContext>();

        // Enable nav mesh agent when in use.
        navMeshAgent.enabled = true;
        navMeshAgent.speed = walkSpeed;

        SetNewPath(controller);
    }

    protected override void OnStateExit(CreatureAIController controller)
    {
        base.OnStateExit(controller);

        // Disable nav mesh agent when not in use.
        navMeshAgent.enabled = false;
    }

    public override void Act(CreatureAIController controller)
    {
        // Check for destination reach and select another.
        float distanceToDestination = Vector3.Distance(navMeshAgent.destination, controller.transform.position);
        if(distanceToDestination <= 0.0f)
        {
            SetNewPath(controller);
        }
    }

    private void SetNewPath(CreatureAIController controller)
    {
        
        GameObject node = worldContext.GetRandomPedestrianPathNode();
        while ((node == previousPedestrianNode) && (node != null) && (worldContext.GetPedestrianPathNodeCount() > 1))
        {
            node = worldContext.GetRandomPedestrianPathNode();
        }
        
        if(node != null)
        {
            navMeshAgent.SetDestination(node.transform.position);
            previousPedestrianNode = node;

            Debug.DrawLine(controller.transform.position, node.transform.position, Color.red, 1.0f);
        }
    }
}
