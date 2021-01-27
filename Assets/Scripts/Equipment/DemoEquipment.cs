using UnityEngine;

/// <summary>
/// Demonstrates how to setup a new type of <see cref="Equipment"/>.
/// </summary>
public class DemoEquipment : Equipment, IActivate
{
    public void Activate(EquipmentController controller)
    {
        Debug.Log("Demo Equipment was activated.");

        transform.localScale += Vector3.one * 0.1f;
    }

    protected override void OnEquipped()
    {
        base.OnEquipped();

        Debug.Log("Demo Equipment was equipped.");
    }

    protected override void OnUnequipped()
    {
        base.OnUnequipped();

        Debug.Log("Demo Equipment was unequipped.");
    }
}