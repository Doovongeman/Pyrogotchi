using UnityEngine;
using System.Collections;
using SVGImporter;
using DG.Tweening;

public class BurnableObject : MonoBehaviour {

	public float contribute;

	public float contributeTimer = 5f;	// In seconds
	public float sustain;
	public float sustainTimer;
	public float size;
	public bool burning = false;

	private GameObject fire;
	private GameObject lifebar;
	private float contributeBackup;


	void Start () {
		fire = GameObject.Find ("Fire");
		lifebar = GameObject.Find ("LifeBar");

		size = GetComponentInChildren<Renderer> ().bounds.size.y;

		contributeBackup = contribute;
	}



	public void StartBurning()
	{
		burning = true;
		CheckIfTooBig ();
		transform.GetComponentInChildren<SVGRenderer> ().color = new Color32 (155, 155, 155, 255);
		StartCoroutine(Burn ());
		print ("IM BURNING");
	}



	IEnumerator Burn()
	{
		lifebar.GetComponent<LifeBar>().ShowLifebar(gameObject);
		lifebar.GetComponent<LifeBar> ().FillLifebar (contributeTimer);

		fire.GetComponent<Fire>().StartGrowing(contribute * 0.5f);
		fire.GetComponent<Fire> ().currentlyBurningSomething = true;
		yield return new WaitForSeconds(contributeTimer);
		lifebar.GetComponent<LifeBar>().HideLifebar();
		fire.GetComponent<Fire>().StopGrowing(contribute * 0.5f);

		fire.GetComponent<Fire> ().currentlyBurningSomething = false;
		SustainShrink (sustainTimer);
		fire.GetComponent<Fire>().StartGrowing(sustain * 0.5f);
		yield return new WaitForSeconds(sustainTimer);
		fire.GetComponent<Fire>().StopGrowing(sustain * 0.5f);

		//Die ();
	}






	private void CheckIfTooBig()
	{
		if(size > fire.GetComponent<Fire>().GetSize() + fire.GetComponent<Fire>().GetSize() * 0.2f)
		{
			contributeBackup = contribute;

			float sizeDifference = size - fire.GetComponent<Fire>().size;
			float oversizePercentage = sizeDifference / fire.GetComponent<Fire> ().size * 100;

			if(oversizePercentage > 200)
			{
				oversizePercentage = 200;
			}

			float penalty = contribute * (oversizePercentage / 100);
			contribute -= penalty;
		}
	}


	public void RemoveFromFire()
	{
		contribute = contributeBackup;
	}



	public void  Die()
	{
		Destroy (gameObject);
	}


	private void SustainShrink(float time)
	{
		transform.DOScaleX (0, time).OnComplete(Die);
		transform.DOScaleY (0, time);
	}

}
