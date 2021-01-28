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

            // Debug.Log($"Vibe '{vibe.name}' score updated to {vibeValues[vibe]}");
        }
    }
}
