using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquationDisplay : MonoBehaviour {
	public Text leftText;
	public Text rightText;
	// Use this for initialization
	void Start () {
		rightText.text = "0";
		leftText.text = "0";
	}
	
	// Update is called once per frame
	void Update () {
		SetLeftText();
		SetRightText();
	}

	void SetLeftText()
	{

		if (EquationController.leftXCount == 0) {
			if (EquationController.leftOneCount == 0) { // x = 0 && one = 0
				leftText.text = "0";
			} else { // x = 0 only
				leftText.text = EquationController.leftOneCount.ToString();
			}
		} else {
			if (EquationController.leftOneCount == 0) { // one = 0 only
				leftText.text = EquationController.leftXCount.ToString() + "x";
			} else { 
				leftText.text = EquationController.leftXCount.ToString() + "x " + EquationController.leftOneCount.ToString();
			}
		}
	}
	void SetRightText()
	{

		if (EquationController.rightXCount == 0) {
			if (EquationController.rightOneCount == 0) { // x = 0 && one = 0
				rightText.text = "0";
			} else { // x = 0 only
				rightText.text = EquationController.rightOneCount.ToString ();
			}
		} else {
			if (EquationController.rightOneCount == 0) { // one = 0 only
				rightText.text = EquationController.rightXCount.ToString () + "x";
			} else { 
				rightText.text = EquationController.rightXCount.ToString () + "x " + EquationController.rightOneCount.ToString ();
			}
		}

	}
}
