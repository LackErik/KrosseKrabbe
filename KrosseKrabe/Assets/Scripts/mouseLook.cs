using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseLook : MonoBehaviour
{
    float mouseSens = 400;
    float mouseX = 0;
    float mouseY = 0;
    float xRotation;
    public Transform playerbody;

    // Start is called before the first frame update
    void Start()
    {
       
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        
        mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation,-90f, 90f);

        playerbody.Rotate(Vector3.up * mouseX);
        
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

    }
}
