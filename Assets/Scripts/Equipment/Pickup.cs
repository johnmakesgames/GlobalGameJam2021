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

    public delegate void ItemPickedUp(ItemType itemType);
    public static event ItemPickedUp OnItemPickedUp;

    private void Update()
    {
        if(pickupVisual != null)
        {
            Vector3 currentPosition = pickupVisual.transform.position;
            currentPosition.y = verticalBobOffset + (Mathf.Sin(Time.time * verticalBobSpeed) * verticalBobScalar);

            pickupVisual.transform.position = currentPosition;
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

        OnItemPickedUp(itemType);

        Destroy(gameObject);
    }
}