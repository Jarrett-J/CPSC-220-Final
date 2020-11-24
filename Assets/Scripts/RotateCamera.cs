using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public GameObject target;
    public int speed = 4;

    private Vector3 offset;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            transform.LookAt(target.transform);
            transform.RotateAround(target.transform.position, Vector3.up, Input.GetAxis("Mouse X") * speed);
            offset = transform.position - target.transform.position;
        }
    }
}
