using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeroPair : MonoBehaviour {
    
    Color myColor;
    string myString;

	void Start () {
        myColor = GetComponent<Renderer>().material.GetColor("_Color");
        myString = GetComponentInChildren<TextMesh>().text;
	}
	
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "x" && gameObject.tag == "mx" ||
            other.gameObject.tag == "mx" && gameObject.tag == "x" ||
            other.gameObject.tag == "one" && gameObject.tag == "mone" ||
            other.gameObject.tag == "mone" && gameObject.tag == "one") {
            gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.gray);
            gameObject.GetComponentInChildren<TextMesh>().text = "0";
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "x" && gameObject.tag == "mx" ||
            other.gameObject.tag == "mx" && gameObject.tag == "x" ||
            other.gameObject.tag == "one" && gameObject.tag == "mone" ||
            other.gameObject.tag == "mone" && gameObject.tag == "one")
        {
            gameObject.GetComponent<Renderer>().material.SetColor("_Color", myColor);
            gameObject.GetComponentInChildren<TextMesh>().text = myString;
        }
    }
}
