using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsStoppingPoint : MonoBehaviour {

	public float speed;
	private Transform target;
	private Light lt;
	private float distance;

	void Start () {
        GameObject[] stoppingPoints = GameObject.FindGameObjectsWithTag ("StoppingPoint");
		int index = Random.Range (0, stoppingPoints.Length);
		target = stoppingPoints [index].transform;
		lt = GetComponent<Light>();
		lt.range = 3;
		lt.intensity = 0;
		distance = (transform.position - target.position).magnitude;
	}

	void Update() {
		float step = speed * Time.deltaTime;
		float pd = (transform.position - target.position).magnitude;
		transform.position = Vector3.MoveTowards(transform.position, target.position, step);

		lt.intensity += 8*(pd-(transform.position - target.position).magnitude)/distance;
		// TODO: let move a little bit past stop and destroy with Destroy(transform)
	}
}
