using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SetInteractionLayerAtRuntime : MonoBehaviour
{
    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable;

    private void Awake()
    {
        grabInteractable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();

        // Assign the interaction layer by name
        grabInteractable.interactionLayers =
            InteractionLayerMask.GetMask("BatterySlot");
    }
}