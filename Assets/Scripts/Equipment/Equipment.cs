using UnityEngine;

public abstract class Equipment : MonoBehaviour
{
    public void Equip()
    {
        OnEquipped();
    }

    public void Unequip()
    {
        OnUnequipped();
    }

    protected virtual void OnEquipped()
    {
        // Default implementation has no behavior.
    }

    protected virtual void OnUnequipped()
    {
        // Default implementation has no behavior.
    }
}