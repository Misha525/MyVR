using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class MovingObject : MonoBehaviour
{

    public TMP_Text textToDisplay;
    public Camera[] camers;
    private int currentCameraIndex = 0;
    public float sp = 5f;
    public float speed;
    public float speed_two = 0;
    public float raz;
    public float speed_koaf;
    private Rigidbody rb;
    private bool zemlya;
    public float mouseSensitivity = 2f;
    public Transform cameraTransform;
    private float rotationX = 0f;
    private float rotationY = 0f;
    public float rotationSpeed = 100f;
    public float move;
    public float turn;




    void Start()
    {
        speed = sp * 5;
        speed_koaf = speed/5;
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody component not found!");
            enabled = false;
            return;
        }
                if (camers == null || camers.Length == 0)
        {
            Debug.LogError("No cameras assigned to CameraSwitcher!");
            return;
        }
    }

    void Update()
    {
    if (GlobalVariables.yprav == 2) 
        {
            textToDisplay.text = "Q - выйти в машину";
            
            if (speed_two != 0)
            {
                raz = speed_two/5;
            }
            else 
            {
                raz = 0;
            }

            GlobalVariables.qk = 2;
            if (Input.GetKeyDown(KeyCode.E))
            {
                camers[currentCameraIndex].gameObject.SetActive(false);
            }

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
            {
                while (raz < speed_koaf)
                {
                    raz = speed_two/5;
                    speed_two = speed_two + 5;
                    //задержка на 2 секунды
                }
            }

            if (Input.GetKeyUp(KeyCode.W) && Input.GetKeyUp(KeyCode.S))
            {
                while (raz > 0)
                {
                    speed_two = speed_two - 5;
                    raz = speed_two/5;
                    //задержка на 2 секунды
                }
            }

        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
        float mouseXCamera = Input.GetAxis("Mouse X") * mouseSensitivity; 
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -45f, 90f);
        rotationY += mouseXCamera;
        rotationY = Mathf.Clamp(rotationY, -90f, 90f);
        cameraTransform.localEulerAngles = new Vector3(rotationX, rotationY, 0f);


        //движение и поворот

        if (GlobalVariables.object1InTrigger > 0)
        {
            move = Input.GetAxis("Vertical") * speed_two * Time.deltaTime;
            transform.Translate(0, 0, move);
            
            if (Input.GetKey(KeyCode.W)) 
            {
                turn = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime * 5;
                transform.Rotate(0, turn, 0);
            }
            if (Input.GetKey(KeyCode.S))
            {
                turn = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime * -5;
                transform.Rotate(0, turn, 0);  
            }
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            camers[currentCameraIndex].gameObject.SetActive(false);
            currentCameraIndex = (currentCameraIndex + 1) % camers.Length;
            camers[currentCameraIndex].gameObject.SetActive(true);
        }

        }
    }
}
