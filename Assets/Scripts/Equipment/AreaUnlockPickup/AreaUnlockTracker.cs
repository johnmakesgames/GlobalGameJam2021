using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaUnlockTracker : MonoBehaviour
{
    private int pickupCounter;

    public delegate void ItemPickedUp(int pickupCounter);
    public static event ItemPickedUp PickupCounterIncreased;

    // Start is called before the first frame update
    void Start()
    {
        pickupCounter = 0;
        Pickup.OnItemPickedUp += OnItemPickedUp;
    }

    void OnItemPickedUp(ItemType type)
    {
        if (type.DisplayName == "MapPickup")
        {
            pickupCounter++;
            PickupCounterIncreased(pickupCounter);
        }
    }
}
