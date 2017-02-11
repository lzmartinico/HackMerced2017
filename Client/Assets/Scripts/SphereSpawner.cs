using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereSpawner: MonoBehaviour {
	
	//Minimum time to wait before spawning the next random object (in seconds)
	public float min_time_between_spawn = 3.0f;
	//max time to wait before spawning the next random object (in seconds)
	public float max_time_between_spawn = 10.0f;
	public GameObject object_to_spawn;

	void Start () {
		InitializeNextSpawn ();
	}

	void InitializeNextSpawn() {
		StartCoroutine(SpawnObject (Random.Range (min_time_between_spawn, max_time_between_spawn)));
	}

	IEnumerator SpawnObject(float wait_time) {
		// Wait for wait_time before moving on
		yield return new WaitForSeconds (wait_time);

		// Choose a random location within the unit sphere
		Vector3 location = Random.insideUnitSphere * ((SphereCollider) GetComponent<Collider>()).radius;
		// Center the random location around the SpehereSpawner
		location = new Vector3(location.x + transform.position.x, location.y + transform.position.y, location.z + transform.position.z);

		// Spawn the actual object
		Instantiate (object_to_spawn, location, Random.rotation, transform);

		// Tell the next object to spawn
		InitializeNextSpawn ();
	}
}
