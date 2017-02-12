using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseOnTimer : MonoBehaviour {

	public float _reverse_time;

	public ReverseOnTimer (float reverse_time) {
		_reverse_time = reverse_time;
	}

	// Update is called once per frame
	void Update () {
		if (_reverse_time <= 0) {
			MoveTowardsStoppingPoint moveTowardsStoppingPoint = gameObject.GetComponent<MoveTowardsStoppingPoint> ();
			moveTowardsStoppingPoint.ToggleMoveAwayFromStoppingPoint ();
			Destroy (GetComponent<ReverseOnTimer> ());
		} else {
			_reverse_time -= Time.deltaTime;
		}
	}
}
