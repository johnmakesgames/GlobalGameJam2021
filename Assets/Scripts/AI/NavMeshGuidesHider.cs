using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavMeshGuidesHider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (this.GetComponent<Renderer>())
        {
            this.GetComponent<Renderer>().enabled = false;
        }

        var renderers = this.GetComponentsInChildren<Renderer>();
        foreach (var r in renderers)
        {
            r.enabled = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
