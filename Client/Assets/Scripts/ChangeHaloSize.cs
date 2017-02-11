using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeHaloSize : MonoBehaviour {

	public Transform target;
	public float speed;
	public float originalRange;
	public Light lt;
	public float past = 0;
  void Start() {
         lt = GetComponent<Light>();
         originalRange = lt.range;
				 Debug.Log(originalRange);
  }
	void Update() {
		past += Time.deltaTime;
		float step = speed * past;
	  lt.range = originalRange-step;
		if (lt.range <= 0) {
			Destroy (gameObject);
		}
	}
}
