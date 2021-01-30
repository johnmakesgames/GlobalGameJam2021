using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class VibeIndicator : MonoBehaviour
{
    [Tooltip("Speed at which the indicator rises into the air.")]
    [SerializeField]
    private float riseSpeed = 0.1f;

    [Tooltip("Duration the indicator exists for.")]
    [SerializeField]
    private float lifetime = 1.0f;

    private SpriteRenderer spriteRenderer = null;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + (riseSpeed * Time.deltaTime), transform.position.z);
    }

    public void SetIcon(Sprite icon)
    {
        if(spriteRenderer != null)
        {
            spriteRenderer.sprite = icon;
        }
    }
}
