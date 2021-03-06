using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diggable : MonoBehaviour
{
    private BoxCollider digArea;
    public GameObject digDrop;

    // Start is called before the first frame update
    void Start()
    {
        digArea = GetComponent<BoxCollider>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BeDug()
    {
        Instantiate(digDrop, transform.position, Quaternion.identity);
        //Drop Item
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            //Debug.Log("player Collide");
            var playerMoveScript = (PlayerMovement)other.gameObject.GetComponent("PlayerMovement");
            playerMoveScript.AbleToDig = true;
            playerMoveScript.CurrentDigZone = this.gameObject;

            //Text Output "Press E to Dig"
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Remove Text
        }
    }
}
