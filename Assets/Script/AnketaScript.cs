using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class AnketaScript : MonoBehaviour
{
    public TMP_InputField nameImputFiled;
    public TMP_Text nameText;
    // Start is called before the first frame update
    public void OnButtonUserName()
    { 
        nameText.text = nameImputFiled.text; 
    }

    // Update is called once per frame
   public void Update()
    {
        
    }
}
