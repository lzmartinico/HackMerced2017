using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncrementScoreOnInstantiate : MonoBehaviour {

	void Start () {
		GameObject[] scoreKeepers = GameObject.FindGameObjectsWithTag ("ScoreKeeper");

		foreach (GameObject scoreKeeper in scoreKeepers) {
			scoreKeeper.GetComponent<ScoreKeeper> ().IncrementScore ();
		}
	}
}
