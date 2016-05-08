using UnityEngine;
using System.Collections;
using DG.Tweening;

public class NegativeFeedback : MonoBehaviour {


	private Vector3 originalPosition;


	// Use this for initialization
	void Start () {
		originalPosition = transform.position;
		hide ();
	}
	


	public void Pop(string text)
	{
		transform.position = originalPosition;
		gameObject.GetComponent<TextMesh>().text  = text;
		transform.DOScale (0, 2.5f).SetEase (Ease.OutElastic).From ().OnComplete (hide);
		print ("popped");
	}



	public void hide()
	{
		transform.position = new Vector3 (-100,-100, transform.position.z);
	}


}
