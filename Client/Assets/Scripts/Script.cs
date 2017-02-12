using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script : MonoBehaviour {

	// Distance in meters
	public float distanceOffset;
	public List<note> script;

	[System.Serializable]
	public class note {
		// Define the possible classes of notes
		public enum NoteClass {Burstable, Draggable, Heavy};

		// The note class of this note
		public NoteClass noteClass;

		// This is the time from the start of the script until the object should be in the players range
		public float timeUntilInPlayerRange;
	}
}
