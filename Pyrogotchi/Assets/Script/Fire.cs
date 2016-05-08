using UnityEngine;
using System.Collections;
using DG.Tweening;

public class Fire : MonoBehaviour {

	public float decayRate;
	public float size;
	public bool firstObjectBurned = false;
	public bool currentlyBurningSomething = false;

	private bool shouldDecay = true;
	private GameObject happinessbar;
	private GameObject healthbar;
	private GameObject flame0;
	private GameObject flame1;
	private GameObject flame2;
	private GameObject flame3;
	private GameObject face_normal;
	private GameObject face_eating;
	private GameObject face_gimme;
	private GameObject face_bad;
	private GameObject heat;

	void Start()
	{
		flame0 = GameObject.Find ("Fire-1");
		flame1 = GameObject.Find ("Fire-2");
		flame2 = GameObject.Find ("Fire-3");
		flame3 = GameObject.Find ("Fire-4");

		face_normal = GameObject.Find ("fire_face_normal");
		face_eating = GameObject.Find ("fire_face_eating");
		face_bad = GameObject.Find ("fire_face_bad");
		face_gimme = GameObject.Find ("fire_face_gimme");

		size = GetComponentInChildren<Collider2D> ().bounds.size.y;
		StartCoroutine (UpdateDecayRate ());
		StartCoroutine (ChangeFlames ());
		happinessbar = GameObject.Find ("HappinessBar");
		healthbar = GameObject.Find ("HealthBar"); 
		heat = GameObject.Find("fx_heat");
		heat.gameObject.SetActive(false);

		decayRate = -0.5f;
		ChangeFace ("fire_face_normal");
	}




	void Update()
	{
		if (transform.localScale.x <= 0.05f) {
			transform.localScale = new Vector2 (0.05f, 0.05f);
			shouldDecay = false;
			FireDied ();
		}
	}


	IEnumerator UpdateDecayRate()
	{
		while(shouldDecay) 
		{			
			AdjustSize ();
			yield return new WaitForSeconds(0.5f);
		}
	}



	public void StartGrowing(float contribution)
	{
		if(! firstObjectBurned)
		{
			firstObjectBurned = true;
		}
		decayRate += contribution;
		ChangeFace ("fire_face_eating");
	}


	public void StopGrowing(float contribution)
	{
		decayRate -= contribution;
		ChangeFace ("fire_face_normal");
	}


	private void AdjustSize()
	{
		if (firstObjectBurned)
		{
			float compiledDecayRate = decayRate * 0.1f;
			transform.DOScaleX (transform.localScale.x + compiledDecayRate, 0.45f).SetEase (Ease.InOutExpo);
			transform.DOScaleY (transform.localScale.y + compiledDecayRate, 0.45f).SetEase (Ease.InOutExpo);
			happinessbar.GetComponent<HappinessBar> ().UpdateHappiness (transform.localScale.y);


			if (GetSize() > 5) {
				healthbar.GetComponent<HealthBar> ().LoseHealth (0.025f);
				heat.gameObject.SetActive(true);
			} else {
				heat.gameObject.SetActive(false);
			}
		}

	}


	private void FireDied()
	{
		print ("GAME OVER");
		Application.LoadLevel ("YourFireDied");
	}


	public float GetSize()
	{
		size = GetComponentInChildren<Collider2D> ().bounds.size.y;
		return size;
	}



	IEnumerator ChangeFlames()
	{
		while (true)
		{
			int min = 0;
			int max = 4;
			int rand = Random.Range (min, max);

			switch (rand) {
			case 0: 
				flame0.gameObject.SetActive (true);
				flame1.gameObject.SetActive (false);
				flame2.gameObject.SetActive (false);
				flame3.gameObject.SetActive (false);
				break;
			case 1:
				flame0.gameObject.SetActive (false);
				flame1.gameObject.SetActive (true);
				flame2.gameObject.SetActive (false);
				flame3.gameObject.SetActive (false);
				break;
			case 2:
				flame0.gameObject.SetActive (false);
				flame1.gameObject.SetActive (false);
				flame2.gameObject.SetActive (true);
				flame3.gameObject.SetActive (false);
				break;
			case 3:
				flame0.gameObject.SetActive (false);
				flame1.gameObject.SetActive (false);
				flame2.gameObject.SetActive (false);
				flame3.gameObject.SetActive (true);
				break;
			}
			yield return new WaitForSeconds (0.1f);
		}
	}


	public void ChangeFace(string faceName)
	{
		switch (faceName) {
		case "fire_face_normal": 
			face_normal.gameObject.SetActive (true);
			face_eating.gameObject.SetActive (false);
			face_gimme.gameObject.SetActive (false);
			face_bad.gameObject.SetActive (false);
			break;
		case "fire_face_eating":
			face_normal.gameObject.SetActive (false);
			face_eating.gameObject.SetActive (true);
			face_gimme.gameObject.SetActive (false);
			face_bad.gameObject.SetActive (false);
			break;
		case "fire_face_bad":
			face_normal.gameObject.SetActive (false);
			face_eating.gameObject.SetActive (false);
			face_gimme.gameObject.SetActive (false);
			face_bad.gameObject.SetActive (true);
			break;
		case "fire_face_gimme":
			face_normal.gameObject.SetActive (false);
			face_eating.gameObject.SetActive (false);
			face_gimme.gameObject.SetActive (true);
			face_bad.gameObject.SetActive (false);
			break;
		}
	}


}
