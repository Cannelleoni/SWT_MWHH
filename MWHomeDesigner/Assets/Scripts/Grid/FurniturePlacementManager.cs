using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurniturePlacementManager : MonoBehaviour
{
    public static string activeFurniture;

    private GameObject selectedFurniture;

    private Transform lastPreviewed;
    private GameObject previewfurniture;

    public GameObject furnitureMenu;

    public FlexibleColorPicker colorPicker;

    RaycastHit hit;

    void Update()
    {
        // if a piece of furniture has been selected
        if (!string.IsNullOrEmpty(activeFurniture))
        {
            // send out the raycast
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            // if it points to something
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                // and that isn't null and the hovered tile has changed 
                if (hit.transform != null && hit.transform != lastPreviewed)
                {
                    // then destroy the last preview on previous tile
                    Destroy(previewfurniture);
                    // and makes new one on current tile
                    previewfurniture = GameObject.Instantiate((GameObject)Resources.Load("Preview" + activeFurniture), hit.transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity, hit.transform);
                }
                // if no preview at all has been set -> set the first one
                else
                {
                    // first preview is set
                    lastPreviewed = hit.transform;
                    previewfurniture = GameObject.Instantiate((GameObject)Resources.Load("Preview" + activeFurniture), hit.transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity, hit.transform);
                }
            }

            // if the player clicks on a tile
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                // a raycast gets send out
                if (Physics.Raycast(ray, out hit, 100.0f))
                {
                    // if it hits something
                    if (hit.transform != null)
                    {
                        // put the active furniture piece there
                        GameObject furniture = GameObject.Instantiate((GameObject)Resources.Load(activeFurniture), hit.transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity, hit.transform);
                        activeFurniture = "";
                    }
                }
                // in any case destroy the preview object
                Destroy(previewfurniture);
            }
        }
        // if no piece of furniture has been selected
        else
        {
            // send out the raycast
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            // if it hit something
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                // and the player presses the left mouse button over a piece of furniture
                if (Input.GetKeyDown(KeyCode.Mouse0) && hit.transform.tag == "Furniture")
                {
                    // its menu becomes active
                    furnitureMenu.SetActive(true);
                    // that object becomes the currently selected piece of furniture
                    selectedFurniture = hit.transform.gameObject;
                    // and preview is destroyed
                    Destroy(previewfurniture);
                }
                // if no furniture has been clicked on
                else if(Input.GetKeyDown(KeyCode.Mouse0))
                {
                    // deactivate the furniture menu
                    furnitureMenu.SetActive(false);
                }
            }
        }
    }

    // when clicking on a furniture icon get its name for Resource loading
    public static void setActiveFurniture(string furniture) { activeFurniture = furniture; }

    // rotate the selected furniture along the y axis to the left
    public void rotateLeft() { selectedFurniture.transform.Rotate(new Vector3(0, -90, 0)); }

    // rotate the selected furniture along the y axis to the right
    public void rotateRight() { selectedFurniture.transform.Rotate(new Vector3(0, 90, 0)); }

    // destroy the piece of furniture and close the furniture menu
    public void deleteFurniture()
    {
        Destroy(selectedFurniture);
        furnitureMenu.SetActive(false);
    }

    // change the color of the object
    public void changeColor() { selectedFurniture.GetComponentInChildren<Renderer>().material.color = colorPicker.color; }
}
