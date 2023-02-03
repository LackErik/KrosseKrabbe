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
    public bool InteractionsCompleted => objectIndex >= interactions.Count;
    private bool interactionInProgress;
    private GameObject tempSelected;
    private Transform tempEndPosition;
    public GameObject senf;
    public GameObject ketchup;

    // Pass Information to the IngameUI Script
    public IngameUI ingameUiScript;
    private int errorCount;
    private int helpCount;

    //handle RawMeat
    public GameObject meatGrillPosition;
    public GameObject rawMeat;

    public AudioSource korrektSound;
    public AudioSource wrongSound;


    private void Awake()
    {
        holding = false;
        cam = Camera.main;
    }
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
        //UI Funktion für Hilfe / Tipps
        getHelp();
        if(InteractionsCompleted) {
            // Training beenden
            // Final Score 
            // Szene verlassen oder Menü öffnen und zum Menü rechts davon FinalScore anzeigen
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
            korrektSound.Play();

            Debug.Log("Nr." + objectIndex + " " + selectedGameObject.name);
        
            // txt.SetText("Nr." + objectIndex + " " + selectedGameObject.name);

        }
        else
        {
            //UI Funktion für Error jedoch nur dann wenn falsch geklickt
            didError(selectedGameObject);
            wrongSound.Play();
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
                // wenn selectedGameObject nicht rawMeat
                if(selectedGameObject != rawMeat)
                {
                    Debug.Log(selectedGameObject.name);
                    selectedGameObject.transform.position = tempEndPosition.position;
                    holding = false;
                    if (objectIndex == 3)
                    {
                        ketchup.SetActive(true);
                    }
                    if (objectIndex == 4)
                    {
                        senf.SetActive(true);
                    }
                }
            }
        }

        //handle rawMeat transform ... danach wirkt das GrillBehavior Script
        if (selectedGameObject.transform.position.x < -0.89f && selectedGameObject.transform.position.x > -1.47f)
        {
            if (selectedGameObject.transform.position.z < 4.0f && selectedGameObject.transform.position.z > 3.4f)
            {
                Debug.Log("selectedGameObject:" + selectedGameObject + selectedGameObject.name);
                Debug.Log("rawMeat:" + rawMeat + rawMeat.name);
                if(selectedGameObject == rawMeat)
                {
                    Debug.Log(selectedGameObject.name + " == " + rawMeat.name);
                    selectedGameObject.transform.position = meatGrillPosition.transform.position;
                    holding = false;
                }
                
            }
        }

    }

    void getHelp(){
        // Users can request help with the H key as long as we still have "open" interactions (the training is not completed).
            if (Input.GetKeyDown(KeyCode.H) && !InteractionsCompleted)
            {
                // If your help counter is limited (because you display the help permanently after it was requested)
                // then you can do this ...
                // if (!currentInteraction.HelpCounted)
                // {
                //     helpCount++;
                //     currentInteraction.HelpCounted = true;
                // }
                // otherwise just do ...
                helpCount++;
                
                ingameUiScript.DisplayHelp(interactions[objectIndex].helpMsg, helpCount);
            }
    }

    void didError(GameObject selectedGameObject){
        // Wenn keine weitere interactions folgen, ist das training beendet. 
        if(InteractionsCompleted)
            return;
            
            // hat der nutzer das richtige Objekt geklickt? dann fahre fort 
        if(selectedGameObject.Equals(interactions[objectIndex].model))
        {
            return;
        }
            // sonst hat er das falsche Objekt geklickt
        else
        {
            errorCount++;
            ingameUiScript.DisplayError(interactions[objectIndex].errorMsg, errorCount);
        }
    }

}
