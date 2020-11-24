using TMPro;
using UnityEngine;

public class Food : MonoBehaviour
{
    private GameObject pointsObject;
    private int points;

    private void OnMouseDown()
    {
        Player.Instance.Points += 1;
        pointsObject = GameObject.FindGameObjectWithTag("Counter");
        pointsObject.GetComponent<TextMeshProUGUI>().text = "Food: " + Player.Instance.Points;
        Destroy(gameObject);
    }
}
