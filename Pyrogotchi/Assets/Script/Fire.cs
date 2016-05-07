using UnityEngine;
using System.Collections;
using DG.Tweening;

public class Fire : MonoBehaviour {

	public float decayRate = -0.1f;



	void Start()
	{
		StartCoroutine (UpdateDecayRate());
	}



	void Update()
	{
		
	}


	IEnumerator UpdateDecayRate()
	{
		while(true) 
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
		transform.DOScale (new Vector2 (transform.localScale.x + compiledDecayRate, transform.localScale.y + compiledDecayRate), 0.45f).SetEase (Ease.InOutExpo);
	}




}
