using UnityEngine;
using System.Collections;

public class Fire : MonoBehaviour {

	public float decayRate = -0.1f;




	void Start()
	{
		StartCoroutine (UpdateDecayRate());
	}



	void Update()
	{
		AdjustSize ();
	}


	IEnumerator UpdateDecayRate()
	{
		while(true) 
		{ 
			//AdjustSize ();
			yield return new WaitForSeconds(1);
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
		print (decayRate);
	}




}
