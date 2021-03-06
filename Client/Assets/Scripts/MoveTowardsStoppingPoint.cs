﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsStoppingPoint : MonoBehaviour {

	public float speed;
	public Transform target;
	private Light lt;
	public float distance;
	public float distanceTraveled;
	public float rate;
	public float travelTime;
	public float estTimeTillArrival;
	public float timeSinceStartSong;
	public float estArrivalTime = 0;
	private float startTime;
	private Vector3 startPos;
	private Vector3 prev;
	public bool reverse = false;

	void Start () {
		startTime = Time.fixedTime;
        GameObject[] stoppingPoints = GameObject.FindGameObjectsWithTag ("StoppingPoint");
		int index = Random.Range (0, stoppingPoints.Length);
		target = stoppingPoints [index].transform;
		lt = GetComponent<Light>();
		lt.range = 3;
		lt.intensity = 0;
		distance = (transform.position - target.position).magnitude;
		startPos = transform.position;
	}

	void Update() {
		float step = speed * Time.deltaTime;
		float pd = (transform.position - target.position).magnitude;
		Vector3 move = transform.position;
		if (reverse) {
			Vector3 reversePosition = Vector3.Scale ((target.position - transform.position).normalized, new Vector3 (-1000, -1000, -1000));
			move = Vector3.MoveTowards(transform.position, reversePosition, step);
		} else {
			move = Vector3.MoveTowards(transform.position, target.position, step);
		}
		if (move != transform.position) {
			prev = move;
			transform.position = move;
			lt.intensity += 8 * (pd - (transform.position - target.position).magnitude) / distance;
		} else {
			lt.intensity = 0;
			ScoreDecrement ();
			transform.position = Vector3.MoveTowards (transform.position, transform.position + prev, step);
			Destroy (gameObject);
		}
		travelTime = Time.fixedTime - startTime;
		distanceTraveled = (startPos - transform.position).magnitude;
		rate = distanceTraveled / travelTime;
		estTimeTillArrival = (transform.position - target.position).magnitude / rate;
		timeSinceStartSong = Time.fixedTime;
		estArrivalTime = timeSinceStartSong + estTimeTillArrival;
	}

	void ScoreDecrement() {
		GameObject[] scoreKeepers = GameObject.FindGameObjectsWithTag ("ScoreKeeper");

		foreach (GameObject scoreKeeper in scoreKeepers) {
			scoreKeeper.GetComponent<ScoreKeeper> ().DecrementScore ();
		}
	}

	public void ToggleMoveAwayFromStoppingPoint() {
		reverse = !reverse;
		Collider col = gameObject.GetComponent<Collider> ();
		col.enabled = !col.enabled;
	}
}
