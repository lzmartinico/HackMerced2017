using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scripted_Sphere_Spawner : MonoBehaviour {

	public GameObject object_to_spawn;
	public Script script;

	private float _startTime;
	private Transform cameraTransform;
	private SphereCollider sphereCollider;
	// Calculated using MoveTowardsStoppingPointDebug
	private static float TRAVEL_RATE_CONSTANT = 17;

	void Start () {

		GameObject[] mainCameras = GameObject.FindGameObjectsWithTag ("MainCamera");
		// There should only be one camera, But if there is more than one choosing one from them seems okay
		int index = Random.Range (0, mainCameras.Length);
		cameraTransform = mainCameras [index].transform;

		sphereCollider = (SphereCollider)GetComponent<Collider> ();

		_startTime = Time.fixedTime;
		Initilize ();
	}

	void Initilize() {
		foreach (Script.note note in script.script) {
			StartCoroutine(SpawnObject (note));
		}
	}

	IEnumerator SpawnObject(Script.note note) {
		NoteInstance noteInstance = new NoteInstance (note,_startTime,cameraTransform.position,sphereCollider.radius,transform.position,script.distanceOffset);

		if (noteInstance.timeToSpare > 0) {
			// Wait spare time before continuing
			yield return new WaitForSeconds (noteInstance.timeToSpare);
		} else {
			print ("The Scripted Spawner was instantiated too far!");
			print ("There was not enough time to deliver a note.");
		}

		// Spawn the note
		GameObject obj = Instantiate (object_to_spawn, noteInstance.spawnLocation, Random.rotation, transform);
		InitizlizeMaterialType (obj, note.noteClass);
	}

	private class NoteInstance {
		public Vector3 spawnLocation;
		public float timeToSpare;

		public NoteInstance(Script.note note, float startTime, Vector3 cameraPosition,float radius,Vector3 spawnerLocation,float distanceOffset) {
			// Choose a random location within the unit sphere
			Vector3 location = Random.insideUnitSphere * radius;
			// Center the random location around the Scripted_SpehereSpawner
			spawnLocation = new Vector3(location.x + spawnerLocation.x, location.y + spawnerLocation.y, location.z + spawnerLocation.z);

			// Estimate how much time is required to travel from spawn to target
			float timeRequiredUntilReachedCamera = (cameraPosition - location).magnitude / TRAVEL_RATE_CONSTANT;

			// Calculate desired arrival time 
			float desiredArrival = startTime + note.timeUntilInPlayerRange + (distanceOffset / TRAVEL_RATE_CONSTANT);

			// The time that we have until the note must be delivered
			float timeAvailable = desiredArrival - Time.fixedTime;

			// Calculate how much we have to spare
			timeToSpare = timeAvailable - timeRequiredUntilReachedCamera;
		}
	}

	void reference(float wait_time) {
		
		// Choose a random location within the unit sphere
		Vector3 location = Random.insideUnitSphere * ((SphereCollider) GetComponent<Collider>()).radius;
		// Center the random location around the SpehereSpawner
		location = new Vector3(location.x + transform.position.x, location.y + transform.position.y, location.z + transform.position.z);

	}

	void InitizlizeMaterialType(GameObject obj,Script.note.NoteClass noteclass) {
		ObjectWasHit objectWasHit = obj.GetComponent<ObjectWasHit> ();
		objectWasHit.UpdateNoteClass (noteclass);
	}
}
