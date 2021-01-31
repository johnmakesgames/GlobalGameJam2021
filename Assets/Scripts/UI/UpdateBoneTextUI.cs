using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateBoneTextUI : MonoBehaviour
{
    [SerializeField]
    Text boneText;

    // Start is called before the first frame update
    void Start()
    {
        AreaUnlockTracker.BonePickupCounterIncreased += BonePickedUp;
    }

    private void OnDestroy()
    {
        AreaUnlockTracker.BonePickupCounterIncreased -= BonePickedUp;
    }

    void BonePickedUp(int boneCount)
    {
        boneText.text = boneCount.ToString();
    }
}
