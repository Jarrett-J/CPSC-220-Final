using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PointsDisplay : MonoBehaviour
{
    private TextMeshProUGUI text;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        UpdatePointsText();
    }

    public void UpdatePointsText()
    {
        text.text = "Points: " + Player.Instance.Points.ToString();
    }
}
