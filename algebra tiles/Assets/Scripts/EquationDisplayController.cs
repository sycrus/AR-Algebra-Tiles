using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquationDisplayController : MonoBehaviour {

    public GameObject equationDisplay;
    public MeshRenderer equalSign;
    public MeshRenderer unequalSign;

    public int[] equation;

    Text leftXTextDisplay;
    Text leftXDisplay;
    Text leftPlusDisplay;
    Text leftOneTextDisplay;

    Text equalTextDisplay;
    Text notEqualTextDisplay;

    Text rightXTextDisplay;
    Text rightXDisplay;
    Text rightPlusDisplay;
    Text rightOneTextDisplay;

    int leftXValue;
    int leftOneValue;
    int leftTotalValue;

    int rightXValue;
    int rightOneValue;
    int rightTotalValue;

    int storedXValue; //user created x value 
    int solvedXValue; //user solved x value
    int solution; //programme solved

    int stage;
    bool isSetUp;

	// Use this for initialization
	void Start () {
        equation = new int[] { 0, 0, 0, 0, 0, 0 };  //{ leftX, leftOne, leftTotal, rightX, rightOne, rightTotal}
        ResetEquation();

        //initialize texts
        leftXTextDisplay = equationDisplay.transform.Find("leftXText").GetComponent<Text>();
        leftXDisplay = equationDisplay.transform.Find("leftX").GetComponent<Text>();
        leftPlusDisplay = equationDisplay.transform.Find("leftPlus").GetComponent<Text>();
        leftOneTextDisplay = equationDisplay.transform.Find("leftOneText").GetComponent<Text>();

        rightXTextDisplay = equationDisplay.transform.Find("rightXText").GetComponent<Text>();
        rightXDisplay = equationDisplay.transform.Find("rightX").GetComponent<Text>();
        rightPlusDisplay = equationDisplay.transform.Find("rightPlus").GetComponent<Text>();
        rightOneTextDisplay = equationDisplay.transform.Find("rightOneText").GetComponent<Text>();

        equalTextDisplay = equationDisplay.transform.Find("equalText").GetComponent<Text>();
        notEqualTextDisplay = equationDisplay.transform.Find("notEqualText").GetComponent<Text>();

        leftXValue = FindObjectOfType<leftHandSide>().leftXValue;
        leftOneValue = FindObjectOfType<leftHandSide>().leftOneValue;
        leftTotalValue = FindObjectOfType<leftHandSide>().leftTotalValue;

        rightXValue = FindObjectOfType<rightHandSide>().rightXValue;
        rightOneValue = FindObjectOfType<rightHandSide>().rightOneValue;
        rightTotalValue = FindObjectOfType<rightHandSide>().rightTotalValue;

        equalTextDisplay.enabled = false;
        notEqualTextDisplay.enabled = false;
        equalSign.enabled = false;
        unequalSign.enabled = false;

	}
	
	// Update is called once per frame
	void Update () {
        
        GetEquation();
        DisplayEquation();
        isSetUp = FindObjectOfType<ModeController>().isSetUpMode;
        stage = FindObjectOfType<EnterButtonController>().stage;

        if (isSetUp && (stage == 1)) { //Set Up Mode, start checking only at Stage 2
            DisplayIsEqual(storedXValue);
        } else if (!isSetUp && (stage == 1)) {
            DisplayIsEqual(solution);
        }
	}

    public void ResetEquation() {
        FindObjectOfType<leftHandSide>().leftXValue = 0 ;
        FindObjectOfType<leftHandSide>().leftOneValue = 0;
        FindObjectOfType<leftHandSide>().leftTotalValue = 0;

        FindObjectOfType<rightHandSide>().rightXValue = 0;
        FindObjectOfType<rightHandSide>().rightOneValue = 0;
        FindObjectOfType<rightHandSide>().rightTotalValue = 0;

    } 

    //gets current values and updates equation
    void GetEquation(){
        leftXValue = FindObjectOfType<leftHandSide>().leftXValue;
        leftOneValue = FindObjectOfType<leftHandSide>().leftOneValue;
        leftTotalValue = FindObjectOfType<leftHandSide>().leftTotalValue;

        rightXValue = FindObjectOfType<rightHandSide>().rightXValue;
        rightOneValue = FindObjectOfType<rightHandSide>().rightOneValue;
        rightTotalValue = FindObjectOfType<rightHandSide>().rightTotalValue;
    }
   

    //displays array
    void DisplayEquation(){

        //display left x
        if (leftXValue != 0)
        {
            leftXDisplay.enabled = true;

            if (leftXValue == 1)
            {
                leftXTextDisplay.text = " ";
            }
            else if (leftXValue == -1)
            {
                leftXTextDisplay.text = "-";
            }
            else
            {
                leftXTextDisplay.text = leftXValue.ToString();
            }
        }
        else
        {
            leftXDisplay.enabled = false;
            leftXTextDisplay.text = " ";
        }

        // display left ones
        leftOneTextDisplay.enabled = true;
        if (leftOneValue != 0)
        {
            if  (leftOneValue > 0 && leftXValue != 0) 
            {
                leftPlusDisplay.enabled = true;
            }
            leftOneTextDisplay.text = leftOneValue.ToString();
        }
        else
        { //ones are zero
            //prevent x + 0 or -x + 0
            leftPlusDisplay.enabled = false;
            if (leftXValue != 0)
            {
                leftOneTextDisplay.enabled = false;
            }
            else
            {
                //both x = 0 and ones are zero 
                leftOneTextDisplay.text = leftOneValue.ToString();
            }
        }

        //display right x
        if (rightXValue != 0)
        {
            rightXDisplay.enabled = true;

            if (rightXValue == 1)
            {
                rightXTextDisplay.text = " ";
            }
            else if (rightXValue == -1)
            {
                rightXTextDisplay.text = "-";
            }
            else
            {
                rightXTextDisplay.text = rightXValue.ToString();
            }
        }
        else
        {
            rightXDisplay.enabled = false;
            rightXTextDisplay.text = " ";
        }

        // display left ones
        rightOneTextDisplay.enabled = true;
        if (rightOneValue != 0)
        {
            if (rightOneValue > 0 && rightXValue != 0)
            {
                rightPlusDisplay.enabled = true;
            }
            rightOneTextDisplay.text = rightOneValue.ToString();
        }
        else
        { //ones are zero
            //prevent x + 0 or -x + 0
            rightPlusDisplay.enabled = false;
            if (rightXValue != 0)
            {
                rightOneTextDisplay.enabled = false;
            }
            else
            {
                //both x = 0 and ones are zero 
                rightOneTextDisplay.text = rightOneValue.ToString();
            }
        }

    }

    //display equal/not equal sign
    void DisplayIsEqual(int xValue) {

        leftTotalValue = xValue * leftXValue + leftOneValue;
        rightTotalValue = xValue * rightXValue + rightOneValue;

        if (leftTotalValue == rightTotalValue)
        {
            equalTextDisplay.enabled = true;
            notEqualTextDisplay.enabled = false;
            equalSign.enabled = true;
            unequalSign.enabled = false;
        }
        else
        {
            equalTextDisplay.enabled = false;
            notEqualTextDisplay.enabled = true;
            equalSign.enabled = false;
            unequalSign.enabled = true;
        }
    }                 
 
    //checks that there is a valid solution to set equation
    public bool EquationError() { 
        if (leftXValue == rightXValue && leftOneValue != rightOneValue) { // parallel lines never intersect, no solution
            return true;
        } else if (leftXValue == rightXValue && leftOneValue == rightOneValue){  // two equivalent lines, infinite solutions
            return true;
        }
        else                //keine Probleme
            return false;
    }

    //checks that it is in simplest form
    public bool IsSolved() { //returns true if it's in the form x = a
        if (leftXValue == 1 ^ rightXValue == 1) { //simplified to single x on either side
            return true;
        }
        else 
            return false;
    }

    //outputs to log
    void DebugDisplay()
    {
        Debug.Log("Equation: (" + equation[0] + ", " +
                  equation[1] + ", " +
                  equation[2] + ", " +
                  equation[3] + ", " +
                  equation[4] + ", " +
                  equation[5] + ")"
                 );
    }

    //stores equation to array for immediate future reference
    public void StoreEquation() 
    {
        GetEquation();
        equation[0] = leftXValue;
        equation[1] = leftOneValue;
        equation[2] = leftTotalValue;
        equation[3] = rightXValue;
        equation[4] = rightOneValue;
        equation[5] = rightTotalValue;
        Debug.Log("Stored: (" + equation[0] + ", " +
                  equation[1] + ", " +
                  equation[2] + ", " +
                  equation[3] + ", " +
                  equation[4] + ", " +
                  equation[5] + ")"
                 );
    }

    //allows user to store own value of x
    public void StoreXValue() { 
        if (leftXValue == 1) { //value on right hand side
            storedXValue = rightOneValue;
        } 
        if (rightXValue == 1) { //value on left hand side
            storedXValue = leftOneValue;
        } 
        Debug.Log("X Value stored = " + storedXValue);
    }


    //app solves equation to get value of x, and stores it
    public void SolveEquation() { //programme solved
        if (!EquationError())
        {
            int sumOfX = leftXValue - rightXValue;
            int sumOfOne = leftOneValue - rightOneValue;
            solution = -sumOfX / sumOfOne;
        }
        else //tell user about equation not valid
        {
            FindObjectOfType<EnterButtonController>().DisplayToHelpText("Error: Equation not valid.");
        }
    }

    public bool CheckAnswer() {
        if (solution == storedXValue) {
            return true;
        } else {
            return false;
        }
    }

}
