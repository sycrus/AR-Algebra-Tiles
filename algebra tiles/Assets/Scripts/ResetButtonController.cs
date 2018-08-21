using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetButtonController : MonoBehaviour {

    public Button resetButton;
    Button resetBtn;
    bool isSetUpMode;

    void Start()
    {
        resetBtn = resetButton.GetComponent<Button>();
        resetBtn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        Debug.Log("Reset click");
        FindObjectOfType<EquationDisplayController>().ResetEquation();
        isSetUpMode = FindObjectOfType<ModeController>().isSetUpMode;
        FindObjectOfType<EnterButtonController>().InitializeDisplays(isSetUpMode);
        /*
        Debug.Log("Equation: (" + FindObjectOfType<EquationDisplayController>().equation[0] + ", " +
                  FindObjectOfType<EquationDisplayController>().equation[1] + ", " +
                  FindObjectOfType<EquationDisplayController>().equation[2] + ", " +
                  FindObjectOfType<EquationDisplayController>().equation[3] + ", " +
                  FindObjectOfType<EquationDisplayController>().equation[4] + ", " +
                  FindObjectOfType<EquationDisplayController>().equation[5] + ")"
                );
         */
    }
}
