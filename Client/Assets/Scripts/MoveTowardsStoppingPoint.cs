using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsStoppingPoint : MonoBehaviour {

	public float speed;
	public Transform target;
	private Light lt;
	private float distance;
	private Vector3 prev;
	public bool reverse = false;

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
