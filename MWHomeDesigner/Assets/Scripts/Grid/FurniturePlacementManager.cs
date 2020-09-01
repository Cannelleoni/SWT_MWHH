using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controller

public class FurniturePlacementManager : MonoBehaviour
{
    public static string activeFurniture;

    public GameObject selectedFurniture;

    public Transform lastPreviewed;
    public GameObject previewfurniture;

    public GameObject furnitureMenu;

    RaycastHit hit;

    void Update()
    {
        if (!string.IsNullOrEmpty(activeFurniture))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform != null && hit.transform != lastPreviewed)
                {
                    Destroy(previewfurniture);
                    previewfurniture = GameObject.Instantiate((GameObject)Resources.Load("Preview" + activeFurniture), hit.transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity, hit.transform);
                } else
                {
                    lastPreviewed = hit.transform;
                    previewfurniture = GameObject.Instantiate((GameObject)Resources.Load("Preview" + activeFurniture), hit.transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity, hit.transform);
                }
            }

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {

                if (Physics.Raycast(ray, out hit, 100.0f))
                {
                    if (hit.transform != null)
                    {
                        Debug.Log("tile hit" + hit.transform.position);
                        GameObject furniture = GameObject.Instantiate((GameObject)Resources.Load(activeFurniture), hit.transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity, hit.transform);

                        activeFurniture = "";
                    }
                }
                Destroy(previewfurniture);
            }
        } else
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (Input.GetKeyDown(KeyCode.Mouse0) && hit.transform.tag == "Furniture")
                {
                    furnitureMenu.SetActive(true);
                    selectedFurniture = hit.transform.gameObject;
                    Debug.Log("selected" + hit.transform.name);
                    Destroy(previewfurniture);
                }
                else if(Input.GetKeyDown(KeyCode.Mouse0))
                {
                    furnitureMenu.SetActive(false);
                }
            }
        }
    }
    public static void setActiveFurniture(string furniture)
    {
        activeFurniture = furniture;
    }


    public void rotateLeft()
    {
        selectedFurniture.transform.Rotate(new Vector3(0, 90, 0));
    }

    public void rotateRight()
    {
        selectedFurniture.transform.Rotate(new Vector3(0, -90, 0));
    }
    public void deleteFurniture()
    {
        Destroy(selectedFurniture);
    }
}
