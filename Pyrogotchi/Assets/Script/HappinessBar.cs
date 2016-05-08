using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;

public class HappinessBar : MonoBehaviour {

	public float score;

	private GameObject happinessfilling;
	private GameObject face0;
	private GameObject face1;
	private GameObject face2;
	private GameObject face3;
	private GameObject scoreText;



	void Start () {
		happinessfilling = GameObject.Find ("HappinessFilling");
		face0 = GameObject.Find ("happy0");
		face1 = GameObject.Find ("happy1");
		face2 = GameObject.Find ("happy2");
		face3 = GameObject.Find ("happy3");
		scoreText = GameObject.Find ("CurrentScore");
		score = 0;
	}



	public void UpdateHappiness(float fireSize)
	{
		float max = 6;
		float min = 1;
		float range = max - min;
		float progress = fireSize - min;
		float percentage = progress / range;
		percentage = Mathf.Clamp (percentage, 0, 1);
		happinessfilling.transform.DOScaleX (Mathf.Clamp (percentage, 0, 1), 0.45f);

		score += Mathf.RoundToInt(percentage * 100);
		scoreText.GetComponent<Text> ().text = score+"";

		if (percentage < 0.30) {
			face0.gameObject.SetActive (true);
			face1.gameObject.SetActive (false);
			face2.gameObject.SetActive (false);
			face3.gameObject.SetActive (false);
		} else if(percentage > 0.30 && percentage < 0.60 ){
			face0.gameObject.SetActive (false);
			face1.gameObject.SetActive (true);
			face2.gameObject.SetActive (false);
			face3.gameObject.SetActive (false);
		} else if(percentage > 0.60 && percentage < 0.90 ){
			face0.gameObject.SetActive (false);
			face1.gameObject.SetActive (false);
			face2.gameObject.SetActive (true);
			face3.gameObject.SetActive (false);
		} else if(percentage > 0.90){
			face0.gameObject.SetActive (false);
			face1.gameObject.SetActive (false);
			face2.gameObject.SetActive (false);
			face3.gameObject.SetActive (true);
		}
	}


}
