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


	void Start()
	{
		decayRate = -0.5f;
		size = GetComponent<Collider2D> ().bounds.size.y;
		StartCoroutine (UpdateDecayRate());
		happinessbar = GameObject.Find ("HappinessBar");
	}



	void Update()
	{
		if (transform.localScale.x <= 0.1f) {
			transform.localScale = new Vector2 (0.1f, 0.1f);
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
	}


	public void StopGrowing(float contribution)
	{
		decayRate -= contribution;
	}


	private void AdjustSize()
	{
		if (firstObjectBurned)
		{
			float compiledDecayRate = decayRate * 0.1f;
			transform.DOScaleX (transform.localScale.x + compiledDecayRate, 0.45f).SetEase (Ease.InOutExpo);
			transform.DOScaleY (transform.localScale.y + compiledDecayRate, 0.45f).SetEase (Ease.InOutExpo);
			happinessbar.GetComponent<HappinessBar> ().UpdateHappiness (transform.localScale.y);
		}

	}


	private void FireDied()
	{
		print ("GAME OVER");
	}


	public float GetSize()
	{
		size = GetComponent<Collider2D> ().bounds.size.y;
		return size;
	}




}
