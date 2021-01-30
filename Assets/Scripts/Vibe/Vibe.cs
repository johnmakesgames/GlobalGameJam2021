using UnityEngine;

[CreateAssetMenu(fileName = "New Item Vibe", menuName = "GGJ 2021/Vibe")]
public class Vibe : ScriptableObject
{
    [Tooltip("The icon for this vibe.")]
    [SerializeField]
    private Sprite icon = null;

    [Tooltip("The default value for the vibe.")]
    [SerializeField]
    private float defaultValue = 0.0f;

    [Tooltip("The following vibes are reset to default when this vibe is applied.")]
    [SerializeField]
    private Vibe[] applicationResetVibes = null;

    /// <summary>
    /// The default value for the vibe.
    /// </summary>
    public float DefaultValue { get { return defaultValue; } }

    /// <summary>
    /// The icon for this vibe.
    /// </summary>
    public Sprite Icon { get { return icon; } }

    /// <summary>
    /// The following vibes are reset to default when this vibe is applied.
    /// </summary>
    public Vibe[] ApplicationResetVibes { get { return applicationResetVibes; } }
}