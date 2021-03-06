﻿using UnityEngine;
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

	//z values
	public float behindFire;
	public float infrontofFire;
	public float infrontofFace;
	private float infrontofObjects;

	void Start() {
		//I set the kinematic thing to true by default so that pulling an object over 
		//another object doesn't make them collide with each other
		rb2d = transform.GetComponent<Rigidbody2D> ();
		rb2d.isKinematic = true;
		sb = transform.GetComponent<SnapBack> ();
		burnableObject = transform.GetComponent<BurnableObject> ();
		behindFire = 1.14f;//1.28f;
		infrontofFire = 0.62f;
		infrontofFace = -2.0f;
		infrontofObjects = -0.1f;

		fire = GameObject.Find ("Fire");
	}


	void OnStartDrag()
    {
		//push forward
		transform.position = new Vector3(transform.position.x, transform.position.y, infrontofFace);
		if (! burnableObject.burning)
		{
			isDragging = true;
			rb2d.isKinematic = false;
			transform.localScale = new Vector3(1,1,1);
			bounce (1f);
		}
		if (fire.GetComponent<Fire> ().currentlyBurningSomething == false)
		{
			fire.GetComponent<Fire> ().ChangeFace ("fire_face_gimme");
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
			//GoToPosition(fire.transform.position, 0.2f);
			//move behind fire, while outline stays in front
			GoToPosition(new Vector3(fire.transform.position.x, fire.transform.position.y, infrontofObjects), 0.2f);
			bounce (1.2f);
		} else
		{
			GoToPosition(sb.startPosition, 0.2f);
			if (fire.GetComponent<Fire> ().currentlyBurningSomething == false)
			{
				fire.GetComponent<Fire> ().ChangeFace ("fire_face_normal");
			}
		}
	}


	void OnCollisionEnter2D (Collision2D col)
	{
		if(col.gameObject.name == "FireCollision")
		{
			overTheFire = true;
		}
	}


	void OnCollisionExit2D (Collision2D col)
	{
		if(col.gameObject.name == "FireCollision")
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


	private void GoToPosition(Vector3 target, float time)
	{
		transform.position = new Vector3 (transform.position.x, transform.position.y, target.z);
		transform.DOMoveY (target.y, time).SetEase(Ease.OutExpo);
		transform.DOMoveX (target.x, time).SetEase(Ease.OutExpo);
	}


}
