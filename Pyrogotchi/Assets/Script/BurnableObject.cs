using UnityEngine;
using System.Collections;
using SVGImporter;

public class BurnableObject : MonoBehaviour {

	public float contribute;
	public float contributeTimer = 5f;	// In seconds
	public float sustain;
	public float sustainTimer;
	public float size;
	public  bool burning = false;

	private GameObject fire;


	void Start () {
		fire = GameObject.Find ("Fire");
	}



	public void StartBurning()
	{
		burning = true;
		transform.GetComponentInChildren<SVGRenderer> ().color = new Color32 (155, 155, 155, 255);
		StartCoroutine(Burn ());
		print ("IM BURNING");
	}



	IEnumerator Burn()
	{
		fire.GetComponent<Fire>().StartGrowing(contribute);
		yield return new WaitForSeconds(contributeTimer);
		fire.GetComponent<Fire>().StopGrowing(contribute);

		fire.GetComponent<Fire>().StartGrowing(sustain);
		yield return new WaitForSeconds(sustainTimer);
		fire.GetComponent<Fire>().StopGrowing(sustain);

		Die ();
	}



	public void  Die()
	{
		Destroy (gameObject);
	}


}
