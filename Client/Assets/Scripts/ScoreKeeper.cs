using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour {

	public GameObject IncrementLabel;
	public GameObject DecrementLabel;
	public Text score_count;
	public float spawnDistance = 3f;
	private Quaternion rotation;
	private int score = 0;
	private Transform parent;

	void Start() {
		parent = GameObject.FindGameObjectWithTag ("UICanvas").transform;
	}

	public void IncrementScore(){
		score += 1;
		score_count.text = score.ToString();
		Vector3 nearbyLocation = NearbyLocation (parent.transform.position,spawnDistance);
		GameObject incScore = Instantiate (IncrementLabel, nearbyLocation, new Quaternion(), parent);
		MoveInDirection move = incScore.AddComponent<MoveInDirection> ();
		move.direction = Vector3.up;
		DestroyOnTimer d = incScore.AddComponent<DestroyOnTimer>();
		d.min_time = 1.0f;
		d.max_time = 2.0f;
	}

	public void DecrementScore(){
		score -= 1;
		score_count.text = score.ToString();
		Vector3 nearbyLocation = NearbyLocation (parent.transform.position,spawnDistance);
		GameObject decScore = Instantiate (DecrementLabel, nearbyLocation, new Quaternion(), parent);
		MoveInDirection move = decScore.AddComponent<MoveInDirection> ();
		move.direction = Vector3.down;
		DestroyOnTimer d = decScore.AddComponent<DestroyOnTimer>();
		d.min_time = 1.0f;
		d.max_time = 2.0f;
	}

	public Vector3 NearbyLocation(Vector3 parentLocation, float distanceFromParentLocation) {
		// Choose a random location within distanceFromParentLocation
		Vector3 randLocation = Random.insideUnitSphere * distanceFromParentLocation;
		// Center the random location around the parentLocation
		return new Vector3(randLocation.x + parentLocation.x, randLocation.y + parentLocation.y, randLocation.z + parentLocation.z);
	}
}
