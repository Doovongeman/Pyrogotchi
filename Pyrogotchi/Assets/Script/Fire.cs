using UnityEngine;
using System.Collections;
using DG.Tweening;

public class Fire : MonoBehaviour {

	public float decayRate = -0.1f;

	private bool shouldDecay = true;


	void Start()
	{
		StartCoroutine (UpdateDecayRate());
	}



	void Update()
	{
		
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
		decayRate += contribution;
	}


	public void StopGrowing(float contribution)
	{
		decayRate -= contribution;
	}


	private void AdjustSize()
	{
		float compiledDecayRate = decayRate * 0.1f;
		transform.DOScaleX (transform.localScale.x + compiledDecayRate, 0.45f).SetEase (Ease.InOutExpo);
		transform.DOScaleY (transform.localScale.y + compiledDecayRate, 0.45f).SetEase (Ease.InOutExpo);

		if(transform.localScale.x <= 0.1f)
		{
			shouldDecay = false;
			FireDied ();
		}

	}


	private void FireDied()
	{
		print ("GAME OVER");
	}





}
