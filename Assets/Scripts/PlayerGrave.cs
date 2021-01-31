using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGrave : MonoBehaviour
{
    Respawner respawner;
    [SerializeField]
    int graveIndex;

    [SerializeField]
    public GameObject graveText;

    private TextMeshPro text;

    private void Start()
    {
        respawner = GameObject.FindGameObjectWithTag("Player").GetComponent<Respawner>();
        respawner.deadCallback += AddToGravestone;
        graveText.GetComponent<TextMeshProUGUI>().SetText("");
    }

    void AddToGravestone()
    {
        if(respawner.deaths.Count > graveIndex)
        {
           graveText.GetComponent<TextMeshProUGUI>().SetText(respawner.deaths[graveIndex]);
        }
    }
}
