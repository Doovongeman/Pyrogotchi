using UnityEngine;
using System.Collections;
using DG.Tweening;

public class FlameBounce : MonoBehaviour {


	void Start () {
		BounceY ();
		BounceX ();

	}


	private void BounceY()
	{
		transform.DOScaleY (Random.Range (1, 1.3f), Random.Range (0.15f, 0.6f)).OnComplete (BounceY).SetEase(Ease.Flash);
	}

	private void BounceX()
	{
		transform.DOScaleX (Random.Range (1, 1.3f), Random.Range (0.15f, 0.6f)).OnComplete (BounceX).SetEase(Ease.Flash);
	}



}
