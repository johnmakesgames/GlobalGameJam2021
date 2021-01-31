using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaUnlockTracker : MonoBehaviour
{
    private int bonesCollected;

    public delegate void ItemPickedUp(int counter);
    public delegate void KeyPickedUp(string keyColour);
    public static event KeyPickedUp KeyPickedup;
    public static event ItemPickedUp BonePickupCounterIncreased;

    // Start is called before the first frame update
    void Start()
    {
        bonesCollected = 0;
        Pickup.OnItemPickedUp += OnItemPickedUp;
    }

    void OnItemPickedUp(ItemType type)
    {
        if (type.DisplayName.StartsWith("MapPickup"))
        {
            string keyColour = (type.DisplayName.Split('_'))[1];

            KeyPickedup(keyColour);
        }
        else if (type.DisplayName == "BonePickup")
        {
            bonesCollected++;
            BonePickupCounterIncreased(bonesCollected);
        }
    }
}
