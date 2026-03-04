using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class InteractionHandler : MonoBehaviour
{
    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable;

    private void Awake()
    {
        // Get the component on this object
        grabInteractable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
    }

    private void OnEnable()
    {
        // SUBSCRIBE to the events when the object is active
        grabInteractable.hoverEntered.AddListener(HandleHoverEnter);
        grabInteractable.selectEntered.AddListener(HandleGrab);
    }

    private void OnDisable()
    {
        // UNSUBSCRIBE when the object is disabled or destroyed
        // Use RemoveListener to prevent memory leaks!
        grabInteractable.hoverEntered.RemoveListener(HandleHoverEnter);
        grabInteractable.selectEntered.RemoveListener(HandleGrab);
    }

    private void HandleHoverEnter(HoverEnterEventArgs args)
    {
        Debug.Log("Hovering started via Code Subscription");
    }

    private void HandleGrab(SelectEnterEventArgs args)
    {
        // Access info about WHAT grabbed this object
        Debug.Log("Grabbed by: " + args.interactorObject.transform.name);
    }
}