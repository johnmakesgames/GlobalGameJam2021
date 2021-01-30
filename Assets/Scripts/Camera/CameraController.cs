using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    public Transform player;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.RotateAround(player.position, Vector3.up, 70 * Time.deltaTime);
            offset = transform.position - player.position;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.RotateAround(player.position, Vector3.up, -70 * Time.deltaTime);
            offset = transform.position - player.position;
        }

        transform.position = player.position + offset;

        Vector3 lookAt = new Vector3(player.position.x, player.position.y + 2, player.position.z);
        transform.LookAt(lookAt); //player
    }

    private void FixedUpdate()
    {
        
    }
}
