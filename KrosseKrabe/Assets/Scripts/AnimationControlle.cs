using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControlle : MonoBehaviour
{
    public Animator animator;
    private int currentState;
    private string currentAnim;
    private string[] animatorStates = { "patty", "sauce" };
    public void PlayNextAnimation()
    {
        

        
        if (currentState < animatorStates.Length)
        {
            
            animator.SetBool(animatorStates[currentState], true);
            currentState++;
            Debug.Log(currentState);
        }
    }

    public void PlayPreviousAnimation()
    {
        
        
        if (currentState > 0)
        {
            currentState--;
            animator.SetBool(animatorStates[currentState], false);
           
            Debug.Log(currentState);
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            PlayNextAnimation();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            PlayPreviousAnimation();
        }



    }
}
