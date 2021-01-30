using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diggable : MonoBehaviour
{
    private BoxCollider digArea;
    // Start is called before the first frame update
    void Start()
    {
        digArea = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            //Debug.Log("player Collide");
            var playerMoveScript = (PlayerMovement)other.gameObject.GetComponent("PlayerMovement");
            playerMoveScript.AbleToDig = true;
            playerMoveScript.CurrentDigZone = this.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Debug.Log("Player Exit");

            //cast to player
            //player movement
            //AbleToDig = false;
        }
    }
}
