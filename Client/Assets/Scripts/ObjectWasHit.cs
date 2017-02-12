using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectWasHit : MonoBehaviour {

	public enum ObjectClass {Burstable, Heavy};

	public Script.note.NoteClass noteClass = Script.note.NoteClass.Burstable;
	public GameObject score_particle;

	public Material defaultMaterial;
	public Material burstableMaterial;
	public Material heavyMaterial;

	void Start() {
		UpdateNoteClass (noteClass);
	}

	public void UpdateNoteClass(Script.note.NoteClass noteClass) {
		this.noteClass = noteClass;
		switch (noteClass) {
		case(Script.note.NoteClass.Burstable):
			GetComponent<Renderer> ().material = burstableMaterial;
			break;
		case(Script.note.NoteClass.Heavy):
			GetComponent<Renderer> ().material = heavyMaterial;
			break;
		default:
			GetComponent<Renderer> ().material = defaultMaterial;
			break;
		}
	}

	public void ReactToHit() {

		switch (noteClass) {
		case(Script.note.NoteClass.Burstable):
			Collider col = gameObject.GetComponent<Collider> ();
			col.enabled = !col.enabled;
			Instantiate(score_particle, transform.position, transform.rotation);
			Destroy(gameObject);
			break;
		case(Script.note.NoteClass.Heavy):
			MoveTowardsStoppingPoint moveTowardsStoppingPoint = gameObject.GetComponent<MoveTowardsStoppingPoint> ();
			moveTowardsStoppingPoint.ToggleMoveAwayFromStoppingPoint ();
			ReverseOnTimer reverseOnTimer = gameObject.AddComponent<ReverseOnTimer> ();
			reverseOnTimer._reverse_time = 0.1f;
			UpdateNoteClass (Script.note.NoteClass.Burstable);
			break;
		default:
			break;
		}
	}

}
