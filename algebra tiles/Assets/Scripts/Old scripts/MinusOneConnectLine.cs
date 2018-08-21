using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinusOneConnectLine : MonoBehaviour {
	private LineRenderer lineRenderer;
	private float distance;
//	private Transform origin;
//	private Transform destination;
	private float width = 1;
	private Vector3 localPos;

	// Use this for initialization
	void Start () {
		lineRenderer = GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
		DrawLine ();
	}

	void OnTriggerEnter (Collider other) {
		
		if (other.gameObject.tag == "one") {

			if (other.gameObject.tag == "left") {


			} else if (other.gameObject.tag == "right") {
				
			}

			//increase one count

			//deactivate gravity for object
			other.attachedRigidbody.useGravity = false;
			other.attachedRigidbody.isKinematic = true;



			//define the origin of line

			//define the destination of line, (normal location., 2, normal location)
			localPos = other.attachedRigidbody.transform.localPosition; 
			localPos.y = 2; //assume on the beam, raises it by 2


			//move the object, (normal location.x., 2, normal location.z)
			other.attachedRigidbody.transform.localPosition = localPos; // new position

		} 
	}
	void OnTriggerExit (Collider other) {

		if (other.gameObject.tag == "one" || other.gameObject.tag == "x") {

			other.attachedRigidbody.isKinematic = false;
		}

	}

	void DrawLine () {
		
			lineRenderer.SetPosition (0, gameObject.transform.position);
			lineRenderer.SetPosition (1, localPos);
			lineRenderer.startWidth = width;
			lineRenderer.endWidth = width;
			lineRenderer.startColor = Color.white;
			lineRenderer.endColor = Color.white;

	}


}
