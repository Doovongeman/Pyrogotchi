using UnityEngine;
using System.Collections;

public class BurnableObject : MonoBehaviour {

	public float contribute;
	public float contributeTimer = 5f;	// In seconds
	public float sustain;
	public float sustainTimer;
	public float size;

	private GameObject fire;
	private bool burning = false;


	void Start () {
		fire = GameObject.Find ("Fire");
	}



	public void StartBurning()
	{
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
