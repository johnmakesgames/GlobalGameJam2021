using UnityEngine;

[CreateAssetMenu(menuName = "GGJ 2021/AI/Action/Translate Controller")]
public class TranslateControllerAIAction : AIAction
{
    [SerializeField]
    private Vector3 translation = Vector3.zero;

    public override void Act(CreatureAIController controller)
    {
        controller.transform.Translate(translation * Time.deltaTime);
    }
}
