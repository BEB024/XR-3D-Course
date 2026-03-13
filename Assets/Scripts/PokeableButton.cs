using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class PokeableButton : MonoBehaviour
{
    private XRSimpleInteractable _simpleInteractable;

    [Header("Target Settings")]
    [SerializeField] private XRGrabInteractable objectToEnable; // The item that becomes grabbable

    private void Awake()
    {
        _simpleInteractable = GetComponent<XRSimpleInteractable>();

        // Ensure the target object starts disabled or non-interactable
        if (objectToEnable != null)
        {
            objectToEnable.enabled = false;
        }
    }

    private void OnButtonPressed(SelectEnterEventArgs args)
    {
        Debug.Log("Button Poke Detected: Enabling Grab Interactable");

        if (objectToEnable != null)
        {
            objectToEnable.enabled = true; // Now the player can grab the hidden item
        }
    }

    private void OnEnable()
    {
        // Subscribe to the press event
        _simpleInteractable.selectEntered.AddListener(OnButtonPressed);
    }

    private void OnDisable()
    {
        // Unsubscribe to keep the project clean
        _simpleInteractable.selectEntered.RemoveListener(OnButtonPressed);
    }

    // private void OnButtonPressed(SelectEnterEventArgs args)
    // {
    //     if (objectToEnable != null)
    //     {
    //         objectToEnable.enabled = true;
    //         Debug.Log($"{objectToEnable.name} is now grabbable!");

    //         _simpleInteractable.selectEntered.RemoveListener(OnButtonPressed); // Unsubscribe after unlocking the drawer
    //     }
    // }
    
}