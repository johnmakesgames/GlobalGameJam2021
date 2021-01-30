using UnityEngine;

public class PlayerReputation : MonoBehaviour
{
    /// <summary>
    /// Invoked each time the reputation value changes/
    /// </summary>
    public System.Action<float> EventReputationChange = null;

    /// <summary>
    /// The current reputation value, valid between -1 and 1.
    /// </summary>
    private float reputation = 0.0f;

    /// <summary>
    /// Get the current reputation value.
    /// </summary>
    public float GetReputation()
    {
        return reputation;
    }

    /// <summary>
    /// Add to the reputation value.
    /// </summary>
    /// <param name="amount">Amount to add.</param>
    public void AddReputation(float amount)
    {
        reputation = Mathf.Clamp(reputation + amount, -1.0f, 1.0f);

        EventReputationChange?.Invoke(reputation);
    }
}