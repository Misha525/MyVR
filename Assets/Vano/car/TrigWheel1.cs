using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigWheel1 : MonoBehaviour
{
    public string triggerTag = "TrigCarZ";
    public string object2Tag = "Player";


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(object2Tag))
        {

        }
        else
        {
            GlobalVariables.WTrig2++;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(object2Tag))
        {

        }
        else
        {
            //задержка на 3 секунды
            GlobalVariables.WTrig2--;
        }
    }
}
