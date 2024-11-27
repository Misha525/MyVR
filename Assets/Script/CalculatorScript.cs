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
        float value1 = ReadFloatFromInputField(inputField1);
        float value2 = ReadFloatFromInputField(inputField2);
        outputText.text = (value1 - value2).ToString();
   }

   public void OnButtunPlus() {
        float value1 = ReadFloatFromInputField(inputField1);
        float value2 = ReadFloatFromInputField(inputField2);
        outputText.text = (value1 + value2).ToString();
   }

    public void OnButtunMultiplication() {
        float value1 = ReadFloatFromInputField(inputField1);
        float value2 = ReadFloatFromInputField(inputField2);
        outputText.text = (value1 * value2).ToString();
    }

    public void OnButtonDivision() {
        float value1 = ReadFloatFromInputField(inputField1);
        float value2 = ReadFloatFromInputField(inputField2);
        if (value2 == 0) {
            outputText.text = "На ноль делить нельзя!";
        } else {
            outputText.text = (value1 / value2).ToString();
        }
    }
    private float ReadFloatFromInputField(TMP_InputField inputField) {
        string str = inputField.text;
        if (str != null && str.Length > 0) {
            if (float.TryParse(str, out float floatValue)) {
                return floatValue;
            }
        }
        return 0;
    }
}