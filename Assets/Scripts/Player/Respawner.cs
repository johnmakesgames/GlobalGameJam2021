using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawner : MonoBehaviour
{
    [SerializeField]
    int startLives;
    [SerializeField]
    int remainingLives = 10;

    [SerializeField]
    private Vector3 respawnLocation;

    [SerializeField]
    public List<string> deaths;

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

        CharacterController col = GetComponent<CharacterController>();
        col.enabled = false;
        deaths.Add(death);
        this.transform.SetPositionAndRotation(respawnLocation, Quaternion.identity);
        col.enabled = true;
    }
}
