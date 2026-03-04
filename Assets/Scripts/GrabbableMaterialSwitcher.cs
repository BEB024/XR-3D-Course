using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit; // Access XRI classes
using UnityEngine.XR.Interaction.Toolkit.Interactables; 
// Required for XR Interaction classes

public class GrabbableMaterialSwitcher : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    private MeshRenderer meshRenderer;

    [Header("Material Settings")]
    // Drag Blue or Black material here
    [SerializeField] private Material grabMaterial;

    // Drag New (Red/Yellow/White) material here
    [SerializeField] private Material defaultMaterial;

    private void Awake()
    {
        // Find components on the same GameObject
        grabInteractable = GetComponent<XRGrabInteractable>();
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Changes the material to the 'Grab' version
    private void SetGrabMaterial(SelectEnterEventArgs args)
    {
        meshRenderer.material = grabMaterial;
    }

    // Reverts the material to the 'Default' version
    private void SetDefaultMaterial(SelectExitEventArgs args)
    {
        meshRenderer.material = defaultMaterial;
    }

    private void OnEnable()
    {
        // Connects the functions to the XR Events
        grabInteractable.selectEntered.AddListener(SetGrabMaterial);
        grabInteractable.selectExited.AddListener(SetDefaultMaterial);
    }

    private void OnDisable()
    {
        // Disconnects the functions when the object is disabled or destroyed
        grabInteractable.selectEntered.RemoveListener(SetGrabMaterial);
        grabInteractable.selectExited.RemoveListener(SetDefaultMaterial);
    }
}