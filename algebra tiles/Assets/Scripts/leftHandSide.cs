using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leftHandSide : MonoBehaviour {

    public int leftXValue;
    public int leftOneValue;
    public int leftTotalValue;

	void Start () {
        leftXValue = 0;
        leftOneValue = 0;
        leftTotalValue = 0;
	}
    private void OnTriggerEnter(Collider other)
    {
        switch(other.tag) {
            case "x":
                leftXValue++;
                break;
            case "mx":
                leftXValue--;
                break;
            case "one":
                leftOneValue++;
                break;
            case "mone":
                leftOneValue--;
                break;
            default:
                Debug.Log("Error with tile tags entering.");
                break;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        switch (other.tag)
        {
            case "x":
                leftXValue--;
                break;
            case "mx":
                leftXValue++;
                break;
            case "one":
                leftOneValue--;
                break;
            case "mone":
                leftOneValue++;
                break;
            default:
                Debug.Log("Error with tile tags exiting.");
                break;
        }
    }

    void DebugLeftValues() {
        Debug.Log("leftX: " + leftXValue + "\n" +
                  "leftOne: " + leftOneValue + "\n" +
                  "leftTotal: " + leftTotalValue
                 );
    }
}
