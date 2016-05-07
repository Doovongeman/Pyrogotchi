using UnityEngine;
using System.Collections;
using DG.Tweening;

public class FlameFaceBounce : MonoBehaviour {


	void Start () {
		//Bounce ();
		BounceY ();
		Move ();
	}


	private void Bounce()
	{
		transform.DOScale (Random.Range (1, 1.6f), Random.Range (2f, 3f)).OnComplete (Bounce).SetEase(Ease.InOutQuad);
	}

	private void BounceY()
	{
		transform.DOScaleY (Random.Range (0.9f, 1.1f), Random.Range (0.15f, 0.6f)).OnComplete (BounceY).SetEase(Ease.Flash);
	}

	private void Move()
	{
		transform.DOMoveX (Random.Range (transform.position.x - 0.1f, transform.position.x + 0.1f), Random.Range (2f, 3f)).OnComplete (Move).SetEase(Ease.InOutQuad);
	}



}
