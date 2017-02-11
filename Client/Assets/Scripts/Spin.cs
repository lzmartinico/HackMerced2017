using UnityEngine;
using System.Collections;

public class Spin : MonoBehaviour
{
	public float speed = 10f;

	void Update ()
	{
		transform.Rotate(Vector3.up, speed * Time.deltaTime);
		transform.Rotate(Vector3.left, speed * Time.deltaTime);
	}
}