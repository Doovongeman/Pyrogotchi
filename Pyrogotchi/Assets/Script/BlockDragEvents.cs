using UnityEngine;
using System.Collections;

public class BlockDragEvents : MonoBehaviour {

    public Color dragColor;

    protected bool isDragging = false;

	private Rigidbody2D rb2d;
	private SnapBack sb;

	void Start() {
		//I set the kinematic thing to true by default so that pulling an object over 
		//another object doesn't make them collide with each other
		rb2d = transform.GetComponent<Rigidbody2D> ();
		rb2d.isKinematic = true;
		sb = transform.GetComponent<SnapBack> ();
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
