using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsDestructionPoint : MonoBehaviour {

	public float speed;
	private Transform target;

	void Start () {
		GameObject[] stoppingPoints = GameObject.FindGameObjectsWithTag ("StoppingPoint");
		int index = Random.Range (0, stoppingPoints.Length);
		target = stoppingPoints [index].transform;
	}

	void Update() {
		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, target.position, step);

	}
}
