using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeftPlaneCollider : MonoBehaviour {

	void OnCollisionEnter (Collision other)
	{
		if (other.gameObject.tag == "one"){
			EquationController.leftOneCount++;
		} 
		
	}
	void OnCollisionExit (Collision other)
	{
		if (other.gameObject.tag == "one") {
			EquationController.leftOneCount--;
		} 

	}
		
}
