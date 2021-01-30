using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodSmearVanishAfterDuration : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyAfterDuration(60));
    }

    private IEnumerator DestroyAfterDuration(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Destroy(this.gameObject);
    }
}
