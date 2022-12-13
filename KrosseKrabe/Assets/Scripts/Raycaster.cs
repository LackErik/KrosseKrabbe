using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycaster : MonoBehaviour
{
    public LayerMask layerMask;
    public Transform holdingPosition;
    public bool holding;
    private Camera cam;
    private int objectIndex;
    public GameObject[] objectsInOrder;
    public List<Interaction> interactions;
    private GameObject tempSelected;
    private Transform tempEndPosition;
    

    private void Awake()
    {
        holding = false;
        cam = Camera.main;
    }
    // Update is called once per frame
    void Update()
    {
        Ray();
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 20.0f, layerMask))
            {

                UpdateSelection(hit.transform.gameObject);

            }

        }
        if (holding)
        {
            holdObject(tempSelected);
        }
        
    }

    void Ray()
    {
        //Ray ray = new Ray(transform.position, transform.forward);
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
       
            if (Physics.Raycast(ray, out hit, 20.0f, layerMask))
            {
                Debug.DrawLine(ray.origin, hit.point, Color.green);
            }
            else
            {
                Debug.DrawLine(ray.origin, ray.origin + ray.direction * 20.0f, Color.red);
            }
        
    }
    private void UpdateSelection(GameObject selectedGameObject)
    {
        if (selectedGameObject.Equals(interactions[objectIndex].model))
        {
            tempEndPosition = interactions[objectIndex].endPosition;
            holding = true;
            tempSelected = interactions[objectIndex].model;

            if (objectIndex < 9) {
                objectIndex++;
            }
            
          
            
           


            Debug.Log("Nr." + objectIndex + " " + selectedGameObject.name);
           
            // txt.SetText("Nr." + objectIndex + " " + selectedGameObject.name);

        }
        else
        {
            Debug.Log("Flase: " + interactions[objectIndex].model);
           // txt.SetText("Wrong Number");
        }
    }
    void holdObject(GameObject selectedGameObject)
    {
       
        selectedGameObject.transform.position = holdingPosition.position;

        if (selectedGameObject.transform.position.x < 0.38f && selectedGameObject.transform.position.x > 0.06f)
        {
            if (selectedGameObject.transform.position.z < 1.401f && selectedGameObject.transform.position.z > 1.147)
            {
                Debug.Log(selectedGameObject.name);
                selectedGameObject.transform.position = tempEndPosition.position;
                holding = false;
               
            }
        }
        
    }
}
