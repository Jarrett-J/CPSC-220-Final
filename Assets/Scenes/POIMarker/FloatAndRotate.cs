using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatAndRotate : MonoBehaviour {

	[SerializeField] private float rotateSpeed = 50;
	[SerializeField] private float floatAmplitude = 1f;
	[SerializeField] private float floatFrequency = 0.75f;

	private Vector3 startPos;

	void Start() {
		startPos = transform.position;
	}
	
	void Update () {
		transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
		Vector3 tempPos = startPos;
		tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * floatFrequency)
		             * floatAmplitude;
		transform.position = tempPos;
	}
}
