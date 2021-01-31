using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawner : MonoBehaviour
{
    [SerializeField]
    int startLives = 10;
    [SerializeField]
    int remainingLives;

    [SerializeField]
    private Vector3 respawnLocation;

    [SerializeField]
    public List<string> deaths;

    public event Action deadCallback;

    // Start is called before the first frame update
    void Start()
    {
        respawnLocation = this.transform.position;
        remainingLives = startLives;
    }

    public void KillAndRespawn(string death)
    {
        remainingLives--;

        if (remainingLives <= 0)
        {
            SceneManager.LoadScene("DeathScene");
        }
        else
        {
            CharacterController col = GetComponent<CharacterController>();
            col.enabled = false;
            deaths.Add(death);
            this.transform.SetPositionAndRotation(respawnLocation, Quaternion.identity);
            col.enabled = true;
            deadCallback?.Invoke();
        }
    }
}
