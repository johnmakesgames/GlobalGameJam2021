using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public Transform player;
    public Vector3 CameraOffset;
    public Vector3 CameraRotation;

    // Start is called before the first frame update
    void Start()
    {
       // CameraRotation = transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = player.position + CameraOffset;
    }

    private void FixedUpdate()
    {

        ////Rotate around the player
        //if (Input.GetKey(KeyCode.F))
        //{
        //    transform.RotateAround(player.position, Vector3.up, 70 * Time.deltaTime);
        //    CameraOffset = transform.position - player.position;
        //}

        //if (Input.GetKey(KeyCode.G))
        //{
        //    transform.RotateAround(player.position, Vector3.up, -70 * Time.deltaTime);
        //    CameraOffset = transform.position - player.position;

        //}

        //transform.LookAt(player);
    }
}
