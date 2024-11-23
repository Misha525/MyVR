using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CalculatorScript : MonoBehaviour
{
   [SerializeField] private TMP_InputField inputField1;
   [SerializeField] private TMP_InputField inputField2;
   [SerializeField] private TMP_Text outputText;

   public void OnButtunMinus() {
        int value1 = ReadIntFromInputField(inputField1);
        int value2 = ReadIntFromInputField(inputField2);
        outputText.text = (value1 - value2).ToString();
   }

   public void OnButtunPlus() {
        int value1 = ReadIntFromInputField(inputField1);
        int value2 = ReadIntFromInputField(inputField2);
        outputText.text = (value1 + value2).ToString();
   }

    public void OnButtunMultiplication() {
        int value1 = ReadIntFromInputField(inputField1);
        int value2 = ReadIntFromInputField(inputField2);
        outputText.text = (value1 * value2).ToString();
    }

    public void OnButtonDivision() {
        int value1 = ReadIntFromInputField(inputField1);
        int value2 = ReadIntFromInputField(inputField2);
        if (value2 == 0) {
            outputText.text = "На ноль делить нельзя!";
        } else {
            outputText.text = (value1 / value2).ToString();
        }
    }
    private int ReadIntFromInputField(TMP_InputField inputField) {
        string str = inputField.text;
        if (str != null && str.Length > 0) {
            if (int.TryParse(str, out int intValue)) {
                return intValue;
            }
        }
        return 0;
    }
}