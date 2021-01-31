using UnityEngine;

/// <summary>
/// A <see cref="Pickup"/> represents an <see cref="ItemType"/> that
/// is physically present in the world and can be picked up by the player.
/// </summary>
public class Pickup : MonoBehaviour
{
    [Tooltip("The item represented by this pickup.")]
    [SerializeField]
    private ItemType itemType = null;

    [Header("Bobbing")]
    [Tooltip("The child game object containing the visuals for the pickup.")]
    [SerializeField]
    private GameObject pickupVisual = null;

    [Tooltip("Offset to the height of the vertical bobbing.")]
    [SerializeField]
    private float verticalBobOffset = 0.5f;

    [Tooltip("Scalar value applied to the bobbing sin calculation.")]
    [SerializeField]
    private float verticalBobScalar = 0.1f;

    [Tooltip("The speed multiplier for the vertical bobbing.")]
    [SerializeField]
    private float verticalBobSpeed = 1.0f;

    [Tooltip("The spin speed of the item")]
    [SerializeField]
    private float spinSpeed = 0;

    [Tooltip("The axis to rotate the item on")]
    [SerializeField]
    private Vector3 rotationAxis = new Vector3(0, 1, 0);

    public delegate void ItemPickedUp(ItemType itemType);
    public static event ItemPickedUp OnItemPickedUp;

    private void Update()
    {
        if(pickupVisual != null)
        {
            pickupVisual.transform.Translate(new Vector3(0.0f, Mathf.Sin(Time.time) * verticalBobScalar * Time.deltaTime/*verticalBobOffset + (Mathf.Sin(Time.time * verticalBobSpeed) * verticalBobScalar*//*)*/, 0.0f));
            pickupVisual.transform.Rotate(rotationAxis, spinSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Pickup expects the player equipment controller.
        EquipmentController equipmentController = other.gameObject.GetComponent<EquipmentController>();
        if(equipmentController != null)
        {
            equipmentController.AddItemToInventory(itemType);
        }

        OnItemPickedUp?.Invoke(itemType);
        Destroy(gameObject);
    }
}