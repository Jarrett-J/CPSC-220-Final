using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextChanger : MonoBehaviour
{
    TextMeshProUGUI text;

    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    public void ChangeText(string text)
    {
        this.text = GetComponent<TextMeshProUGUI>();

        if (this.text == null)
        {
            print("mesh null");
        }

        if (text == null)
        {
            print("text null");
        }
        this.text.text = text;
    }
}
