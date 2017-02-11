using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsCamera : MonoBehaviour {
	
	public Transform target;
	public float speed;

	void Start() {
		target = Camera.main.gameObject.transform;
	}

	void Update() {
		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, target.position, step);
	}
}
