using UnityEngine;
using System.Collections;

public class ClickToDestroy : MonoBehaviour
{
	void OnMouseOver () {
		if (Input.GetMouseButtonDown(1)) {
			gameObject.GetComponent<ObjectWasHit> ().ReactToHit();
//			Destroy(gameObject);
		}
	}
}