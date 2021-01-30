using UnityEngine;

public class UIWidget : MonoBehaviour
{
    /// <summary>
    /// The logical owner of this widget (likely the player object).
    /// </summary>
    public GameObject Owner { get; private set; }

    public virtual void InitializeWidget(GameObject owner)
    {
        Owner = owner;
    }
}
