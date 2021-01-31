using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveOnKeyPickup : MonoBehaviour
{
    [SerializeField]
    GameObject yellowKey;

    [SerializeField]
    GameObject greenKey;

    [SerializeField]
    GameObject blueKey;

    [SerializeField]
    GameObject redKey;

    [SerializeField]
    GameObject pinkKey;

    Dictionary<string, GameObject> keyValuePairs = new Dictionary<string, GameObject>();

    void Start()
    {
        keyValuePairs.Add("Yellow", yellowKey);
        keyValuePairs.Add("Green", greenKey);
        keyValuePairs.Add("Blue", blueKey);
        keyValuePairs.Add("Red", redKey);
        keyValuePairs.Add("Pink", pinkKey);
        AreaUnlockTracker.KeyPickedup += OnKeyPickedUp;
    }

    private void OnDestroy()
    {
        AreaUnlockTracker.KeyPickedup -= OnKeyPickedUp;
    }

    void OnKeyPickedUp(string collectedKey)
    {
        GameObject key = keyValuePairs[collectedKey];
        key.SetActive(true);
    }
}
