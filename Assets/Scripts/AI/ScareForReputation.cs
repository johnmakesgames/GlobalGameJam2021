using UnityEngine;

public class ScareForReputation : MonoBehaviour
{
    [SerializeField]
    private float reputationChange = -0.3f;

    [SerializeField]
    private GameObject ragdollObject = null;

    [SerializeField]
    private GameObject staticObject = null;

    private VibeMessageHandler vibeMessageHandler = null;

    private void Awake()
    {
        vibeMessageHandler = GetComponent<VibeMessageHandler>();
        vibeMessageHandler.EventVibeMessage += OnVibeMessage;
    }

    private void OnVibeMessage(Vibe vibe, float value)
    {
        staticObject.SetActive(false);
        ragdollObject.SetActive(true);

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if(player != null)
        {
            PlayerReputation playerReputation = player.GetComponent<PlayerReputation>();
            playerReputation.AddReputation(reputationChange);
        }
    }
}
