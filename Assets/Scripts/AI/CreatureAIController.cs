using UnityEngine;

public class CreatureAIController : MonoBehaviour
{
    [Tooltip("The starting state for the creature.")]
    [SerializeField]
    private AIState entryState = null;

    /// <summary>
    /// The <see cref="AIState"/> currently being executed.
    /// </summary>
    private AIState currentStateInstance = null;

    private void Start()
    {
        EnterState(entryState);
    }

    private void Update()
    {
        if(currentStateInstance != null)
        {
            currentStateInstance.RunState(this);
        }
    }

    /// <summary>
    /// Switches the controller to a provided
    /// <see cref="AIState"/>.
    /// </summary>
    /// <param name="state">The state to enter.</param>
    private void EnterState(AIState state)
    {
        // Exit existing state.
        if(currentStateInstance != null)
        {
            currentStateInstance.ExitState(this);
        }

        // Destroy the state.
        Destroy(currentStateInstance);

        currentStateInstance = Instantiate(state);
        if(currentStateInstance != null)
        {
            currentStateInstance.Initialize(this);
            currentStateInstance.EnterState(this);
        }
    }
}
