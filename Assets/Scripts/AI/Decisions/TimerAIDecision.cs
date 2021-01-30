using UnityEngine;

/// <summary>
/// A type of <see cref="AIDecision"/> that passes after a time limit has
/// passed.
/// </summary>
[CreateAssetMenu(menuName = "GGJ 2021/AI/Decision/Timer")]
public class TimerAIDecision : AIDecision
{
    [SerializeField]
    private float timeLimit = 3.0f;

    private float timeStamp = 0.0f;

    public override void Initialize(CreatureAIController controller)
    {
        base.Initialize(controller);

        timeStamp = Time.time;
    }

    public override bool Decide(CreatureAIController controller)
    {
        return (Time.time - timeStamp) >= timeLimit;
    }
}
