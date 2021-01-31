using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawner : MonoBehaviour
{
    [SerializeField]
    private Vector3 respawnLocation;

    [SerializeField]
    public List<string> deaths;

    // Start is called before the first frame update
    void Start()
    {
        respawnLocation = this.transform.position;
    }

    public void KillAndRespawn(string death)
    {
        CharacterController col = GetComponent<CharacterController>();
        col.enabled = false;
        deaths.Add(death);
        this.transform.SetPositionAndRotation(respawnLocation, Quaternion.identity);
        col.enabled = true;
    }
}
