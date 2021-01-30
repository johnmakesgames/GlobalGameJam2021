using UnityEngine;

[System.Serializable]
public class AITransition
{
    [Tooltip("The decision executed for this transition.")]
    [SerializeField]
    private AIDecision decision = null;

    [Tooltip("The state transitioned to upon decision pass.")]
    [SerializeField]
    private AIState passState = null;
    
    [Tooltip("The state transitioned to upon decision fail.")]
    [SerializeField]
    private AIState failState = null;

    public AIDecision Decision { get { return decision; } }
    public AIState PassState { get { return passState; } }
    public AIState FailState { get { return failState; } }
}
