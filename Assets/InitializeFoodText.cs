using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InitializeFoodText : MonoBehaviour
{
    private TextMeshProUGUI text;
    private string initialText;

    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        initialText = "Food: " + Player.Instance.Points;
        text.text = initialText;
    }
}
