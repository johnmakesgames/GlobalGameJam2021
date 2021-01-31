using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnItemPickup : MonoBehaviour
{
    public string wantedKeyName;
    void Start()
    {
        AreaUnlockTracker.MapPickupCounterIncreased += OnItemPickedUp;
    }

    void OnItemPickedUp(string collectedKey)
    {
        if (collectedKey == wantedKeyName)
        {
            AreaUnlockTracker.MapPickupCounterIncreased -= OnItemPickedUp;
            Destroy(this.gameObject);
        }
    }
}
