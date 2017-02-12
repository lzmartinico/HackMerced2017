using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTimer : MonoBehaviour {

	public float min_time;
	public float max_time;
	private float _life_remaining;

	public DestroyOnTimer (float min, float max) {
		min_time = min;
		max_time = max;
	}

	// Use this for initialization
	void Start () {
		_life_remaining = Random.Range (min_time, max_time);
	}
		
	// Update is called once per frame
	void Update () {
		if (_life_remaining <= 0) {
			Destroy(gameObject);
		} else {
			_life_remaining -= Time.deltaTime;
		}
	}
}
