using UnityEngine;

[CreateAssetMenu(menuName = "GGJ 2021/AI/Action/Face Player")]
public class FacePlayerAIAction : AIAction
{
    private AIWorldContext worldContext = null;

    private GameObject playerGameObject = null;

    public override void Initialize(CreatureAIController controller)
    {
        base.Initialize(controller);

        worldContext = controller.GetComponent<AIWorldContext>();
        playerGameObject = worldContext.GetPlayerGameObject();
    }

    public override void Act(CreatureAIController controller)
    {
        Vector3 heightMatchLocation = playerGameObject.transform.position;
        heightMatchLocation.y = controller.transform.position.y;

        controller.transform.LookAt(heightMatchLocation, Vector3.up);
    }
}
