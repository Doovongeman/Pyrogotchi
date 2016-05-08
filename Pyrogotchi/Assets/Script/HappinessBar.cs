using UnityEngine;
using System.Collections;
using DG.Tweening;

public class HappinessBar : MonoBehaviour {


	private GameObject happinessfilling;
	private GameObject face0;
	private GameObject face1;
	private GameObject face2;
	private GameObject face3;




	void Start () {
		happinessfilling = GameObject.Find ("HappinessFilling");
		face0 = GameObject.Find ("happy0");
		face1 = GameObject.Find ("happy1");
		face2 = GameObject.Find ("happy2");
		face3 = GameObject.Find ("happy3");
	}



	public void UpdateHappiness(float fireSize)
	{
		float max = 6;
		float min = 1;
		float range = max - min;
		float progress = fireSize - min;
		float percentage = progress / range;
		happinessfilling.transform.DOScaleX (Mathf.Clamp (percentage, 0, 1), 0.45f);

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
