using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour {

	public Text score_count;
	private int score = 0;

	public void IncrementScore(){
		score += 1;
		score_count.text = score.ToString();
	}

	public void DecrementScore(){
		score -= 1;
		score_count.text = score.ToString();
	}
}
