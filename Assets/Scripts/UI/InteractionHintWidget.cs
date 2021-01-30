using UnityEngine;
using UnityEngine.UI;

public class InteractionHintWidget : MonoBehaviour
{
    [Tooltip("The text used to display interaction hints.")]
    [SerializeField]
    private Text interactionHintText = null;

    /// <summary>
    /// The attached <see cref="UIWidget"/>.
    /// </summary>
    private UIWidget widget = null;

    /// <summary>
    /// The owners <see cref="InteractionController"/>.
    /// </summary>
    private InteractionController interactionController = null;

    /// <summary>
    /// The current interactable we are displaying text for.
    /// </summary>
    private IInteractable currentInteractable = null;

    private void Awake()
    {
        widget = GetComponent<UIWidget>();
    }

    private void Start()
    {
        if (widget.Owner != null)
        {
            interactionController = widget.Owner.GetComponent<InteractionController>();
            interactionController.EventNewTargetInteractable += OnNewTargetInteractable;

            EquipmentController equipmentController = widget.Owner.GetComponent<EquipmentController>();
            if(equipmentController != null)
            {
                equipmentController.EventEquippedItem += OnEquippedItemChange;
            }
        }

        interactionHintText.text = "";
    }

    private void OnNewTargetInteractable(InteractionController instigator, IInteractable interactable)
    {
        currentInteractable = interactable;
        RefreshInteractionText();
       
    }

    private void OnEquippedItemChange(ItemType item)
    {
        RefreshInteractionText();
    }

    private void RefreshInteractionText()
    {
        if (currentInteractable != null)
        {
            interactionHintText.text = currentInteractable.GetInteractionText(interactionController);
            return;
        }

        interactionHintText.text = "";
    }
}
