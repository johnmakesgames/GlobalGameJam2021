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
        deaths.Add(death);
        this.transform.TransformPoint(Vector3.zero);
    }    
}
