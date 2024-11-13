using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AnketaScript : MonoBehaviour
{
    public TMP_InputField nameImputFiled;
    public TMP_Text nameText;
    
    // public TMP_InputField ageImputFiled;
    // public TMP_Text ageTmpText;

    public void OnButtonUserName()
    { 
        nameText.text = nameImputFiled.text; 
    }
}
