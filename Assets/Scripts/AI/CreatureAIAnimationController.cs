using UnityEngine;

/// <summary>
/// Provides functionality to manage the animation playing on a
/// <see cref="CreatureAIController"/>.
/// </summary>
[RequireComponent(typeof(CreatureAIController))]
public class CreatureAIAnimationController : MonoBehaviour
{
    [SerializeField]
    private Animator animator = null;

    private CreatureAIController controller = null;

    private void Awake()
    {
        controller = GetComponent<CreatureAIController>();
        controller.EventChangeState += OnAIStateChange;
    }

    private void OnAIStateChange(AIState newState)
    {
        animator.Play(newState.GetRandomAnimation().name);
    }
}
