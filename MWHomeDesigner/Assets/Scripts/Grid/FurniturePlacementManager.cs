using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controller

public class FurniturePlacementManager : MonoBehaviour
{
    public static string activeFurniture;

    public Transform lastPreviewed;
    public GameObject previewfurniture;

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

                        Debug.Log("Bed spawned");
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
                    Debug.Log("selected" + hit.transform.name);
                    Destroy(previewfurniture);
                }
                else
                {
                }
            }
        }
    }
    public static void setActiveFurniture(string furniture)
    {
        activeFurniture = furniture;
    }
}
