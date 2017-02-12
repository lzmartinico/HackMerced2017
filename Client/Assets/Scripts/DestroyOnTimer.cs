using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTimer : MonoBehaviour {

	public float min_time = 0.5f;
	public float max_time = 2.0f;
	private float _life_remaining;
	
	public DestroyOnTimer (float min_time, float max_time) {
		this.min_time = min_time;
		this.max_time = max_time;
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
