using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInDirection : MonoBehaviour {

	public Vector3 direction;
	private Vector3 position;

	void Start() {
		position = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.position = Vector3.MoveTowards 
			(position, position + direction, 500*Time.deltaTime);
	}


}
