using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

	public Text screenText;
	public Text endText;


	// Use this for initialization
	void Start () {
		endText.text = "";
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void setScreenTextAddCollected(){
		//screenText.text = "Collected: " + collected.ToString ();
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("Zombie")) {
			endText.text= "YOU LOSE!";
		}
	}
}
