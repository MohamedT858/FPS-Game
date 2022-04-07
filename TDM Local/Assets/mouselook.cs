using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouselook : MonoBehaviour
{
    public float mousesensitivity =100f;
    public Transform playerbody;

    float XRotation=0f ;
 
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        
    }

    
    void Update()
    {
        float mousex = Input.GetAxis("Mouse X") * mousesensitivity * Time.deltaTime;
        float mousey = Input.GetAxis("Mouse Y") * mousesensitivity * Time.deltaTime;
        XRotation -= mousey;
        XRotation = Mathf.Clamp(XRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(XRotation,0f,0f);


        playerbody.Rotate(Vector3.up * mousex);


    }
}
