using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    [SerializeField]
    public AudioClip normalBarkNoise;
    public AudioClip angryBarkNoise;
    public AudioClip happyBarkNoise; //room to add more
    public float reputation = 0.0f;
    public float barkEffectRadius = 5.0f;
    public Vibe barkEffectVibe = null;

    private AudioSource source;
    private bool Bark = false;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            Bark = true;
        }


        if (Bark)
        {
            if(reputation <= 0.5f)
            {
                source.PlayOneShot(happyBarkNoise);
            }
            else if(reputation <= 1.5f)
            {
                source.PlayOneShot(normalBarkNoise);
            }
            else
            {
                source.PlayOneShot(angryBarkNoise);
            }

            BarkVibeMessage();

            Bark = false;
        }
    }

    private void BarkVibeMessage()
    {
        Collider[] overlaps = Physics.OverlapSphere(transform.position, barkEffectRadius);
        foreach(Collider collider in overlaps)
        {
            VibeMessageHandler messageHandler = collider.GetComponent<VibeMessageHandler>();
            if(messageHandler)
            {
                messageHandler.VibeMessage(barkEffectVibe, 0.1f);
            }
        }
    }
}
