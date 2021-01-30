using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayerOnCollision : MonoBehaviour
{
    Vector3 locationLastFrame;
    float movedSinceLastFrame = 0;

    // Update is called once per frame
    void Update()
    {
        movedSinceLastFrame = Vector3.Distance(this.transform.position, locationLastFrame) * Time.deltaTime;
        locationLastFrame = this.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            if (movedSinceLastFrame > 0.0005f)
            {
                Destroy(other.gameObject);
            }
        }
    }
}
