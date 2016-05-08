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
	private float face1percent;
	private float face2percent;
	private float face3percent;


	void Start () {
		happinessfilling = GameObject.Find ("HappinessFilling");
		face0 = GameObject.Find ("happy0");
		face1 = GameObject.Find ("happy1");
		face2 = GameObject.Find ("happy2");
		face3 = GameObject.Find ("happy3");
		scoreText = GameObject.Find ("CurrentScore");
		score = 0;
		face1percent = 0.05f;
		face2percent = 0.15f;
		face3percent = 0.25f;
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

		if (percentage < face1percent) {
			face0.gameObject.SetActive (true);
			face1.gameObject.SetActive (false);
			face2.gameObject.SetActive (false);
			face3.gameObject.SetActive (false);
		} else if(percentage > face1percent && percentage < face2percent ){
			face0.gameObject.SetActive (false);
			face1.gameObject.SetActive (true);
			face2.gameObject.SetActive (false);
			face3.gameObject.SetActive (false);
		} else if(percentage > face2percent && percentage < face3percent ){
			face0.gameObject.SetActive (false);
			face1.gameObject.SetActive (false);
			face2.gameObject.SetActive (true);
			face3.gameObject.SetActive (false);
		} else if(percentage > face3percent){
			face0.gameObject.SetActive (false);
			face1.gameObject.SetActive (false);
			face2.gameObject.SetActive (false);
			face3.gameObject.SetActive (true);
		}
	}


}
