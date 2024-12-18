using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollectableCanvas : MonoBehaviour
{
    public static CollectableCanvas Instance;
    public TMP_Text tmpText;
    public int itemCount = 0;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        }
    }

    public void IncrementItem() {
        itemCount = itemCount + 1;
        tmpText.text = itemCount.ToString();
    }
}
