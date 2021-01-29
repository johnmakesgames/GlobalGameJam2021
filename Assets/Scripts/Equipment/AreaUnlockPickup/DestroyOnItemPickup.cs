using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnItemPickup : MonoBehaviour
{
    public int pickupIndex;
    void Start()
    {
        AreaUnlockTracker.PickupCounterIncreased += OnItemPickedUp;
    }

    void OnItemPickedUp(int counter)
    {
        if (counter == pickupIndex)
        {
            Destroy(this.gameObject);
        }
    }
}
