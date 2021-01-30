using UnityEngine;
using System.Linq;

public class InteractionController : MonoBehaviour
{
    /// <summary>
    /// Broadcast each time a new <see cref="IInteractable"/> is targeted, with null signifying
    /// no interactable targeted.
    /// </summary>
    public System.Action<InteractionController, IInteractable> EventNewTargetInteractable = null;

    [Tooltip("The radius of the sphere cast used to find interactables.")]
    [SerializeField]
    private float sphereCastRadius = 1.0f;

    [Tooltip("The maximum distance of the sphere cast used to find interactables.")]
    [SerializeField]
    private float sphereCastMaxDistance = 5.0f;

    /// <summary>
    /// The currently targeted <see cref="IInteractable"/>.
    /// </summary>
    private IInteractable targetInteractable = null;

    private void Update()
    {
        FindTargetInteractable();
        TryInteract();
    }

    private void FindTargetInteractable()
    {
        // Get hits ordered by distance.
        RaycastHit[] hits = Physics.SphereCastAll(transform.position, sphereCastRadius, transform.forward, sphereCastMaxDistance).OrderBy(x => x.distance).ToArray();

        // Look for interactables within the hits.
        foreach(RaycastHit hit in hits)
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            if((interactable != null) && (interactable.IsInteractionAllowed(this)))
            {
                // Notify listeners there is a new valid interactable.
                if(interactable != targetInteractable)
                {
                    EventNewTargetInteractable?.Invoke(this, interactable);
                }

                // Set the new target.
                targetInteractable = interactable;

                // Early exit.
                return;
            }
        }

        // If we had one last frame, notify listeners it's gone.
        if(targetInteractable != null)
        {
            EventNewTargetInteractable?.Invoke(this, null);
        }

        // No valid interactables found this time.
        targetInteractable = null;
    }

    private void TryInteract()
    {
        if((targetInteractable != null) && Input.GetKeyDown(KeyCode.E))
        {
            targetInteractable.Interact(this);
        }
    }
}