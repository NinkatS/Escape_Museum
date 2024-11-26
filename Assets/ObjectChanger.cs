using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class ObjectChanger : MonoBehaviour
{
    public GameObject Character2;
    //public Transform leftControllerTransform;
    public float moveSpeed = 1f;
    public Color ObjectColor = Color.white;
    private GameObject pointedObject;
    private bool isXPressed = false;
    private bool isYPressed = false;
    private bool isColored = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            pointedObject = hit.collider.gameObject;
        }
        else
        {
            pointedObject = null;
        }

        CheckXPress();
        CheckYPress();

        

        if (pointedObject == GameObject.Find("Cube1_rotate") && isXPressed)
        {
            RotateObject();
        }

        if (pointedObject == GameObject.Find("Cube2_scale") && isXPressed)
        {
            ScaleObject();
        }

        if (pointedObject == GameObject.Find("Cube2_scale") && isYPressed)
        {
            DeScaleObject();
        }

        if (pointedObject == GameObject.Find("Cube3_color") && OVRInput.Get(OVRInput.Button.Three))
        {
            //ObjectColor = pointedObject.GetComponent<Renderer>().material.color;

            if (isColored) //if (pointedObject.GetComponent<Renderer>().material.color == Color.white)
                DeColorObject();
            else
                ColorObject();

            isColored = !isColored;

        }

        if (pointedObject == GameObject.Find("Sphere3") && isYPressed)
        {
            
            TeleportToObject();
            DeleteObject();
        }

        if (pointedObject == GameObject.Find("Sphere2") && isYPressed)
        {

            TeleportToObject();
            DeleteObject();
        }

        if (pointedObject == GameObject.Find("Sphere1") && isYPressed)
        {

            TeleportToObject();
            DeleteObject();
        }

        if (pointedObject == GameObject.Find("Summoning") && isYPressed)
        {

            TeleportToObject();
        }

    }

    void CheckXPress()
    {
        InputDevice leftHandDevice = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
        leftHandDevice.TryGetFeatureValue(CommonUsages.primaryButton, out isXPressed);
    }

    void CheckYPress()
    {
        InputDevice leftHandDevice = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
        leftHandDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out isYPressed);
    }



    void RotateObject()
    {
        pointedObject.transform.Rotate(new Vector3(90.0f, 0.0f, 0.0f) * moveSpeed * Time.deltaTime);
    }

    void ScaleObject()
    {
        Vector3 scaleChange = new Vector3(0.1f, 0.1f, 0.1f);
        pointedObject.transform.localScale += scaleChange;
        /*if (pointedObject.transform.localScale.x < 3f)
        {
            pointedObject.transform.localScale += scaleChange;
        }
        else
        {
            while (pointedObject.transform.localScale.x > 0.1f)
                pointedObject.transform.localScale -= scaleChange;
        }*/
    }
    void DeScaleObject()
    {
        Vector3 scaleChange = new Vector3(0.05f, 0.05f, 0.05f);
        pointedObject.transform.localScale -= scaleChange;
        /*while (pointedObject.transform.localScale.x > 0.1f)
        {
            pointedObject.transform.localScale -= scaleChange;
            if (pointedObject.transform.localScale.x < 0.1f)
                break;
        }*/
    }

    void ColorObject()
    {
        pointedObject.GetComponent<Renderer>().material.color = new Color(0, 204, 102);
    }
    void DeColorObject()
    {
        pointedObject.GetComponent<Renderer>().material.color = Color.white;
    }

    void DeleteObject()
    {
        Destroy(pointedObject);
    }
    void TeleportToObject()
    {
        Character2.transform.position = pointedObject.transform.position;
    }


}
