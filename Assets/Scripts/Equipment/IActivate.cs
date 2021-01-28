public interface IActivate
{
    /// <summary>
    /// Override to implement functionality that occurs when the object is
    /// activated.
    /// </summary>
    /// <param name="controller">The <see cref="EquipmentController"/> that
    /// instigated activation.</param>
    public void Activate(EquipmentController controller);
}
