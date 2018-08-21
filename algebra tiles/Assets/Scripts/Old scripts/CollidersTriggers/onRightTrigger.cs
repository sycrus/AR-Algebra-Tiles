using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class onRightTrigger : MonoBehaviour {

	private Vector3 localPos;

	void OnTriggerEnter (Collider other) {

		if (other.gameObject.tag == "one") {
			//make objects fall onto plane
			other.attachedRigidbody.useGravity = true;
			other.attachedRigidbody.isKinematic = false;

		} else if (other.gameObject.tag == "minusOne") {
			//decrease one count
			EquationController.rightOneCount--;
		}
	}

	void OnTriggerExit (Collider other) {

		if (other.gameObject.tag == "minusOne" || other.gameObject.tag == "one") {
			//make objects float back into original position
			localPos = other.attachedRigidbody.transform.localPosition; //cannot set transform directly
			localPos.y = 2;
			other.attachedRigidbody.transform.localPosition = localPos;

			if (other.gameObject.tag == "one") {
				other.attachedRigidbody.useGravity = false;
				other.attachedRigidbody.isKinematic = true;
			}
		}
	}
		
}
		
		


