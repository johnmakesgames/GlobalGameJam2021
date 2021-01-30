using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaUnlockTracker : MonoBehaviour
{
    private int pickupCounter;
    private int bonesCollected;

    public delegate void ItemPickedUp(int counter);
    public static event ItemPickedUp MapPickupCounterIncreased;
    public static event ItemPickedUp BonePickupCounterIncreased;

    // Start is called before the first frame update
    void Start()
    {
        pickupCounter = 0;
        bonesCollected = 0;
        Pickup.OnItemPickedUp += OnItemPickedUp;
    }

    void OnItemPickedUp(ItemType type)
    {
        if (type.DisplayName == "MapPickup")
        {
            pickupCounter++;
            MapPickupCounterIncreased(pickupCounter);
        }
        else if (type.DisplayName == "BonePickup")
        {
            bonesCollected++;
            BonePickupCounterIncreased(bonesCollected);
        }
    }
}
