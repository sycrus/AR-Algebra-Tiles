using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModeController : MonoBehaviour {
    Toggle setUpToggle;
    Toggle solveToggle;
    public bool isSetUpMode;


	void Start () {
        setUpToggle = GameObject.Find("SetUpToggle").GetComponent<Toggle>();
        solveToggle = GameObject.Find("SolveToggle").GetComponent<Toggle>();

        //default mode is Set Up mode
        isSetUpMode = true;
        Debug.Log("ModeController isSetUp: " + isSetUpMode);
	
        setUpToggle.onValueChanged.AddListener(delegate {
            if (setUpToggle.isOn) {
                
                isSetUpMode = true;

                //once switched, start from stage 1 of other mode 
                FindObjectOfType<EnterButtonController>().InitializeDisplays(isSetUpMode);
            }    
           
        });
        solveToggle.onValueChanged.AddListener(delegate {
            if (solveToggle.isOn)
            {
                isSetUpMode = false;

                //once switched, start from stage 1 of other mode
                FindObjectOfType<EnterButtonController>().InitializeDisplays(isSetUpMode);
            }

        });

    }

}
