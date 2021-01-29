using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnItemPickup : MonoBehaviour
{
    public string pickupName;

    void Start()
    {
        // Register for delegate event.
    }

    // Destroy itself when the event is invoked.
    void OnInvoke(string pickupName)
    {
        if (pickupName == this.pickupName)
        {
            Destroy(this.gameObject);
        }
    }
}
