using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RightPlaneCollider : MonoBehaviour {

	void OnCollisionEnter (Collision other)
	{
		if (other.gameObject.tag == "one") {
			EquationController.rightOneCount++;
		}
	}

	void OnCollisionExit (Collision other)
	{
		if (other.gameObject.tag == "one") {
			EquationController.rightOneCount--;
		}
	}
}
