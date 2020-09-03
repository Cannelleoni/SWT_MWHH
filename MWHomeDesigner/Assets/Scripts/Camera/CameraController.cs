using UnityEngine;

public class CameraController : MonoBehaviour
{
    //pivot point which the camera will pivot around
    [SerializeField] Transform rotationController;

    // the camera in the scene
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


    void Update()
    {
        //checking if any of the assistance buttons are pressed
        // is the rotation button pressed
        if (Input.GetKey(KeyCode.Mouse0) && buttonRotation)
        {
            //rotation the pivot point which the camera is parented to around the y-axis
            rotationController.Rotate(Vector3.up * Input.GetAxis("Mouse X") * mouseSensitivity * mouseDirection * Time.deltaTime);
        }
        // is the zoom button pressed
        else if(Input.GetKey(KeyCode.Mouse0) && buttonZoom)
        {
            // if the mouse input exceeds the orthographic size of the camera
            if (Input.GetAxis("Mouse X") < 0 && camera.orthographicSize < 1)
            {
                Debug.Log("Cant zoom in further");
            }
            else
            {
                // zoom either in or out
                camera.orthographicSize += Input.GetAxis("Mouse X") * mouseSensitivity * mouseDirection * Time.deltaTime;
            }
        }
        // is the pan button pressed
        else if(Input.GetKey(KeyCode.Mouse0) && buttonPan)
        {
            // the camera gets moved along the x & y axis according to the mouse input
            rotationController.Translate(Vector3.left * Input.GetAxis("Mouse X") * mouseSensitivity / 10 * mouseDirection * Time.deltaTime);
            rotationController.Translate(Vector3.up * Input.GetAxis("Mouse Y") * mouseSensitivity / 10 * -mouseDirection * Time.deltaTime);

        }
        // is not button pressed
        else if(Input.GetKey(KeyCode.Mouse0))
        {
            // if no button is true the default fo the left mouse button is rotation
            rotationController.Rotate(Vector3.up * Input.GetAxis("Mouse X") *mouseDirection * mouseSensitivity * Time.deltaTime);
        }

        //ZOOM
        // adjusting the field of view to the mouse scroll input (makes zoom effect)
        if (Input.mouseScrollDelta.y < 0 && camera.orthographicSize < 1)
        {
            Debug.Log("Cant zoom in further");
        }
        else
        {
            camera.orthographicSize += Input.mouseScrollDelta.y * scrollSensitivity * scrollDirection;
        }


        //PANING
        // KeyCode.Mouse1 == right mouse button
        // the camera gets moved along the x & y axis according to the mouse input
        if (Input.GetKey(KeyCode.Mouse1))
        {
            rotationController.Translate(Vector3.left * Input.GetAxis("Mouse X") * mouseSensitivity/10 * mouseDirection * Time.deltaTime);
            rotationController.Translate(Vector3.up * Input.GetAxis("Mouse Y") * mouseSensitivity / 10 * -mouseDirection * Time.deltaTime);
        }

    }

    //set the button mode to rotation
    public void setButtonRotation()
    {
        buttonPan = false;
        buttonRotation = true;
        buttonZoom = false;
    }
    // set the button mode to zoom 
    public void setButtonZoom()
    {
        buttonPan = false;
        buttonRotation = false;
        buttonZoom = true;
    }
    // set the button mode to pan
    public void setButtonPan()
    {
        buttonPan = true;
        buttonRotation = false;
        buttonZoom = false;
    }

    // set the scroll direction
    public void setScrollDirection(int value) { scrollDirection = value; }
}
