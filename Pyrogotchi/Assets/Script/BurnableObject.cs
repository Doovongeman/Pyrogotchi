using UnityEngine;
using System.Collections;
using SVGImporter;
using DG.Tweening;

public class BurnableObject : MonoBehaviour {

	public float contribute;

	public float contributeTimer = 5f;	// In seconds
	private float sustain;
	private float sustainTimer;
	private float size;
	public float toxicity;
	public bool burning = false;

	private GameObject fire;
	private GameObject lifebar;
	private GameObject healthbar;
	private float contributeBackup;
	private Transform outline;
	private Transform regularShape;
	private BlockDragEvents bde;
	private GameObject negFeedback;


	void Start () {
		fire = GameObject.Find ("Fire");
		lifebar = GameObject.Find ("LifeBar");
		healthbar = GameObject.Find ("HealthBar");
		negFeedback = GameObject.Find("NegativeFeedback");

		size = GetComponentInChildren<Renderer> ().bounds.size.y;
		//outline = gameObject.transform.GetChild(2);
		regularShape = gameObject.transform.GetChild(0);
		bde = GetComponent<BlockDragEvents> ();
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

		healthbar.GetComponent<HealthBar> ().AddToxicity (toxicity);
		if (toxicity > 0) {
			//fire.GetComponent<Fire>().ChangeFace("fire_face_bad");
			negFeedback.GetComponent<NegativeFeedback> ().Pop ("toxic fumes!");
		}

		fire.GetComponent<Fire>().StartGrowing(contribute * 0.5f);
		fire.GetComponent<Fire> ().currentlyBurningSomething = true;
		yield return new WaitForSeconds(contributeTimer);
		lifebar.GetComponent<LifeBar>().HideLifebar();
		fire.GetComponent<Fire>().StopGrowing(contribute * 0.5f);

		//switch to orange business
		//move orange business in front of fire behind outline
		//outline.gameObject.SetActive(false);
		//switch to orange frame
		//regularShape.gameObject.SetActive(false);
		//move in front
		//transform.position = new Vector3(transform.position.x, transform.position.y, bde.infrontofFire);

		healthbar.GetComponent<HealthBar> ().SubstractToxicity (toxicity);
		fire.GetComponent<Fire> ().currentlyBurningSomething = false;
		SustainShrink (sustainTimer + 0.1f);
		//fire.GetComponent<Fire>().StartGrowing(sustain * 0.5f);
		yield return new WaitForSeconds(sustainTimer);
		//fire.GetComponent<Fire>().StopGrowing(sustain * 0.5f);

		//Die ();
	}






	private void CheckIfTooBig()
	{
		if (size > fire.GetComponent<Fire> ().GetSize () + fire.GetComponent<Fire> ().GetSize () * 0.2f) {
			contributeBackup = contribute;

			float sizeDifference = size - fire.GetComponent<Fire> ().size;
			float oversizePercentage = sizeDifference / fire.GetComponent<Fire> ().size * 100;

			if (oversizePercentage > 200) {
				oversizePercentage = 200;
			}

			float penalty = contribute * (oversizePercentage / 100);
			contribute -= penalty;

			negFeedback.GetComponent<NegativeFeedback> ().Pop ("too big!");
		} else {
			if(contribute < 0)
			{
				negFeedback.GetComponent<NegativeFeedback>().Pop("too wet!");
			}
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
		print ("sustain for " + time);
		transform.DOScaleX (0, time).OnComplete(Die);
		transform.DOScaleY (0, time);
	}

}
