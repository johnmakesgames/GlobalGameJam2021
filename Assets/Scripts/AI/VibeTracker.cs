using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Keeps track of the current value for various <see cref="Vibe"/>s.
/// </summary>
[RequireComponent(typeof(VibeMessageHandler))]
public class VibeTracker : MonoBehaviour
{
    [Tooltip("The vibes recognized by this AI creature.")]
    [SerializeField]
    private Vibe[] recognisedVibes = null;

#if UNITY_EDITOR
    [SerializeField]
    private float vibeDebugVerticalOffset = 0.0f;
#endif

    /// <summary>
    /// The current value of the vibes.
    /// </summary>
    private Dictionary<Vibe, float> vibeValues = new Dictionary<Vibe, float>();

    /// <summary>
    /// The attached message handler used to listen for vibe changes.
    /// </summary>
    private VibeMessageHandler vibeMessageHandler = null;

    private void Awake()
    {
        vibeMessageHandler = GetComponent<VibeMessageHandler>();
        if(vibeMessageHandler != null)
        {
            vibeMessageHandler.EventVibeMessage += OnVibeMessage;
        }

        if(recognisedVibes != null)
        {
            foreach(Vibe vibe in recognisedVibes)
            {
                if(!vibeValues.ContainsKey(vibe))
                {
                    vibeValues.Add(vibe, vibe.DefaultValue);
                }
            }
        }
    }

    /// <summary>
    /// Get the value of a <see cref="Vibe"/>.
    /// </summary>
    public bool GetVibeValue(Vibe vibe, out float score)
    {
        if(RecognisesVibe(vibe))
        {
            score = vibeValues[vibe];
            return true;
        }

        score = 0.0f;
        return false;
    }

    /// <summary>
    /// Does this tracker recognize a particular <see cref="Vibe"/>.
    /// </summary>
    /// <param name="vibe">The vibe to check.</param>
    public bool RecognisesVibe(Vibe vibe)
    {
        return (vibe != null) && (vibeValues != null) && (vibeValues.ContainsKey(vibe));
    }

    /// <summary>
    /// Update the score of the vibe.
    /// </summary>
    protected void OnVibeMessage(Vibe vibe, float scoreChange)
    {
        if(RecognisesVibe(vibe))
        {
            vibeValues[vibe] += scoreChange;
        }
    }

#if UNITY_EDITOR
    private void OnGUI()
    {
        // Style.
        GUIStyle style = new GUIStyle();
        style.normal.textColor = Color.yellow;
        style.fontSize = 18;
        style.fontStyle = FontStyle.Bold;

        Vector2 origin = Camera.main.WorldToScreenPoint(new Vector3(transform.position.x, transform.position.y + vibeDebugVerticalOffset, transform.position.z));

        int lineHeight = 24;
        int lineCount = 0;
        foreach (KeyValuePair<Vibe, float> vibeScorePair in vibeValues)
        {
            string text = $"{vibeScorePair.Key.name}: {vibeScorePair.Value}";
            Vector2 textSize = style.CalcSize(new GUIContent(text));

            Vector2 textPosition = origin;
            textPosition.x -= (textSize.x / 2.0f);
            textPosition.y += (lineCount * lineHeight);

            GUI.Label(new Rect(textPosition.x, Screen.height - textPosition.y, textSize.x, textSize.y), text, style);
            ++lineCount;
        }     
    }
#endif
}
