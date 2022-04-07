
using UnityEngine;

public class SprintAndCrouch : MonoBehaviour
{
    public MovementScript MovementScript;
    public float sPrintsPeed = 19f;
    public float mOvesPeed = 13f;
    public float cRouchsPeed = 6f;
    private float cRouchhEight = 1.7f;
    private float standheight = 3.51f;
    private CharacterController m_charactercontroller;

    bool iscrouching;
    //private CharacterController CharacterController;
    /// Start is called before the first frame update
    void Start()
    {
        MovementScript = GetComponent<MovementScript>();
        m_charactercontroller = GetComponent<CharacterController>();





    }

    // Update is called once per frame
    void Update()
    {
        crouch();
        sprint();


    }
    void sprint() {
        if (Input.GetKeyDown(KeyCode.LeftShift) && !iscrouching)
        {
            MovementScript.speed = sPrintsPeed;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) && !iscrouching)
        {
            MovementScript.speed = mOvesPeed;

        }
    }
    void crouch() {
        if (Input.GetKeyDown(KeyCode.C))
        {

            m_charactercontroller.height = cRouchhEight;
            MovementScript.speed = cRouchsPeed;
            iscrouching = true;


        }
        if (Input.GetKeyUp(KeyCode.C))
        {
            MovementScript.speed = mOvesPeed;
            m_charactercontroller.height = standheight;
            iscrouching = false;

        }

    }



}