using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ConfigureSocketLayer : MonoBehaviour
{
    private UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor socket;

    private void Awake()
    {
        socket = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor>();

        // Allow only objects in "BatterySlot" layer
        socket.interactionLayers = 
            InteractionLayerMask.GetMask("BatterySlot", "Key", "HeavyObject");
    }
}