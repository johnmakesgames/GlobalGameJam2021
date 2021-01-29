using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeVisibilityOnDistance : MonoBehaviour
{
    bool trackDistance = false;
    GameObject player;
    Renderer[] childRenderers;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        childRenderers = this.GetComponentsInChildren<Renderer>();
        foreach (var r in childRenderers)
        {
            r.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (trackDistance)
        {
            float distance = Vector3.Distance(player.transform.position, this.transform.position);
            Debug.Log($"{this.gameObject.name} : {distance}");
            if (distance < 2.5)
            {
                foreach (var r in childRenderers)
                {
                    Color col = r.material.color;
                    col.a = 1;
                    r.material.color = col;
                }
            }
            else if (distance < 10)
            {
                foreach (var r in childRenderers)
                {
                    Color col = r.material.color;
                    col.a = 1 - distance / 10;
                    r.material.color = col;
                }
            }
            else
            {
                foreach (var r in childRenderers)
                {
                    Color col = r.material.color;
                    col.a = 0;
                    r.material.color = col;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            trackDistance = true;
            foreach (var r in childRenderers)
            {
                r.enabled = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            trackDistance = false;
            foreach (var r in childRenderers)
            {
                r.enabled = false;
            }
        }
    }
}
