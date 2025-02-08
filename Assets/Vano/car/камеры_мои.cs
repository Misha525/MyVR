using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class камеры_мои : MonoBehaviour
{
    public Camera[] cameras;
    public TMP_Text textToDisplay;
    public TMP_Text textToDisplay1;
    private int currentCameraIndex = 0;
    public Transform targetObject;
    public Transform targetBox;
    public Transform transform;
    public Vector3 offset = new Vector3(5f, 0f, 0f);
    public Vector3 offsset = new Vector3(0f, 2f, 0f);
    public string q;
    public string y;

    void Start()
    {
        if (cameras == null || cameras.Length == 0)
        {
            Debug.LogError("No cameras assigned to CameraSwitcher!");
            return;
        }
        for (int i = 1; i < cameras.Length; i++)
        {
            cameras[i].gameObject.SetActive(false);
        }
        cameras[0].gameObject.SetActive(true);
    }
    void Update() 
    {   y = GlobalVariables.yprav.ToString();
        q = GlobalVariables.qk.ToString();
        textToDisplay.text = y;
        textToDisplay1.text = q;
        if (Input.GetKeyDown(KeyCode.I)){
            GlobalVariables.yprav = 1; 
            cameras[currentCameraIndex].gameObject.SetActive(false);
            currentCameraIndex = 0 % cameras.Length;
            cameras[currentCameraIndex].gameObject.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.O)){
            GlobalVariables.yprav = 2; 
            cameras[currentCameraIndex].gameObject.SetActive(false);
            currentCameraIndex = 1 % cameras.Length;
            cameras[currentCameraIndex].gameObject.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.P)){
            GlobalVariables.yprav = 3; 
            cameras[currentCameraIndex].gameObject.SetActive(false);
            currentCameraIndex = 2 % cameras.Length;
            cameras[currentCameraIndex].gameObject.SetActive(true);
        }



            // внезавное условие из тригерров
            if (GlobalVariables.WTrig1 > 0 || GlobalVariables.WTrig2 > 0)
            {
                GlobalVariables.object1InTrigger = 1;
            }
            else
            {
                GlobalVariables.object1InTrigger = 0;
            }

            // снова внезапное условие но для входа/выхода в/из машину
            if (GlobalVariables.qk == 1)
            {
                if (GlobalVariables.yprav == 1)
                {
                    if (Input.GetKeyDown(KeyCode.Q))
                    {
                        GlobalVariables.yprav = 2;
                        cameras[currentCameraIndex].gameObject.SetActive(false);
                        currentCameraIndex = 1 % cameras.Length;
                        cameras[currentCameraIndex].gameObject.SetActive(true);

                        transform.position = targetBox.position + offsset;
                    }
                }
            }

            if (GlobalVariables.qk == 2)
            {
                if (GlobalVariables.yprav == 2)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        GlobalVariables.yprav = 1;
                        currentCameraIndex = 0 % cameras.Length;
                        cameras[currentCameraIndex].gameObject.SetActive(true);

                        transform.position = targetObject.position + offset;
                        GlobalVariables.qk = 1;
                    }
                }
            }
    }
}