using UnityEngine;
using System.Collections;
using DG.Tweening;

public class BlockDragEvents : MonoBehaviour {

    public Color dragColor;

    protected bool isDragging = false;

	private Rigidbody2D rb2d;
	private SnapBack sb;
	private BurnableObject burnableObject;
	private GameObject fire;
	private bool overTheFire = false;

	void Start() {
		//I set the kinematic thing to true by default so that pulling an object over 
		//another object doesn't make them collide with each other
		rb2d = transform.GetComponent<Rigidbody2D> ();
		rb2d.isKinematic = true;
		sb = transform.GetComponent<SnapBack> ();
		burnableObject = transform.GetComponent<BurnableObject> ();

		fire = GameObject.Find ("Fire");
	}


	void OnStartDrag()
    {
		if (! burnableObject.burning)
		{
			isDragging = true;
			rb2d.isKinematic = false;
			transform.localScale = new Vector2 (1, 1);
			bounce (1f);
		}
		if (fire.GetComponent<Fire> ().currentlyBurningSomething == true)
		{

		}
    }


    void OnStopDrag()
    {
		if (!burnableObject.burning)
		{
			isDragging = false;
			rb2d.isKinematic = true;

			CheckIfInTheFire ();
		}

    }


	private void CheckIfInTheFire()
	{
		if (overTheFire &&  fire.GetComponent<Fire> ().currentlyBurningSomething == false)
		{
			burnableObject.StartBurning ();
			GoToPosition(fire.transform.position, 0.2f);
			bounce (1.2f);
		} else
		{
			GoToPosition(sb.startPosition, 0.2f);
		}
	}


	void OnCollisionEnter2D (Collision2D col)
	{
		if(col.gameObject.name == "Fire")
		{
			overTheFire = true;
		}
	}


	void OnCollisionExit2D (Collision2D col)
	{
		if(col.gameObject.name == "Fire")
		{
			overTheFire = false;
		}
	}


    //You can use a bool to indicate whether the GameObject is currently being dragged.
    void Update()
    {
        if(isDragging)
        {
            //Do stuff while grabbed
        }
    }


	public void bounce(float amount)
	{

		transform.DOScaleY (1.3f * amount, 0.5f).SetEase (Ease.OutElastic).From ();
		transform.DOScaleX (0.8f * amount, 0.5f).SetEase (Ease.OutElastic).From ();
	}


	private void GoToPosition(Vector2 target, float time)
	{
		transform.DOMove (target, time).SetEase(Ease.OutExpo);
	}


}
