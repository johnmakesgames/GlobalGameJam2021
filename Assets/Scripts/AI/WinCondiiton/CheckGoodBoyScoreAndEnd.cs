using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckGoodBoyScoreAndEnd : MonoBehaviour
{
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            PlayerReputation rep = other.gameObject.GetComponent<PlayerReputation>();
            animator.SetBool("DogHere", true);
            this.transform.position = new Vector3(-299.95f, -0.016f, 38.778f);

            if (rep.GetReputation() < 0)
            {
                StartCoroutine(SetPositionAfterTime(0.8f));
                animator.SetFloat("GoodBoyPoints", -1);
                StartCoroutine(WaitAndMoveScene(5, "BadBoyEnding"));
            }
            else
            {
                animator.SetFloat("GoodBoyPoints", 1);
                StartCoroutine(WaitAndMoveScene(5, "GoodBoyEnding"));
            }
        }
    }

    private IEnumerator WaitAndMoveScene(float waitTime, string sceneToMoveTo)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(sceneToMoveTo);
    }

    private IEnumerator SetPositionAfterTime(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        this.transform.position = new Vector3(-299.38f, 0.03f, 38.84f);
    }
}
