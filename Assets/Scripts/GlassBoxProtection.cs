using Oculus.Interaction;
using UnityEngine;

public class GlassBoxProtection : MonoBehaviour
{
    public GameObject button; // Reference to the button inside the glass box
    private Collider buttonCollider;
    private Vector3 initialPosition;
    private bool hasMovedGlassBox = false;

    void Start()
    {
        if (button != null)
        {
            buttonCollider = button.GetComponent<Collider>();

            // Disable the button's collider at the start to prevent pressing
            if (buttonCollider != null)
            {
                buttonCollider.enabled = false;
            }
        }

        // Store the initial position of the glass box to check for movement
        initialPosition = transform.position;
    }

    void Update()
    {
        // Check if the glass box has been moved from its initial position
        if (!hasMovedGlassBox && Vector3.Distance(initialPosition, transform.position) > 0.1f)
        {
            // The glass box has been moved away, enabling the button's collider
            hasMovedGlassBox = true;

            if (buttonCollider != null)
            {
                buttonCollider.enabled = true;
            }
        }
    }
}



/*using UnityEngine;

public class GlassBoxProtection : MonoBehaviour
{
    public GameObject button; // Reference to the button inside the glass box
    private Collider buttonCollider;
    private bool hasMovedGlassBox = false;

    void Start()
    {
        if (button != null)
        {
            buttonCollider = button.GetComponent<Collider>();

            // Disable the button's collider at the start
            if (buttonCollider != null)
            {
                buttonCollider.enabled = false;
            }
        }
    }

    void Update()
    {
        // Check if the glass box has been moved
        if (!hasMovedGlassBox && transform.hasChanged)
        {
            // The glass box has been moved
            hasMovedGlassBox = true;

            // Enable the button's collider to allow pressing
            if (buttonCollider != null)
            {
                buttonCollider.enabled = true;
            }
        }
    }
}
*/