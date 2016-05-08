using UnityEngine;
using System.Collections;
using SVGImporter;

public class BurnableObject : MonoBehaviour {

	public float contribute;

	public float contributeTimer = 5f;	// In seconds
	public float sustain;
	public float sustainTimer;
	public float size;
	public bool burning = false;

	private GameObject fire;
	private float contributeBackup;
	private Transform outline;
	private Transform regularShape;
	private BlockDragEvents bde;


	void Start () {
		fire = GameObject.Find ("Fire");
		size = GetComponentInChildren<Renderer> ().bounds.size.y;
		outline = gameObject.transform.GetChild(2);
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
		fire.GetComponent<Fire>().StartGrowing(contribute * 0.5f);
		yield return new WaitForSeconds(contributeTimer);
		fire.GetComponent<Fire>().StopGrowing(contribute * 0.5f);

		//switch to orange business
		//move orange business in front of fire behind outline
		outline.gameObject.SetActive(false);
		//switch to orange frame
		regularShape.gameObject.SetActive(false);
		//move in front
		transform.position = new Vector3(transform.position.x, transform.position.y, bde.infrontofFire);
		fire.GetComponent<Fire>().StartGrowing(sustain * 0.5f);
		yield return new WaitForSeconds(sustainTimer);
		fire.GetComponent<Fire>().StopGrowing(sustain * 0.5f);

		Die ();
	}



	private void CheckIfTooBig()
	{
		if(size > fire.GetComponent<Fire>().GetSize() + fire.GetComponent<Fire>().GetSize() * 0.1f)
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


}
