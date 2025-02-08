using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class TrigCarPlayer1 : MonoBehaviour
{
    public TMP_Text textToDisplay;
    public string triggerTag = "PTrigCar";
    public string object2Tag = "Player";


    void Start()
    {
        if (textToDisplay == null)
            {
                Debug.LogError("TextMeshProUGUI component not assigned!");
                enabled = false;
                return;
            }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(object2Tag))
        {
            textToDisplay.text = "Q - войти в машину";
            GlobalVariables.qk = 1;
        }
        else
        {
        
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(object2Tag))
        {
            textToDisplay.text = "Здесь будут высвечиваться ваши возможности на данный момент.";
            GlobalVariables.qk = 0;
        }
        else
        {
            
        }
    }
}
