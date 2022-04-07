using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public CharacterController Controller;
    public float speed = 13f;
    public float Gravity = -9.81f;
    Vector3 velocit;
    public Transform GroundCheck;
    public float grounddestance = .10f;
    public LayerMask terrainMask;
    bool istouching;
    public float JumpHieght = 3f;

   
   
    void Update()
    {
        istouching = Physics.CheckSphere(GroundCheck.position, grounddestance,terrainMask);
        if(istouching && velocit.y < 0)
        {
            velocit.y = -2f;
        }
        float X = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * X + transform.forward * z;
        Controller.Move(move * speed * Time.deltaTime);
        
        
            if (Input.GetButtonDown("Jump"))
            {
                velocit.y = Mathf.Sqrt(JumpHieght * -2 * Gravity);
            }
        

        velocit.y += Gravity * Time.deltaTime;

        Controller.Move(velocit * Time.deltaTime);
    }
}