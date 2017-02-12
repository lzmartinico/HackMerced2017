using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectWasHit : MonoBehaviour {

	public enum ObjectClass {Burstable, Heavy};

	public ObjectClass objectClass = ObjectClass.Burstable;
	public GameObject score_particle;

	public Material defaultMaterial;
	public Material burstableMaterial;
	public Material heavyMaterial;

	void Start() {
		UpdateObjectClass (objectClass);
	}

	public void UpdateObjectClass(ObjectClass objectClass) {
		this.objectClass = objectClass;
		switch (objectClass) {
		case(ObjectClass.Burstable):
			GetComponent<Renderer> ().material = burstableMaterial;
			break;
		case(ObjectClass.Heavy):
			GetComponent<Renderer> ().material = heavyMaterial;
			break;
		default:
			GetComponent<Renderer> ().material = defaultMaterial;
			break;
		}
	}

	public void ReactToHit() {

		switch (objectClass) {
		case(ObjectClass.Burstable):
			Collider col = gameObject.GetComponent<Collider> ();
			col.enabled = !col.enabled;
			Instantiate(score_particle, transform.position, transform.rotation);
			Destroy(gameObject);
			break;
		case(ObjectClass.Heavy):
			MoveTowardsStoppingPoint moveTowardsStoppingPoint = gameObject.GetComponent<MoveTowardsStoppingPoint> ();
			moveTowardsStoppingPoint.ToggleMoveAwayFromStoppingPoint ();
			ReverseOnTimer reverseOnTimer = gameObject.AddComponent<ReverseOnTimer> ();
			reverseOnTimer._reverse_time = 0.1f;
			UpdateObjectClass (ObjectClass.Burstable);
//			DestroyOnTimer destroyOnTimer = gameObject.AddComponent<DestroyOnTimer>();
//			destroyOnTimer = new DestroyOnTimer(30,35);
			break;
		default:
			break;
		}
	}

}
