using UnityEngine;
using System.Collections;

public class BlockDragEventsDemo : MonoBehaviour {

    public Color dragColor;
    public SpriteRenderer dragIndicatorRenderer;
    public TextMesh dragTimeIndicatorTextMesh;

    protected bool isDragging = false;
    protected Color originalIndicatorColor;

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

        dragTimeIndicatorTextMesh.text = "0";

        originalIndicatorColor = gameObject.GetComponent<SpriteRenderer>().color;
        dragIndicatorRenderer.color = dragColor;

		//Make Kinematic?
		rb2d.isKinematic = false;
    }

    //This event is called when you drop this GameObject
    void OnStopDrag()
    {
        isDragging = false;

        dragTimeIndicatorTextMesh.text = "0";

        dragIndicatorRenderer.color = originalIndicatorColor;

		//Make Kinematic?
		rb2d.isKinematic = true;
		transform.position = sb.startPosition;
    }

    //You can use a bool to indicate whether the GameObject is currently being dragged.
    void Update()
    {
        if(isDragging)
        {
            //For example, here we are updating a clock in the scene to show drag time
            float currentTime = float.Parse(dragTimeIndicatorTextMesh.text);
            dragTimeIndicatorTextMesh.text = (currentTime + Time.deltaTime).ToString();
        }
    }
}
