using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnItemPickup : MonoBehaviour
{
    public string wantedKeyName;
    void Start()
    {
        AreaUnlockTracker.KeyPickedup += OnItemPickedUp;
    }

    void OnItemPickedUp(string collectedKey)
    {
        if (collectedKey == wantedKeyName)
        {
            AreaUnlockTracker.KeyPickedup -= OnItemPickedUp;
            Destroy(this.gameObject);
        }
    }
}
