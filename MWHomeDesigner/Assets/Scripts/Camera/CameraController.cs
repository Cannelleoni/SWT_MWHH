using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //pivot point which the camera will pivot around
    [SerializeField] Transform rotationController;

    [SerializeField] Camera camera;

    //the strength the mouse input will influence the camera rotation
    public float mouseSensitivity = 100f;
    [Tooltip("Takes values (-1,1)")]
    public int mouseDirection = 1;
    //the strength the mouse input will influence the camera field of view (zoom in and out)
    public float scrollSensitivity = 1f;
    [Tooltip("Takes values (-1,1)\n-1: scroll up > zoom in\n 1: scroll up > zoom out")]
    public int scrollDirection = 1;

    //states for button controls
    public bool buttonRotation = false;
    public bool buttonZoom = false;
    public bool buttonPan = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //checking if any of the assistance buttons is pressed
        if (Input.GetKey(KeyCode.Mouse0) && buttonRotation)
        {
            //rotation the pivot point which the camera is parented to around the y-axis
            rotationController.Rotate(Vector3.up * Input.GetAxis("Mouse X") * mouseSensitivity * mouseDirection * Time.deltaTime);
        } else if(Input.GetKey(KeyCode.Mouse0) && buttonZoom)
        {
            camera.fieldOfView += Input.GetAxis("Mouse X") * mouseSensitivity * mouseDirection * Time.deltaTime;
        } else if(Input.GetKey(KeyCode.Mouse0) && buttonPan)
        {
            rotationController.Translate(Vector3.left * Input.GetAxis("Mouse X") * mouseSensitivity / 10 * mouseDirection * Time.deltaTime);
            rotationController.Translate(Vector3.up * Input.GetAxis("Mouse Y") * mouseSensitivity / 10 * -mouseDirection * Time.deltaTime);

        } else if(Input.GetKey(KeyCode.Mouse0))
        {
            rotationController.Rotate(Vector3.up * Input.GetAxis("Mouse X") *mouseDirection * mouseSensitivity * Time.deltaTime);
        }

        //ZOOM
        // adjusting the field of view to the mouse scroll input (makes zoom effect)
        camera.fieldOfView += Input.mouseScrollDelta.y * scrollSensitivity * scrollDirection;

        //PANING

        if(Input.GetKey(KeyCode.Mouse1))
        {
            rotationController.Translate(Vector3.left * Input.GetAxis("Mouse X") * mouseSensitivity/10 * mouseDirection * Time.deltaTime);
            rotationController.Translate(Vector3.up * Input.GetAxis("Mouse Y") * mouseSensitivity / 10 * -mouseDirection * Time.deltaTime);
        }

    }

    //Setter for button controls
    public void setButtonRotation(bool state)
    {
        buttonRotation = state;
    }
    public void setButtonZoom(bool state)
    {
        buttonZoom = state;
    }
    public void setButtonPan(bool state)
    {
        buttonPan = state;
    }

    //other setters
    public void setScrollDirection(int value)
    {
        scrollDirection = value;
    }
}
