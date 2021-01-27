using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleOnHowToUseComponents1 : MonoBehaviour
{
    public float timePassedCounter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timePassedCounter += Time.deltaTime;

        Transform t = this.GetComponent<Transform>();
        t.position = t.position + new Vector3(Mathf.Sin(timePassedCounter) / 1000, 0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Something Has Entered Me");
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
