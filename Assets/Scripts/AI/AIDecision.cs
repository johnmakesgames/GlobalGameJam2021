using UnityEngine;

public abstract class AIDecision : ScriptableObject
{
    public virtual void Initialize(CreatureAIController controller)
    {
        // Default implementation has no behavior.
    }

    /// <summary>
    /// Override to implement AI decision based on <see cref="CreatureAIController"/>.
    /// </summary>
    public abstract bool Decide(CreatureAIController controller);
}
