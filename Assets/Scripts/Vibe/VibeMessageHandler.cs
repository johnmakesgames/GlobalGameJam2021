using System;
using UnityEngine;

public class VibeMessageHandler : MonoBehaviour
{
    public event Action<Vibe, float> EventVibeMessage = null;

    [Tooltip("The origin point for indicator icon spawns.")]
    [SerializeField]
    private Transform indicatorOrigin = null;

    [Tooltip("Maximum distance randomly selected for indicator spawn location.")]
    [SerializeField]
    private float indicatorRandomSpawnRadius = 0.5f;

    [Tooltip("The prefab for a vibe indicator.")]
    [SerializeField]
    private VibeIndicator vibeIndicatorPrefab = null;

    /// <summary>
    /// Send a vibe message that will be broadcast to listeners.
    /// </summary>
    public void VibeMessage(Vibe vibe, float scoreChange, bool spawnIndicator)
    {
        if(vibe == null)
        {
            Debug.LogWarning("VibeMessageHandler received message with invalid vibe.");
            return;
        }

        if (spawnIndicator)
        {
            SpawnIndicator(vibe);
        }

        EventVibeMessage?.Invoke(vibe, scoreChange);
    }


    private void SpawnIndicator(Vibe vibe)
    {
        Vector3 randomOffset = (UnityEngine.Random.insideUnitSphere * indicatorRandomSpawnRadius);
        randomOffset.y = 0.0f;

        Vector3 spawnLocation = indicatorOrigin.position + randomOffset;

        VibeIndicator indicator = Instantiate(vibeIndicatorPrefab, spawnLocation, Quaternion.Euler(0.0f, UnityEngine.Random.value * 360.0f, 0.0f));
        indicator.SetIcon(vibe.Icon);
    }
}
