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

    private void OnTriggerEnter(Collider other)
    {
        // Pickup expects the player equipment controller.
        EquipmentController equipmentController = other.gameObject.GetComponent<EquipmentController>();
        if(equipmentController != null)
        {
            equipmentController.AddItemToInventory(itemType);
        }

        Destroy(gameObject);
    }
}