using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Purchase : MonoBehaviour
{
    public int totalCost { set; get; } = 0;
    public GameObject pointsText;
    private TextMeshProUGUI text;
    public List<GameObject> dropdownObjects;
    private List<ShopDropdown> dropdowns = new List<ShopDropdown>();

    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();

        foreach (GameObject dropdown in dropdownObjects)
        {
            dropdowns.Add(dropdown.GetComponent<ShopDropdown>());
        }
    }

    public void PurchaseOutfit()
    {
        if (Player.Instance.Points < totalCost)
        {
            GameObject notEnough = transform.GetChild(0).gameObject;
            notEnough.SetActive(true);
        }
        else
        {
            GameObject notEnough = transform.GetChild(0).gameObject;
            notEnough.SetActive(false);
            Buy();
        }
    }

    private void Buy()
    {
        Player.Instance.Points -= totalCost;
        pointsText.GetComponent<PointsDisplay>().UpdatePointsText();

        foreach(ShopDropdown dropdown in dropdowns)
        {
            if (dropdown.dropdown.value > 0)
            {
                dropdown.parts[dropdown.dropdown.value - 1].owned = true;
            }
        }

        UpdateTotalCostText();
        Refresh();
    }

    public void UpdateTotalCostText()
    {
        text.text = "Total cost: " + totalCost.ToString();
    }

    private void Refresh()
    {
        foreach (ShopDropdown dropdown in dropdowns)
        {
            dropdown.RefreshDropdownItems();
        }
    }
}
