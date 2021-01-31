using UnityEngine;

/// <summary>
/// Allows an <see cref="CreatureAIController"/> to hold and drop
/// an item.
/// </summary>
[RequireComponent(typeof(CreatureAIController))]
public class AIHeldItem : MonoBehaviour
{
    [Tooltip("The item held by this AI.")]
    [SerializeField]
    private ItemType heldItem = null;

    [Tooltip("The anchor on the AI on which the held item is spawned.")]
    [SerializeField]
    private Transform heldItemAnchor = null;

    [Tooltip("Transform that represents the spawn point for the pickup.")]
    [SerializeField]
    private Transform pickupSpawn = null;

    /// <summary>
    /// The object that represents the item in the world.
    /// </summary>
    private GameObject heldItemInstance = null;

    /// <summary>
    /// Is the AI still holding the item?
    /// </summary>
    public bool IsHoldingItem { get; private set; } = false;

    private void Awake()
    {
        SpawnHeldItem();   
    }

    public void DropHeldItem()
    {
        if(IsHoldingItem)
        {
            // Instantiate the pickup prefab for our held item.
            Pickup pickup = Instantiate(heldItem.PickupPrefab);
            pickup.transform.position = pickupSpawn.position;

            // Destroy the held item.
            Destroy(heldItemInstance);

            // No longer holding anything.
            IsHoldingItem = false;
        }
    }

    private void SpawnHeldItem()
    {
        if (heldItem != null)
        {
            if (heldItem.HeldItemPrefab == null)
            {
                Debug.LogWarning("The item type assigned for an AI to hold has no held item prefab.");
                return;
            }

            // Spawn the held item.
            heldItemInstance = Instantiate(heldItem.HeldItemPrefab, heldItemAnchor);
            IsHoldingItem = true;
        }
    }
}
