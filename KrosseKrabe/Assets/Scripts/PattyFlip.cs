using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PattyFlip : MonoBehaviour
{
    public GrillBehavior cookingTimer;
    private Animator anim;
    public GameObject cooked;
    public GameObject burned;

    // Start is called before the first frame update
    void Start()
    {

        anim = gameObject.GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cookingTimer.grillTime == 87)
        {
            cooked.SetActive(true);
        }
        if (cookingTimer.grillTime == 90) 
        {
            anim.enabled = true;
            Debug.Log("enable pls");
            anim.SetBool("Flip", true);
           
        }
       
       
    }

}
