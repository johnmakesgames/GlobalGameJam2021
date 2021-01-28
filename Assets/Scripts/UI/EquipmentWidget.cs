using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(UIWidget))]
public class EquipmentWidget : MonoBehaviour
{
    [Tooltip("The image component displaying the equipped item.")]
    [SerializeField]
    private Image equippedItemImage = null;

    /// <summary>
    /// The attached <see cref="UIWidget"/>.
    /// </summary>
    private UIWidget widget = null;

    private void Awake()
    {
        widget = GetComponent<UIWidget>();
    }

    private void Start()
    {
        // Look for the equipment controller so we can listen for updates.
        if(widget.Owner != null)
        {
            EquipmentController equipmentController = widget.Owner.GetComponent<EquipmentController>();
            if(equipmentController != null)
            {
                equipmentController.EventEquippedItem += OnItemEquipped;
            }
        }
    }

    private void OnItemEquipped(ItemType item)
    {
        equippedItemImage.enabled = true;
        equippedItemImage.sprite = item.Icon;
    }
}
