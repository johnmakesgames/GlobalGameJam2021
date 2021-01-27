using UnityEngine;

/// <summary>
/// <see cref="ItemType"/> describes the data and prefabs required
/// for a single item.
/// </summary>
public class ItemType : ScriptableObject
{
    [Tooltip("In-game name for the item.")]
    [SerializeField]
    private string displayName = "";

    [Tooltip("Prefab for the item's equipment game object.")]
    [SerializeField]
    private Equipment equipmentPrefab = null;

    [Tooltip("Prefab for the item's pickup game object.")]
    [SerializeField]
    private Pickup pickupPrefab = null;

    /// <summary>
    /// In-game name for the item.
    /// </summary>
    public string DisplayName { get { return displayName; } }

    /// <summary>
    /// Prefab for the item's equipment game object.
    /// </summary>
    public Equipment EquipmentPrefab { get { return equipmentPrefab; } }

    /// <summary>
    /// Prefab for the item's pickup game object.
    /// </summary>
    public Pickup PickupPrefab { get { return pickupPrefab; } }
}
