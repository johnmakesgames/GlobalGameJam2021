public interface IInteractable
{
    /// <summary>
    /// Override to implement interaction behavior.
    /// </summary>
    /// <param name="controller">The <see cref="InteractionController"/> that instigated this
    /// interaction.</param>
    public void Interact(InteractionController controller);

    /// <summary>
    /// Return false to prevent interaction or targeting.
    /// </summary>
    public bool IsInteractionAllowed(InteractionController controller);

    /// <summary>
    /// Override to determine the text prompt for this interaction.
    /// </summary>
    public string GetInteractionText(InteractionController controller);
}