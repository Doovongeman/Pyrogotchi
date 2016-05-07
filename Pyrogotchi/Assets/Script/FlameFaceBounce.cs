using UnityEngine;
using System.Collections;
using DG.Tweening;

public class FlameFaceBounce : MonoBehaviour {


	void Start () {
		//Bounce ();
		BounceY ();
		//Move ();
	}


	private void Bounce()
	{
		transform.DOScale (Random.Range (1, 1.6f), Random.Range (2f, 3f)).OnComplete (Bounce).SetEase(Ease.InOutQuad);
	}

	private void BounceY()
	{
		transform.DOScaleY (Random.Range (1f, 1.2f), Random.Range (0.15f, 0.6f)).OnComplete (BounceY).SetEase(Ease.Flash);
	}

	private void Move()
	{
		transform.DOMoveX (Random.Range (transform.position.x - 0.04f, transform.position.x + 0.04f), Random.Range (2f, 3f)).OnComplete (Move).SetEase(Ease.InOutQuad);
	}



}
