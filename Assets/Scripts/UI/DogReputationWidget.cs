using UnityEngine;
using UnityEngine.UI;

public class DogReputationWidget : MonoBehaviour
{
    [Header("Colours")]
    [Tooltip("The foreground color for good reputation.")]
    [SerializeField]
    private Color goodColorForeground = Color.green;

    [Tooltip("The background color for good reputation.")]
    [SerializeField]
    private Color goodColorBackground = Color.green;

    [Tooltip("The foreground color for neutral reputation.")]
    [SerializeField]
    private Color neutralColorForeground = Color.white;

    [Tooltip("The background color for neutral reputation.")]
    [SerializeField]
    private Color neutralColorBackground = Color.white;

    [Tooltip("The foreground color for bad reputation.")]
    [SerializeField]
    private Color badColorForeground = Color.red;

    [Tooltip("The background color for bad reputation.")]
    [SerializeField]
    private Color badColorBackground = Color.red;

    [Header("Sprites")]
    [Tooltip("The regular dog icon.")]
    [SerializeField]
    private Sprite defaultDogIcon = null;

    [Tooltip("The bad dog icon.")]
    [SerializeField]
    private Sprite badDogIcon = null;

    [Header("Components")]
    [Tooltip("The foreground slider image.")]
    [SerializeField]
    private Image sliderFillImage = null;

    [Tooltip("The slider background image.")]
    [SerializeField]
    private Image sliderBackgroundImage = null;

    [Tooltip("The image that displays the dog icon.")]
    [SerializeField]
    private Image dogIconImage = null;

    [Tooltip("The slider that displays reputation value.")]
    [SerializeField]
    private Slider slider = null;

    /// <summary>
    /// The attached <see cref="UIWidget"/>.
    /// </summary>
    private UIWidget widget = null;

    /// <summary>
    /// The <see cref="PlayerReputation"/> intended to be attached to the widget
    /// owner.
    /// </summary>
    private PlayerReputation reputation = null;

    private void Awake()
    {
        widget = GetComponent<UIWidget>();
    }

    private void Start()
    {
        reputation = widget.Owner.GetComponent<PlayerReputation>();
        reputation.EventReputationChange += OnReputationChange;
    }

    protected void OnReputationChange(float reputation)
    {
        if(reputation >= 0.0f)
        {
            sliderBackgroundImage.color = Color.Lerp(neutralColorBackground, goodColorBackground, reputation);
            sliderFillImage.color = Color.Lerp(neutralColorForeground, goodColorForeground, reputation);
        }
        else
        {
            float temp = reputation * -1.0f;
            sliderBackgroundImage.color = Color.Lerp(neutralColorBackground, badColorBackground, temp);
            sliderFillImage.color = Color.Lerp(neutralColorForeground, badColorForeground, temp);
        }

        // Reputation ranges between [-1.0, 1.0], scale this to [0.0, 1.0] for the slider.
        float sliderValue = (reputation + 1.0f) / 2.0f;
        slider.value = sliderValue;

        dogIconImage.sprite = (reputation < -0.5f) ? badDogIcon : defaultDogIcon;
    }
}
