using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

	public float smooth = 1F;
	public float tiltAngle = 20f;

	private float tilt = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (WeightController.leftWeight > WeightController.rightWeight) {
			
			//rotate anticlockwise
			tilt = tiltAngle;
			Quaternion target = Quaternion.Euler(0, 0, tilt);
			transform.rotation = Quaternion.Lerp(transform.rotation, target, Time.deltaTime * smooth);

		}

		else if (WeightController.leftWeight < WeightController.rightWeight) {
			
			//rotate clockwise
			tilt = tiltAngle * -1;
			Quaternion target = Quaternion.Euler(0, 0, tilt);
			transform.rotation = Quaternion.Lerp(transform.rotation, target, Time.deltaTime * smooth);

		} else if (WeightController.leftWeight == WeightController.rightWeight) {

			//rotate until level
			Quaternion target = Quaternion.Euler(0, 0, 0);
			transform.rotation = Quaternion.Lerp(transform.rotation, target, Time.deltaTime * smooth);

		}
	}
}
