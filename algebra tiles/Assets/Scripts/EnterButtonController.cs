using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnterButtonController : MonoBehaviour {

    public Button enterButton;
    public Text helpTextDisplay;

    bool isSetUpMode;
    public int stage;
    Button enterBtn;
    Text helpTextDisp;
    string[] solveBtnText;
    string[] solveHelpText;
    string[] setUpBtnText;
    string[] setUpHelpText;


	// Use this for initialization
	void Start () {

        enterBtn = enterButton.GetComponent<Button>();
        helpTextDisp = helpTextDisplay.GetComponentInChildren<Text>();
        isSetUpMode = true;
        Debug.Log("EnterButtonController isSetUp: " + isSetUpMode);

        InitializeStrings();
        InitializeDisplays(isSetUpMode);
        Debug.Log("start stage: " + stage);
        enterBtn.onClick.AddListener(TaskOnClick);
	}

    void TaskOnClick() {
        isSetUpMode = FindObjectOfType<ModeController>().isSetUpMode;
        Debug.Log("TaskOnClick isSetUp: " + isSetUpMode);

        if (isSetUpMode) //set up mode
        { 
            
            switch (stage) {
                case 0: //Set Up mode, stage 1, user presses "Set x"
                    Debug.Log("Set Up stage 1");
                    if (FindObjectOfType<EquationDisplayController>().IsSolved()) { //equation is set up properly
                        Debug.Log("Correct format. Storing...");
                        //record 
                        FindObjectOfType<EquationDisplayController>().StoreXValue();

                        DisplayNextStage(isSetUpMode);

                    } 
                    else 
                    { //complain, repeat instructions, remains on current stage
                        Debug.Log("stage 1");
                        DisplayToHelpText("Error setting up x value. \n" + setUpHelpText[stage]);
                    }
                    break;

                case 1: //Set Up mode, stage 2, user presses "Set equation"
                    Debug.Log("Set Up stage 2");
                    FindObjectOfType<EquationDisplayController>().StoreEquation(); //equation[]
                    FindObjectOfType<EquationDisplayController>().SolveEquation(); //solution

                    DisplayNextStage(isSetUpMode);
                    break;

                case 2: //Set Up mode, stage 3, button disabled
                    Debug.Log("Set Up stage 3");
                    enterBtn.interactable = false;
                    break;

                default:
                    Debug.Log("Error with stage");
                    break;
            }
        } 

        else            //solve mode
        {
            switch (stage)
            {
                case 0: //Solve mode, stage 1, user presses "Set equation"
                    Debug.Log("Solve stage 1");
                    FindObjectOfType<EquationDisplayController>().StoreEquation(); //equation[]
                    FindObjectOfType<EquationDisplayController>().SolveEquation(); //solution

                    DisplayNextStage(isSetUpMode);
                    break;

                case 1: //Solve mode, stage 2, user presses "Check Answer" 
                    Debug.Log("Solve stage 2");
                    //checks to see if simplified
                    if (FindObjectOfType<EquationDisplayController>().IsSolved()) 
                    {
                        Debug.Log("Solve stage 2 IsSolved");
                        FindObjectOfType<EquationDisplayController>().StoreXValue();

                        if (FindObjectOfType<EquationDisplayController>().CheckAnswer()) 
                        {
                            DisplayNextStage(isSetUpMode);
                        } 
                        else 
                        {                            //go back to Solve stage 1
                            stage = -1;
                            DisplayToHelpText("Incorrect! Try again!");
                            DisplayNextStage(isSetUpMode);
                        }
                    }  
                    else 
                    {
                        Debug.Log("Solve stage 2 not Solved");
                        DisplayToHelpText("Not quite! Try again!");
                    }
                    break;

                case 2: //Solve mode, stage 3, user presses "Try another"
                    Debug.Log("Solve stage 3");
                    stage = -1;
                    DisplayNextStage(isSetUpMode);
                    break;   

                default:
                    Debug.Log("Error with stage");
                    break;
            }
          
        }
    }

    void DisplayNextStage(bool mode) {
        stage++;
        if (mode) { //true == Set Up mode
            enterButton.GetComponentInChildren<Text>().text = setUpBtnText[stage];
            helpTextDisp.text = setUpHelpText[stage];
        } else { //false == Solve mode
            enterButton.GetComponentInChildren<Text>().text = solveBtnText[stage];
            helpTextDisp.text = solveHelpText[stage];
        }
    }

    public void InitializeDisplays(bool mode) {
        stage = 0;
        enterButton.interactable = true;

        Debug.Log("InitializeDisplays isSetUp: " + mode);

        if (mode)
        {
            enterButton.GetComponentInChildren<Text>().text = setUpBtnText[0];
            helpTextDisp.text = setUpHelpText[0];
        }
        else
        {
            enterButton.GetComponentInChildren<Text>().text = solveBtnText[0];
            helpTextDisp.text = solveHelpText[0];
        }
    }

    void InitializeStrings() {
        setUpHelpText = new string[] {
            "Arrange one x tile on left, x value on right",
            "Set up equation for others to solve",
            "Select Solve mode on left"
        };

        setUpBtnText = new string[] {
            "Set x value",
            "Set equation",
            " "
        };

        solveHelpText = new string[] {
           "Arrange tiles to form given equation.",
            "Find the value of x.",
            "Correct! Press button to try another",
        };

        solveBtnText = new string[] {
            "Set equation",
            "Check answer",
            "Try another",
        };


    }

	// Update is called once per frame
	public void DisplayToHelpText(string message) {
        helpTextDisp.text = message;
	}
}
