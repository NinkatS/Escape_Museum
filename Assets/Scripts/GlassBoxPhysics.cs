using Oculus.Interaction;
using UnityEngine;


public class GlassBoxPhysics : MonoBehaviour
{
    /*private Rigidbody rb;
    private XRGrabInteractable grabInteractable;

    void Start()
    {
        // Get the Rigidbody component and set initial properties
        rb = GetComponent<Rigidbody>();
        grabInteractable = GetComponent<XRGrabInteractable>();

        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>(); // Add Rigidbody if not already attached
        }

        rb.useGravity = false; // Start with gravity disabled
        rb.isKinematic = true; // Make it kinematic while it's in the initial position

        // Register events for grab and release actions
        grabInteractable.selectEntered.AddListener(OnGrab);
        grabInteractable.selectExited.AddListener(OnRelease);
    }

    // This method is called when the glass box is grabbed
    private void OnGrab(SelectEnterEventArgs args)
    {
        rb.useGravity = false; // Disable gravity while grabbing
        rb.isKinematic = true; // Make it kinematic while holding
    }

    // This method is called when the glass box is released
    private void OnRelease(SelectExitEventArgs args)
    {
        rb.useGravity = true; // Re-enable gravity
        rb.isKinematic = false; // Make it non-kinematic so it falls naturally
    }

    void OnDestroy()
    {
        // Unregister events to avoid potential memory leaks
        grabInteractable.selectEntered.RemoveListener(OnGrab);
        grabInteractable.selectExited.RemoveListener(OnRelease);
    }*/
}
