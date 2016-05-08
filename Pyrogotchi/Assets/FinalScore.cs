using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour {
	private GameObject scoreText;
	private float finalScore;
	public float highscore;

	// Use this for initialization
	void Start () {
		highscore = HappinessBar.highscore;
		scoreText = GameObject.Find ("CurrentScore");
		finalScore = HappinessBar.score;
		scoreText.GetComponent<Text> ().text = "Final Score: "+finalScore+"";
//		if (finalScore > highscore) {
//			highscore = finalScore;
//			scoreText.GetComponent<Text> ().text = "New High Score! " + finalScore + "";
//		} else {
//			scoreText.GetComponent<Text> ().text = "Final Score: "+finalScore+"";
//		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
