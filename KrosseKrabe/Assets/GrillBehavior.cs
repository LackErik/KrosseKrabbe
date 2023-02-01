using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrillBehavior : MonoBehaviour
{
    public GameObject meatGrillPosition;
    public GameObject rawMeat;
    public GameObject cookedMeat;
    public GameObject burnedMeat;
    public float rawToCookedTime = 180f;
    public float CookedToBurnedTime = 60f;

    private void Awake()
    {
        rawMeat.SetActive(true);
        cookedMeat.SetActive(false);
        burnedMeat.SetActive(false);
    }
    
    private void Update()
    {
        // 1. Wenn rawPatty auf dem Grill liegt, starte cooking
        if(rawMeat.transform.position == meatGrillPosition.transform.position){
            StartCoroutine(ReplaceWithCookedMeat());
        }
        
        // 2. wenn Patty gekocht fertig, dann beginne "Verbennungszeit"
        if(cookedMeat.activeSelf == true){
            StartCoroutine(ReplaceWithBurnedMeat());
        }
        
        // 3. Wenn Patty verbrannt, beende das Trainung und gebe Rückmeldung
        if(burnedMeat.activeSelf == true){
            // ... doSomething ...
        }
        
    }

    private IEnumerator ReplaceWithCookedMeat()
    {
        yield return new WaitForSeconds(rawToCookedTime);

        rawMeat.SetActive(false);
        cookedMeat.SetActive(true);
        //StartCoroutine(ReplaceWithBurnedMeat());
    }

    private IEnumerator ReplaceWithBurnedMeat()
    {
        yield return new WaitForSeconds(CookedToBurnedTime);

        cookedMeat.SetActive(false);
        burnedMeat.SetActive(true);
    }
}
