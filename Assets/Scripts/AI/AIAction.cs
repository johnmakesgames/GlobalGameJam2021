using UnityEngine;

/// <summary>
/// Base class for action in a pluggable AI system based around
/// https://learn.unity.com/tutorial/pluggable-ai-with-scriptable-objects
/// </summary>
public abstract class AIAction : ScriptableObject
{
    public virtual void Initialize(CreatureAIController controller)
    {
        // Default implementation has no behavior.
    }

    /// <summary>
    /// Override to implement a single AI action.
    /// </summary>
    /// <param name="controller">The <see cref="CreatureAIController"/> instigating the action.</param>
    public abstract void Act(CreatureAIController controller);
}