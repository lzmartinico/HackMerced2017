using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour {

	public GameObject IncrementLabel;
	public Text score_count;
	public Vector3 position;
	public Quaternion rotation;
	private int score = 0;
	private Transform parent;

	void Start() {
		parent = GameObject.FindGameObjectWithTag ("UICanvas").transform;
	}

	public void IncrementScore(){
		score += 1;
		score_count.text = score.ToString();
		GameObject incScore = Instantiate (IncrementLabel, parent.transform.position, new Quaternion(), parent);
		MoveInDirection move = incScore.AddComponent<MoveInDirection> ();
		move.direction = Vector3.up;
		DestroyOnTimer d = incScore.AddComponent<DestroyOnTimer>();
		d.min_time = 1.0f;
		d.max_time = 2.0f;
	}

	public void DecrementScore(){
		score -= 1;
		score_count.text = score.ToString();
	}
}
