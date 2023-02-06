using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GrillBehavior : MonoBehaviour
{
    public GameObject meatGrillPosition;
    public GameObject rawMeat;
    public GameObject cookedMeat;
    public GameObject burnedMeat;
    public float rawToCookedTime = 180f;
    public float CookedToBurnedTime = 60f;
    public TextMeshProUGUI UIgrillTime;
    public int waitTimer;
    public int grillTime;
    private float nextActionTime;
    private float period;
    private bool startCooking;
    public AudioSource sizzelSound;


    private void Awake()
    {
        rawMeat.SetActive(true);
        cookedMeat.SetActive(false);
        burnedMeat.SetActive(false);
        
        UIgrillTime.text = "start";
    }
    private void Start()
    {
        period = 1;
        grillTime = 0;
        startCooking = false;
    }

    private void Update()
    {
        showTimer();

        // 1. Wenn rawPatty auf dem Grill liegt, starte cooking
        if (rawMeat.transform.position == meatGrillPosition.transform.position){
            startCooking = true;
            // Sekunden bis Patty fertig
           
            
  
        }
        if (grillTime == 180)
        {
            rawMeat.SetActive(false);
            cookedMeat.SetActive(true);

        }
        // Sekunden bis Patty Verbrand
        if (grillTime == 185 && cookedMeat.transform.position == meatGrillPosition.transform.position)
        {

            cookedMeat.SetActive(false);
            burnedMeat.SetActive(true);
        }



    }

    private void showTimer()
    {
        // geschwindigkeit anpassen
        if (Input.GetKeyDown(KeyCode.Space))
        {
            period = 0.05f;
            sizzelSound.pitch = 1.5f;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            period = 1;
            sizzelSound.pitch = 1;
        }
        //Timer Stopen
        if (cookedMeat.transform.position != meatGrillPosition.transform.position)
        {
            startCooking = false;
            UIgrillTime.text = "";

        }
        //Timer Anzeige
        if (startCooking)
        {

            if (Time.time > nextActionTime)
            {
                if (!sizzelSound.isPlaying)
                {
                    sizzelSound.Play();
                }
               
                grillTime++;
                nextActionTime = Time.time + period;

                if (grillTime < 60)
                {
                    if (grillTime < 10)
                    {
                        UIgrillTime.text = "0:0" + grillTime.ToString();
                    }
                    else { UIgrillTime.text = "0:" + grillTime.ToString(); }

                }
                else
                {
                    if ((grillTime % 60) < 10)
                    {
                        UIgrillTime.text = ((grillTime / 60) % 60) + ":0" + (grillTime % 60);
                    }
                    else { UIgrillTime.text = ((grillTime / 60) % 60) + ":" + (grillTime % 60); }

                }
            }
        }
    }

}
