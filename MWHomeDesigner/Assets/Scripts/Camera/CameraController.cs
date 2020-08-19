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
    //the strength the mouse input will influence the camera field of view (zoom in and out)
    public float scrollSensitivity = 1f;

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
            rotationController.Rotate(Vector3.up * Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime);
        } else if(Input.GetKey(KeyCode.Mouse0) && buttonZoom)
        {
            camera.fieldOfView += Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        } else if(Input.GetKey(KeyCode.Mouse0) && buttonPan)
        {

        } else if(Input.GetKey(KeyCode.Mouse0))
        {
            rotationController.Rotate(Vector3.up * Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime);
        }

        //ZOOM
        // adjusting the field of view to the mouse scroll input (makes zoom effect)
        camera.fieldOfView += Input.mouseScrollDelta.y * scrollSensitivity;

        //PANING

        
    }
}
