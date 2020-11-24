using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopDropdown : MonoBehaviour
{
    public TMP_Dropdown dropdown;

    public GameObject playerPartObject;
    public List<BodyPart> parts;
    public GameObject purchaseObject;
    public string partType = "";
    // hat = 0, head = 1, body = 2
    public int childIndex = 0;
    public int currentPartCost = 0;

    void Start()
    {
        dropdown = GetComponent<TMP_Dropdown>();
        
        RefreshDropdownItems();

        dropdown.onValueChanged.AddListener(delegate { DropdownItemSelected(dropdown); });
    }

    public void RefreshDropdownItems()
    {
        dropdown.options.Clear();
        dropdown.options.Add(new TMP_Dropdown.OptionData() { text = partType });

        foreach (var part in parts)
        {
            string partString;

            if (part.owned)
            {
                partString = part.part.name + " : Owned";
            }
            else
            {
                partString = part.part.name + " : " + part.price + " points";
            }

            dropdown.options.Add(new TMP_Dropdown.OptionData()
            {
                text = partString
            });
        }

        // value of 0 will show the label
        dropdown.value = 0;
        dropdown.RefreshShownValue();
    }

    void DropdownItemSelected(TMP_Dropdown dropdown)
    {
        Purchase purchase = purchaseObject.GetComponent<Purchase>();
        int index = dropdown.value;
        // the first index is just text, so we need to adjust
        if (index != 0)
        {
            index -= 1;
            playerPartObject.GetComponent<PlayerCustomization>().SetPart(parts[index]);

            purchase.totalCost -= currentPartCost;
            currentPartCost = parts[index].price;

            if (parts[index].owned)
            {
                currentPartCost = 0;
            }

            purchase.totalCost += currentPartCost;
            purchase.UpdateTotalCostText();
        }
        else
        {
            purchase.totalCost -= currentPartCost;
            currentPartCost = 0;
            purchase.UpdateTotalCostText();
        }
    }

    public void ResetOwnership()
    {
        foreach (BodyPart part in parts)
        {
            part.owned = false;
        }
        RefreshDropdownItems();
    }

}
    


