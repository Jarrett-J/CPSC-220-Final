using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoiColor : MonoBehaviour
{
    public MeshRenderer[] markers;
    public Color color;

    void Start()
    {
        markers = GetComponentsInChildren<MeshRenderer>();

        foreach (MeshRenderer mesh in markers)
        {
            mesh.material.SetColor("_Color", color);
        }
    }
}
