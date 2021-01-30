using UnityEngine;

public class Trading : MonoBehaviour, IInteractable
{
    /// <summary>
    /// Broadcast when the trade is completed.
    /// </summary>
    public System.Action EventTradeComplete = null;

    [Tooltip("The item wanted by this trader.")]
    [SerializeField]
    private ItemType wantedItem = null;

    [Tooltip("The item given by this trader.")]
    [SerializeField]
    private ItemType givenItem = null;

    [Header("UI")]
    [Tooltip("The prefab for the trading UI widget.")]
    [SerializeField]
    private UIWidget tradingWidgetPrefab = null;

    [Tooltip("The transform used as a parent for the trading UI widget.")]
    [SerializeField]
    private Transform tradingWidgetParent = null;

    [Header("Vibes")]
    [Tooltip("Required reference to the anger vibe.")]
    [SerializeField]
    private Vibe angerVibe = null;

    [Tooltip("Required reference to the happy vibe.")]
    [SerializeField]
    private Vibe happyVibe = null;

    /// <summary>
    /// Has the trade been completed?
    /// </summary>
    public bool IsTradeComplete { get; private set; } = false;

    /// <summary>
    /// The attached <see cref="VibeMessageHandler"/> component.
    /// </summary>
    private VibeMessageHandler vibeMessageHandler = null;

    /// <summary>
    /// The <see cref="ItemType"/> wanted by this trader.
    /// </summary>
    public ItemType WantedItem { get { return wantedItem; } }

    private void Awake()
    {
        UIWidgetFactory.SpawnUIWidget(tradingWidgetPrefab, gameObject, tradingWidgetParent);

        vibeMessageHandler = GetComponent<VibeMessageHandler>();
    }

    public string GetInteractionText(InteractionController instigator)
    {
        EquipmentController equipmentController = instigator.GetComponent<EquipmentController>();
        if(equipmentController != null)
        {
            ItemType equippedItem = equipmentController.GetEquippedItem();
            if(equippedItem != null)
            {
                return $"Offer {equippedItem.DisplayName}";
            }

            return "No item to offer";
        }

        return "";
    }

    public bool IsInteractionAllowed(InteractionController controller)
    {
        return !IsTradeComplete;
    }

    public void Interact(InteractionController instigator)
    {
        if(instigator != null)
        {
            EquipmentController equipmentController = instigator.GetComponent<EquipmentController>();
            if(equipmentController != null)
            {
                ItemType equippedItem = equipmentController.GetEquippedItem();
                if(equippedItem != null)
                {
                    // Correct item!.
                    if(equippedItem == wantedItem)
                    {
                        vibeMessageHandler.VibeMessage(happyVibe, float.MaxValue, true);
                        IsTradeComplete = true;

                        // Let the listeners know the trade is complete.
                        EventTradeComplete?.Invoke();
                    }

                    // Incorrect item.
                    else
                    {
                        vibeMessageHandler.VibeMessage(angerVibe, 0.01f, true);
                    }
                }
            }
        }
    }   
}