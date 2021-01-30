using UnityEngine;
using UnityEngine.UI;

public class TraderWidget : MonoBehaviour
{
    [Tooltip("The image component that displays the trade item icon.")]
    [SerializeField]
    private Image tradeItemIconImage = null;

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
        if (widget.Owner != null)
        {
            // Setup the icon for the trading item.
            Trading trading = widget.Owner.GetComponent<Trading>();
            tradeItemIconImage.sprite = trading.WantedItem.Icon;

            // Listen for trade completion.
            trading.EventTradeComplete += OnTradeComplete;
        }
    }

    private void OnTradeComplete()
    {
        Destroy(gameObject);
    }
}
