using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cinemachine;

public class AnimationControlle : MonoBehaviour
{
    public Animator animator;
    private int currentState;
    private string currentAnim;
    public List<Interaction> interactions;
    private string[] animatorStates = { "patty", "sauce","senf", "pickels","onions","salat","cheese","tomato","bun" };
    public TextMeshProUGUI instructionDisplay;
    public GameObject btnSkip;
    public GameObject btnBack;
    public GameObject bunBotown;
    public CinemachineVirtualCamera c_VirtualCam;

    public void PlayNextAnimation()
    {
        

        
        if (currentState < animatorStates.Length)
        {
            
            animator.SetBool(animatorStates[currentState], true);
            instructionDisplay.SetText(interactions[currentState].instruction);
            c_VirtualCam.m_LookAt = interactions[currentState].model.transform;
          
            currentState++;
            
        }
        
    }

    public void PlayPreviousAnimation()
    {
        
        
        if (currentState > 0)
        {
            currentState--;
            animator.SetBool(animatorStates[currentState], false);
            c_VirtualCam.m_LookAt = interactions[currentState].model.transform;
            instructionDisplay.SetText(interactions[currentState].instruction);
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        instructionDisplay.SetText(interactions[currentState].instruction);
    }
    private void Awake()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(currentState == 0)
        {
            c_VirtualCam.m_LookAt = bunBotown.transform;
            btnBack.SetActive(false);
        }
        else btnBack.SetActive(true);

        if (currentState == animatorStates.Length)
        {
            btnSkip.SetActive(false);
        }
        else btnSkip.SetActive(true);

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
