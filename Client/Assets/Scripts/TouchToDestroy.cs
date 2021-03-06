using UnityEngine;
using System.Collections;
using Leap.Unity;
using System;

public class TouchToDestroy : MonoBehaviour
{ 
	public GameObject Cube_Fragments;

	private HandModel GetHand(Collider other) {
		if (other.transform.parent && other.transform.parent.parent && other.transform.parent.parent.GetComponent<HandModel>()) {
			return other.transform.parent.parent.GetComponent<HandModel>();
		} else {
			return null;
		}
	}
	void OnTriggerEnter(Collider other) {
//		if (other.CompareTag ("destroyer")) {
//			Instantiate(Cube_Fragments, transform.position, transform.rotation);
//			Destroy(gameObject);
//		}
//		Debug.Log("OnTriggerEnter");
		HandModel handModel = GetHand(other);
		if (handModel != null) {
			gameObject.GetComponent<ObjectWasHit> ().ReactToHit();
//			Instantiate(Cube_Fragments, transform.position, transform.rotation);
//			Destroy(gameObject);
		}
	}
}