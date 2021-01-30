using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckGoodBoyScoreAndEnd : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            PlayerReputation rep = other.gameObject.GetComponent<PlayerReputation>();

            if (rep.GetReputation() < 0)
            {
                SceneManager.LoadScene("BadBoyEnding");
            }
            else
            {
                SceneManager.LoadScene("GoodBoyEnding");
            }
        }
    }
}
