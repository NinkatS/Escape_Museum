/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pen : MonoBehaviour
{
    [Header("Pen Properties")]
    public Transform tip;
    public Material drawingMaterial;
    public Material tipMaterial;
    [Range(0.01f, 0.1f)]
    public float penWidth = 0.01f;
    public Color[] penColors;

    [Header("Hands & Grabbable")]
    public OVRGrabber rightHand;
    public OVRGrabber leftHand;
    public OVRGrabbable grabbable;

    private LineRenderer currentDrawing;
    private int index;
    private int currentColorIndex;

    private void Start()
    {
        currentColorIndex = 0;
        tipMaterial.color = penColors[currentColorIndex];
    }

    private void Update()
    {
        bool isGrabbed = grabbable.isGrabbed;
        bool isRightHandDrawing = isGrabbed && grabbable.grabbedBy == rightHand && OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger);
        bool isLeftHandDrawing = isGrabbed && grabbable.grabbedBy == leftHand && OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger);
        if (isRightHandDrawing || isLeftHandDrawing)
        {
            Draw();
        }
        else if (currentDrawing != null)
        {
            currentDrawing = null;
        }
        else if (OVRInput.GetDown(OVRInput.Button.One))
        {
            SwitchColor();
        }
    }

    private void Draw()
    {
        if (currentDrawing == null)
        {
            index = 0;
            currentDrawing = new GameObject().AddComponent<LineRenderer>();
            currentDrawing.material = drawingMaterial;
            currentDrawing.startColor = currentDrawing.endColor = penColors[currentColorIndex];
            currentDrawing.startWidth = currentDrawing.endWidth = penWidth;
            currentDrawing.positionCount = 1;
            currentDrawing.SetPosition(0, tip.position);
        }
        else
        {
            var currentPos = currentDrawing.GetPosition(index);
            if (Vector3.Distance(currentPos, tip.position) > 0.01f)
            {
                index++;
                currentDrawing.positionCount = index + 1;
                currentDrawing.SetPosition(index, tip.position);
            }
        }
    }

    private void SwitchColor()
    {
        if (currentColorIndex == penColors.Length - 1)
        {
            currentColorIndex = 0;
        }
        else
        {
            currentColorIndex++;
        }
        tipMaterial.color = penColors[currentColorIndex];
    }
}
*/

/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pen : MonoBehaviour
{
    [Header("Pen Properties")]
    public Transform tip;
    public Material drawingMaterial;
    public Material tipMaterial;
    [Range(0.01f, 0.1f)]
    public float penWidth = 0.01f;
    public Color[] penColors;

    [Header("Hands & Grabbable")]
    public Transform rightHand; // Reference to right virtual hand's transform
    public Transform leftHand; // Reference to left virtual hand's transform
    public float grabDistance = 0.05f; // Max distance to consider pen as "grabbed"

    private LineRenderer currentDrawing;
    private int index;
    private int currentColorIndex;
    private bool isGrabbed;

    private void Start()
    {
        currentColorIndex = 0;
        tipMaterial.color = penColors[currentColorIndex];
        isGrabbed = false;
    }

    private void Update()
    {
        // Check if either hand is grabbing the pen
        bool rightHandNear = Vector3.Distance(rightHand.position, transform.position) <= grabDistance;
        bool leftHandNear = Vector3.Distance(leftHand.position, transform.position) <= grabDistance;
        bool isRightHandDrawing = rightHandNear && OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger);
        bool isLeftHandDrawing = leftHandNear && OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger);

        // Start drawing if the pen is grabbed and the index trigger is pressed
        if (isRightHandDrawing || isLeftHandDrawing)
        {
            isGrabbed = true;
            Draw();
        }
        else
        {
            isGrabbed = false;
            currentDrawing = null;
        }

        // Switch color when "Button.One" is pressed (typically A or X on the controller)
        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            SwitchColor();
        }
    }

    private void Draw()
    {
        if (currentDrawing == null)
        {
            index = 0;
            currentDrawing = new GameObject("LineDrawing").AddComponent<LineRenderer>();
            currentDrawing.material = drawingMaterial;
            currentDrawing.startColor = currentDrawing.endColor = penColors[currentColorIndex];
            currentDrawing.startWidth = currentDrawing.endWidth = penWidth;
            currentDrawing.positionCount = 1;
            currentDrawing.SetPosition(0, tip.position);
        }
        else
        {
            Vector3 currentPos = currentDrawing.GetPosition(index);
            if (Vector3.Distance(currentPos, tip.position) > 0.01f)
            {
                index++;
                currentDrawing.positionCount = index + 1;
                currentDrawing.SetPosition(index, tip.position);
            }
        }
    }

    private void SwitchColor()
    {
        if (penColors.Length == 0) return;

        currentColorIndex = (currentColorIndex + 1) % penColors.Length;
        tipMaterial.color = penColors[currentColorIndex];
    }
}
*/


/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pen : MonoBehaviour
{
    [Header("Pen Properties")]
    public Transform tip;
    public Material drawingMaterial;
    public Material tipMaterial;
    [Range(0.01f, 0.1f)]
    public float penWidth = 0.01f;
    public Color[] penColors;

    [Header("Drawing Surface")]
    public GameObject canvasBox; // Reference to the specific object you want to draw on

    [Header("Hands")]
    public Transform rightHand;
    public Transform leftHand;
    public float grabDistance = 0.05f;

    private LineRenderer currentDrawing;
    private int index;
    private int currentColorIndex;
    private bool isGrabbed;

    private void Start()
    {
        currentColorIndex = 0;
        tipMaterial.color = penColors[currentColorIndex];
        isGrabbed = false;
    }

    private void Update()
    {
        bool rightHandNear = Vector3.Distance(rightHand.position, transform.position) <= grabDistance;
        bool leftHandNear = Vector3.Distance(leftHand.position, transform.position) <= grabDistance;
        bool isRightHandDrawing = rightHandNear && OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger);
        bool isLeftHandDrawing = leftHandNear && OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger);

        if (isRightHandDrawing || isLeftHandDrawing)
        {
            isGrabbed = true;
            Draw();
        }
        else
        {
            isGrabbed = false;
            currentDrawing = null;
        }

        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            SwitchColor();
        }
    }

    private void Draw()
    {
        RaycastHit hit;
        // Cast a ray from the pen tip to check if it's touching canvasBox
        if (Physics.Raycast(tip.position, -tip.up, out hit, 0.1f))
        {
            // Check if the hit object is the canvasBox
            if (hit.collider.gameObject == canvasBox)
            {
                if (currentDrawing == null)
                {
                    index = 0;
                    currentDrawing = new GameObject("SurfaceDrawing").AddComponent<LineRenderer>();
                    currentDrawing.material = drawingMaterial;
                    currentDrawing.startColor = currentDrawing.endColor = penColors[currentColorIndex];
                    currentDrawing.startWidth = currentDrawing.endWidth = penWidth;
                    currentDrawing.positionCount = 1;
                    currentDrawing.SetPosition(0, hit.point);
                }
                else
                {
                    var currentPos = currentDrawing.GetPosition(index);
                    if (Vector3.Distance(currentPos, hit.point) > 0.01f)
                    {
                        index++;
                        currentDrawing.positionCount = index + 1;
                        currentDrawing.SetPosition(index, hit.point);
                    }
                }
            }
        }
    }

    private void SwitchColor()
    {
        if (penColors.Length == 0) return;

        currentColorIndex = (currentColorIndex + 1) % penColors.Length;
        tipMaterial.color = penColors[currentColorIndex];
    }
}
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pen : MonoBehaviour
{
    [Header("Pen Properties")]
    public Transform tip;
    public Material drawingMaterial;
    public Material tipMaterial;
    [Range(0.01f, 0.1f)]
    public float penWidth = 0.015f;
    public Color[] penColors;

    public Transform rightHand;
    public Transform leftHand;
    public float grabDistance = 0.05f;

    [Header("Drawing Surface")]
    //public GameObject canvasBox; // Reference to the specific object you want to draw on

    public float offsetDistance = 0.001f;
    private LineRenderer currentDrawing;
    private int index;
    private int currentColorIndex;

    private void Start()
    {
        currentColorIndex = 0;
        tipMaterial.color = penColors[currentColorIndex];
    }

    private void Update()
    {
        bool rightHandNear = Vector3.Distance(rightHand.position, transform.position) <= grabDistance;
        bool leftHandNear = Vector3.Distance(leftHand.position, transform.position) <= grabDistance;
        //bool isRightHandDrawing = rightHandNear && OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger);
        //bool isLeftHandDrawing = leftHandNear && OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger);

        
        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            SwitchColor();
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        // Start drawing if the pen touches the canvasBox
        if (other.gameObject.name == "canvasBox")
        {
            StartDrawing();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        // Continue drawing as long as the pen stays on the canvasBox
        if (other.gameObject.name == "canvasBox")
        {
            Draw();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Stop drawing when the pen leaves the canvasBox
        if (other.gameObject.name == "canvasBox")
        {
            currentDrawing = null;
        }
    }

    private void StartDrawing()
    {
        GameObject door = GameObject.Find("openingDoor");
        if (door != null)
        {
            door.SetActive(false);
        }

        // Initialize a new LineRenderer when starting to draw
        index = 0;
        currentDrawing = new GameObject("SurfaceDrawing").AddComponent<LineRenderer>();
        currentDrawing.material = drawingMaterial;
        currentDrawing.startColor = currentDrawing.endColor = penColors[currentColorIndex];
        currentDrawing.startWidth = currentDrawing.endWidth = penWidth;
        currentDrawing.positionCount = 1;
        currentDrawing.SetPosition(0, tip.position);
    }

    private void Draw()
    {
        if (currentDrawing != null)
        {
            var currentPos = currentDrawing.GetPosition(index);
            if (Vector3.Distance(currentPos, tip.position) > 0.01f)
            {
                index++;
                currentDrawing.positionCount = index + 1;
                currentDrawing.SetPosition(index, tip.position);
            }
        }
    }

    private void SwitchColor()
    {
        if (penColors.Length == 0) return;

        currentColorIndex = (currentColorIndex + 1) % penColors.Length;
        tipMaterial.color = penColors[currentColorIndex];
    }
}
