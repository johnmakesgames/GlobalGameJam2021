using UnityEngine;

/// <summary>
/// The <see cref="EquipmentController"/> manages the items in the players inventory
/// and implements the ability to equip and activate each item.
/// </summary>
public class EquipmentController : MonoBehaviour
{
    /// <summary>
    /// The maximum number of <see cref="ItemType"/>s that can fit into the 
    /// inventory.
    /// </summary>
    public static int MAXIMUM_INVENTORY_SIZE = 32;

    /// <summary>
    /// Represents an invalid inventory item index.
    /// </summary>
    public static int INVALID_ITEM = -1;

    [Tooltip("Should the first item that is added into the inventory be equipped automatically?")]
    [SerializeField]
    private bool autoEquipFirstItem = true;

    [Tooltip("Should subsequent items that are added into the inventory be equipped automatically?")]
    [SerializeField]
    private bool autoEquipSubsequentItems = false;

    [Tooltip("The transform to which instantiated equipment is attached.")]
    [SerializeField]
    private Transform equippedItemAnchor = null;

    /// <summary>
    /// The items making up the player's inventory.
    /// </summary>
    private ItemType[] inventoryItems = new ItemType[MAXIMUM_INVENTORY_SIZE];

    /// <summary>
    /// The index of the item that is currently equipped.
    /// </summary>
    private int equippedItemIndex = INVALID_ITEM;

    /// <summary>
    /// The next available index into the inventory array. This implementation assumes
    /// items cannot be removed from the inventory and this value will simply count up.
    /// </summary>
    private int nextFreeIndex = 0;

    /// <summary>
    /// The number of items within the inventory.
    /// </summary>
    private int itemCount = 0;

    /// <summary>
    /// The <see cref="Equipment"/> that is currently equipped.
    /// </summary>
    private Equipment equippedItem = null;

    /// <summary>
    /// Adds the provided <see cref="ItemType"/> to the inventory.
    /// </summary>
    /// <param name="item">The item that will be added.</param>
    public void AddItemToInventory(ItemType item)
    {
        if(item == null)
        {
            Debug.LogWarning("Failed to add item to inventory, item is null.");
            return;
        }

        if(!IsValidInventoryIndex(nextFreeIndex))
        {
            Debug.LogError("Failed to add item to inventory, nextFreeIndex is out-of-bounds.");
            return;
        }

        // Add the item to the inventory.
        inventoryItems[nextFreeIndex] = item;

        // Auto item equipping.
        if((itemCount == 0) && autoEquipFirstItem)
        {
            EquipItemAtIndex(nextFreeIndex);
        }
        else if(autoEquipSubsequentItems)
        {
            EquipItemAtIndex(nextFreeIndex);
        }

        // Ready for next item.
        ++nextFreeIndex;

        Debug.Log("Item '" + item.DisplayName + "' was added to the inventory.");
    }

    /// <summary>
    /// Instantiates and equips the <see cref="Equipment"/> for the <see cref="ItemType"/>
    /// at a provided index within the inventory.
    /// </summary>
    /// <param name="index">Index for the target item.</param>
    public void EquipItemAtIndex(int index)
    {
        if(!IsValidInventoryIndex(index))
        {
            Debug.LogError("Failed to equip item at index " + index + ", index out-of-bounds.");
            return;
        }

        UnequipCurrentEquipment();

        // Find the item to equip.
        ItemType itemToEquip = inventoryItems[index];

        // Invalid item.
        if(itemToEquip == null) 
        {
            Debug.LogWarning("Failed to equip item, item at index is null");
            return;
        }

        if(itemToEquip.EquipmentPrefab == null)
        {
            Debug.LogWarning("Failed to equip '" + itemToEquip.name + "', missing equipment prefab.");
            return;
        }

        // Create the new equipment and find the equipment interfaces it may have.
        equippedItem = Instantiate(itemToEquip.EquipmentPrefab, equippedItemAnchor);
        if(equippedItem != null)
        {
            equippedItem.Equip();

            // #TODO_Equipment: interface finding.

            equippedItemIndex = index;
        }
    }

    /// <summary>
    /// Unequips and destroys the currently equipped <see cref="Equipment"/>.
    /// </summary>
    private void UnequipCurrentEquipment()
    {
        if(equippedItem != null)
        {
            equippedItem.Unequip();

            // Destroy the equipped item and clean up interface references.
            Destroy(equippedItem.gameObject);
            equippedItem = null;

            equippedItemIndex = INVALID_ITEM;
        }
    }

    /// <summary>
    /// Checks an inventory item index is within array bounds.
    /// </summary>
    /// <param name="index">Index to check.</param>
    private bool IsValidInventoryIndex(int index)
    {
        return (index >= 0) && (index < inventoryItems.Length) && (index < MAXIMUM_INVENTORY_SIZE);
    }
}