using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rightHandSide : MonoBehaviour {

    public int rightXValue;
    public int rightOneValue;
    public int rightTotalValue;

    void Start()
    {
        rightXValue = 0;
        rightOneValue = 0;
        rightTotalValue = 0;
    }
    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "x":
                rightXValue++;
                break;
            case "mx":
                rightXValue--;
                break;
            case "one":
                rightOneValue++;
                break;
            case "mone":
                rightOneValue--;
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
                rightXValue--;
                break;
            case "mx":
                rightXValue++;
                break;
            case "one":
                rightOneValue--;
                break;
            case "mone":
                rightOneValue++;
                break;
            default:
                Debug.Log("Error with tile tags exiting.");
                break;
        }
    }

    void DebugRightValues()
    {
        Debug.Log("rightX: " + rightXValue + "\n" +
                  "rightOne: " + rightOneValue + "\n" +
                  "rightTotal: " + rightTotalValue
                 );
    }
}
