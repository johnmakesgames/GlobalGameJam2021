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

    /// <summary>
    /// The default value for the vibe.
    /// </summary>
    public float DefaultValue { get { return defaultValue; } }

    /// <summary>
    /// The icon for this vibe.
    /// </summary>
    public Sprite Icon { get { return icon; } }
}