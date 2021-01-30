using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarWheelController : MonoBehaviour
{
    public GameObject[] wheels;

    Vector3 previousFramePos;

    public float step;

    void Start()
    {
        step = 0;
        previousFramePos = this.GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    {
        if (previousFramePos != this.GetComponent<Transform>().position)
        {
            step = (previousFramePos - this.GetComponent<Transform>().position).magnitude;
            foreach (var wheel in wheels)
            {
                wheel.GetComponent<Transform>().Rotate(new Vector3(-1, 0, 0), step * 100);
            }
        }

        previousFramePos = this.GetComponent<Transform>().position;
    }
}
