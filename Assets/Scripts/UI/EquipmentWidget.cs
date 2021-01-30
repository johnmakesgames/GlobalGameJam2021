using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(UIWidget))]
public class EquipmentWidget : MonoBehaviour
{
    [Tooltip("The image component displaying the equipped item.")]
    [SerializeField]
    private Image equippedItemImage = null;

    [Tooltip("The image component displaying the next item.")]
    [SerializeField]
    private Image nextItemImage = null;

    [Tooltip("The image component displaying the previous item.")]
    [SerializeField]
    private Image previousItemImage = null;

    /// <summary>
    /// The attached <see cref="UIWidget"/>.
    /// </summary>
    private UIWidget widget = null;

    /// <summary>
    /// Reference to the <see cref="EquipmentController"/>.
    /// </summary>
    private EquipmentController equipmentController = null;

    /// <summary>
    /// The <see cref="ItemType"/> displayed in the current item slot.
    /// </summary>
    private ItemType currentItemType = null;

    private void Awake()
    {
        widget = GetComponent<UIWidget>();
    }

    private void Start()
    {
        // Look for the equipment controller so we can listen for updates.
        if(widget.Owner != null)
        {
            equipmentController = widget.Owner.GetComponent<EquipmentController>();
            if(equipmentController != null)
            {
                equipmentController.EventEquippedItem += OnInventoryStatusUpdate;
                equipmentController.EventItemAddedToInventory += OnInventoryStatusUpdate;
            }
        }
    }

    private void OnInventoryStatusUpdate(ItemType item)
    {
        // Get the currently equipped item.
        currentItemType = equipmentController.GetEquippedItem();

        // This function executes when items are added so there might not be one equipped here yet.
        if (currentItemType != null)
        {         
            // Update image for current item.
            equippedItemImage.enabled = true;
            equippedItemImage.sprite = currentItemType.Icon;
        }

        // Next item (when switching up).
        ItemType nextItem = equipmentController.GetNextItem();
        nextItemImage.enabled = false;
        if ((nextItem != null) && (nextItem.Icon != null) && (currentItemType != nextItem))
        {
            nextItemImage.enabled = true;
            nextItemImage.sprite = nextItem.Icon;
        }

        // Previous item (when switching down).
        ItemType previousItem = equipmentController.GetPreviousItem();
        previousItemImage.enabled = false;
        if ((previousItem != null) && (previousItem.Icon != null) && (currentItemType != previousItem))
        {
            previousItemImage.enabled = true;
            previousItemImage.sprite = previousItem.Icon;
        }
    }
}
