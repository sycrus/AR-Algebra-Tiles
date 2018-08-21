using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class WeightController : MonoBehaviour {
	public static float leftWeight = 0;
	public static float rightWeight = 0;
	public Text debugLeft;
	public Text debugRight;

	void Start () {

	}
	void Update () {
		SetLeftWeight ();
		SetRightWeight ();
		Debug ();
	}
	void SetLeftWeight() {

		WeightController.leftWeight = XValue.xValue * EquationController.leftXCount + EquationController.leftOneCount;

	}
	void SetRightWeight() {

		WeightController.rightWeight = XValue.xValue * EquationController.rightXCount + EquationController.rightOneCount;

	}

	void Debug(){
		
		debugLeft.text =  leftWeight.ToString();
		debugRight.text = rightWeight.ToString();

	}


}
