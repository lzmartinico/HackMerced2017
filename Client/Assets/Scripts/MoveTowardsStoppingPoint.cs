using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsStoppingPoint : MonoBehaviour {

	public float speed;
	private Transform target;

	void Start () {
		GameObject[] stoppingPoints = GameObject.FindGameObjectsWithTag ("StoppingPoint");
		target = stoppingPoints [0].transform;
	}

	void Update() {
		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, target.position, step);
	}
}
