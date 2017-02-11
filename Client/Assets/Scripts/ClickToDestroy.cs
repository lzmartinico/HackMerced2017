using UnityEngine;
using System.Collections;

public class ClickToDestroy : MonoBehaviour
{
	void OnMouseOver () {
		if (Input.GetMouseButtonDown(1)) {
			Destroy(gameObject);
		}
	}
}