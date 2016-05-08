using UnityEngine;
using System.Collections;
using DG.Tweening;

public class LifeBar : MonoBehaviour {


	private GameObject fire;
	private GameObject filling;


	// Use this for initialization
	void Start () {
		fire = GameObject.Find ("Fire");
		filling = GameObject.Find ("Filling");
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void ShowLifebar(GameObject obj)
	{
		float objectSize = obj.GetComponentInChildren<Renderer> ().bounds.size.y;
		transform.position = new Vector3 (fire.transform.position.x, fire.transform.position.y + objectSize + 0.5f, -9);
		transform.DOMoveY (transform.position.y + 1, 1f).SetEase (Ease.OutElastic).From();
	}


	public void HideLifebar()
	{
		filling.transform.localScale = new Vector3 (0, 1, 1);
		transform.position = new Vector3 (-100, -100, -9);
	}



	public void FillLifebar(float time)
	{
		filling.transform.DOScaleX (1, time).SetEase (Ease.OutSine);
	}
}
