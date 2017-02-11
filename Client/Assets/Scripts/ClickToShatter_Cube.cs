using UnityEngine;
using System.Collections;

public class ClickToShatter_Cube : MonoBehaviour
{
	public GameObject Cube_Fragments;
	void OnMouseOver () {
		if (Input.GetMouseButtonDown(1)) {
			Instantiate(Cube_Fragments, transform.position, transform.rotation);
			Destroy(gameObject);
		}
	}
}