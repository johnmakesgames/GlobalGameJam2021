using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayerOnCollision : MonoBehaviour
{
    [SerializeField]
    GameObject bloodSplat;

    [SerializeField]
    GameObject bloodSmearPrefab;

    [SerializeField]
    string reasonForDeath = "Hit by car";

    Vector3 locationLastFrame;
    float movedSinceLastFrame = 0;
    bool spawnBlood;

    private void Start()
    {
        if (bloodSplat)
            bloodSplat.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        movedSinceLastFrame = Vector3.Distance(this.transform.position, locationLastFrame) * Time.deltaTime;
        locationLastFrame = this.transform.position;

        if (spawnBlood && bloodSmearPrefab)
        {
            var splat = GameObject.Instantiate(bloodSmearPrefab, new Vector3(this.transform.position.x, -0.05f, this.transform.position.z), this.GetComponentInParent<Transform>().rotation);

            splat.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (bloodSplat)
            {
                if (movedSinceLastFrame > 0.0002f)
                {
                    bloodSplat.gameObject.SetActive(true);
                    StartCoroutine(SetBloodBoolFalseAfterDuration(5));
                    other.gameObject.GetComponent<Respawner>().KillAndRespawn(reasonForDeath);
                }
            }
            else
            {
                other.gameObject.GetComponent<Respawner>().KillAndRespawn(reasonForDeath);
            }
        }
    }

    // every 2 seconds perform the print()
    private IEnumerator SetBloodBoolFalseAfterDuration(float waitTime)
    {
        spawnBlood = true;
        yield return new WaitForSeconds(waitTime);
        spawnBlood = false;
    }
}
