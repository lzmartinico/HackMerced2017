using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeHaloSize : MonoBehaviour {

	public float speed;
	public float originalRange;
	public float originalIntensity;
	public Light lt;
	public float past = 0;
  void Start() {
        speed = SphereSpeed.get();
        lt = GetComponent<Light>();
        originalRange = lt.range;
        originalIntensity = lt.intensity;
  }
	void Update() {
		float step = speed * Time.deltaTime;
        lt.range -= step;
		lt.intensity -= step;
		if (lt.range <= 1) {
			Destroy (gameObject);
            // Lose points?
		}
	}
}
