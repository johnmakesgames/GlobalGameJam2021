using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowChildrenWhenInTrigger : MonoBehaviour
{
    private void Start()
    {
        var renderers = this.GetComponentsInChildren<Renderer>();
        foreach (var r in renderers)
        {
            r.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            var renderers = this.GetComponentsInChildren<Renderer>();
            foreach (var r in renderers)
            {
                r.enabled = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            var renderers = this.GetComponentsInChildren<Renderer>();
            foreach (var r in renderers)
            {
                r.enabled = false;
            }
        }
    }
}
