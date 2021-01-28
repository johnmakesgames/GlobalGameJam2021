using UnityEngine;

/// <summary>
/// States implementation for a pluggable AI system based around
/// https://learn.unity.com/tutorial/pluggable-ai-with-scriptable-objects
/// </summary>
[CreateAssetMenu(fileName = "New AI State", menuName = "GGJ 2021/AI/State")]
public class AIState : ScriptableObject
{
    [Tooltip("The actions once upon entry to this state.")]
    [SerializeField]
    private AIAction[] entryActions = null;

    [Tooltip("The actions once upon exit of this state.")]
    [SerializeField]
    private AIAction[] exitActions = null;

    [Tooltip("The actions performed each frame during this state.")]
    [SerializeField]
    private AIAction[] actions = null;

    private AIAction[] entryActionInstances = null;
    private AIAction[] exitActionInstances = null;
    private AIAction[] actionInstances = null;

    public void Initialize(CreatureAIController controller)
    {
        if (entryActions != null)
        {
            entryActionInstances = new AIAction[entryActions.Length];
            for (int i = 0; i < entryActions.Length; ++i)
            {
                entryActionInstances[i] = Instantiate(entryActions[i]);
                entryActionInstances[i].Initialize(controller);
            }
        }

        if (exitActions != null)
        {
            exitActionInstances = new AIAction[exitActions.Length];
            for (int i = 0; i < exitActions.Length; ++i)
            {
                exitActionInstances[i] = Instantiate(exitActions[i]);
                exitActionInstances[i].Initialize(controller);
            }
        }

        if (actions != null)
        {
            actionInstances = new AIAction[actions.Length];
            for (int i = 0; i < actions.Length; ++i)
            {
                actionInstances[i] = Instantiate(actions[i]);
                actionInstances[i].Initialize(controller);
            }
        }
    }

    /// <summary>
    /// Call upon entrance into a state.
    /// </summary>
    /// <param name="controller">The owning <see cref="CreatureAIController"/>.</param>
    public void EnterState(CreatureAIController controller)
    {
        if (entryActionInstances != null)
        {
            foreach (AIAction action in entryActionInstances)
            {
                action.Act(controller);
            }
        }
    }

    /// <summary>
    /// Call upon exit into a state.
    /// </summary>
    /// <param name="controller">The owning <see cref="CreatureAIController"/>.</param>
    public void ExitState(CreatureAIController controller)
    {
        if (exitActionInstances != null)
        {
            foreach (AIAction action in exitActionInstances)
            {
                action.Act(controller);
            }
        }
    }

    /// <summary>
    /// Execute the per-frame actions.
    /// </summary>
    /// <param name="controller">Instigating <see cref="CreatureAIController"/></param>
    public void RunState(CreatureAIController controller)
    {
        if(actionInstances != null)
        {
            foreach(AIAction action in actionInstances)
            {
                action.Act(controller);
            }
        }
    }
}