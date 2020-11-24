using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Body part", menuName = "ScriptableObjects/BodyPart", order = 1)]
public class BodyPart : ScriptableObject
{
    public GameObject part;
    public int price;
    public bool owned = false;
}
