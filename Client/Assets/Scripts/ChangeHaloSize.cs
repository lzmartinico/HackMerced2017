using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeHaloSize : MonoBehaviour {

	public Transform target;
	public float speed;
	public float originalRange;
	public float originalIntensity;
	public Light lt;
	public float past = 0;
  void Start() {
         lt = GetComponent<Light>();
         originalRange = lt.range;
		originalIntensity = lt.intensity;
  }
	void Update() {
		past += Time.deltaTime;
		float step = speed * past;
	  lt.range = originalRange-step;
		lt.intensity = originalIntensity - step;
		if (lt.range <= 1) {
			Destroy (gameObject);
		}
	}
}
