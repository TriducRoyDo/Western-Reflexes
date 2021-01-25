using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

	public float speed = 20;

	[Range(0.0f, 20.0f)]
	public float range = 20.0f;

	// Use this for initialization
	void Start() {
		range += Random.Range(0.0f, 20.0f);
	}

	// Update is called once per frame
	void Update() {
		// Debug.Log (range);
		transform.Rotate((new Vector3(0.0f, 0.0f, -10.0f) * Time.deltaTime), Space.Self);

	}
}
