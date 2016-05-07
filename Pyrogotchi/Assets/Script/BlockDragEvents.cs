using UnityEngine;
using System.Collections;

public class BlockDragEvents : MonoBehaviour {

    public Color dragColor;

    protected bool isDragging = false;

	private Rigidbody2D rb2d;
	private SnapBack sb;
	private GameObject fire;
	private bool overTheFire = false;

	void Start() {
		//I set the kinematic thing to true by default so that pulling an object over 
		//another object doesn't make them collide with each other
		rb2d = transform.GetComponent<Rigidbody2D> ();
		rb2d.isKinematic = true;
		sb = transform.GetComponent<SnapBack> ();

		fire = GameObject.Find ("Fire");
	}


    //This event is called when you first pick up this GameObject
	void OnStartDrag()
    {
        isDragging = true;
		//Make Kinematic
		rb2d.isKinematic = false;
    }


    //This event is called when you drop this GameObject
    void OnStopDrag()
    {
        isDragging = false;
		//Make Kinematic?
		rb2d.isKinematic = true;
		transform.position = sb.startPosition;

		CheckIfInTheFire ();

    }


	private void CheckIfInTheFire()
	{
		if(overTheFire)
		{
			gameObject.GetComponent<BurnableObject> ().StartBurning ();
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
}
