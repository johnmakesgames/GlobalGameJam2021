using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneUITracker : MonoBehaviour
{
    private int bones;
    void Start()
    {
        AreaUnlockTracker.BonePickupCounterIncreased += BoneCountUpdated;
    }

    void BoneCountUpdated(int boneCount)
    {
        bones = boneCount;
    }
}
