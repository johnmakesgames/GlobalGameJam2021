using UnityEngine;

public class CreatureAIController : MonoBehaviour
{
    /// <summary>
    /// Invoked each time the controller changes <see cref="AIState"/>.
    /// </summary>
    public System.Action<AIState> EventChangeState = null;

    [Tooltip("The starting state for the creature.")]
    [SerializeField]
    private AIState entryState = null;

    /// <summary>
    /// The <see cref="AIState"/> currently being executed.
    /// </summary>
    private AIState currentStateInstance = null;

#if UNITY_EDITOR
    [SerializeField]
    private bool vibeDebugTextEnabled = false;

    [SerializeField]
    private float vibeDebugVerticalOffset = 0.0f;
#endif

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
    public void EnterState(AIState state)
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

        // Broadcast state change.
        EventChangeState?.Invoke(state);
    }

#if UNITY_EDITOR
    private void OnGUI()
    {
        if (vibeDebugTextEnabled)
        {
            // Style.
            GUIStyle style = new GUIStyle();
            style.normal.textColor = Color.yellow;
            style.fontSize = 18;
            style.fontStyle = FontStyle.Bold;

            Vector2 origin = Camera.main.WorldToScreenPoint(new Vector3(transform.position.x, transform.position.y + vibeDebugVerticalOffset, transform.position.z));

            int lineHeight = 24;

            if (currentStateInstance != null)
            {
                string text = $"AI State: {currentStateInstance.name}";
                Vector2 textSize = style.CalcSize(new GUIContent(text));

                Vector2 textPosition = origin;
                textPosition.x -= (textSize.x / 2.0f);
                textPosition.y += (lineHeight);

                GUI.Label(new Rect(textPosition.x, Screen.height - textPosition.y, textSize.x, textSize.y), text, style);
            }
        }
    }
#endif
}
