using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class RobotController : MonoBehaviour {
	private Rigidbody rb;
	public float speed;
	private int collected;
	public Text screenText;
	public Text endText;
	Animator animator;

	void Start(){
		rb = GetComponent<Rigidbody> ();
		collected = 0;
		setScreenTextAddCollected ();
		endText.text = "";
		animator = transform.Find ("Robot").GetComponent<Animator> ();
	}

	void Update(){
		if (rb.velocity.magnitude > 0.1) {
			animator.SetBool ("isWalking", true);
		} 
		else {
			animator.SetBool ("isWalking", false);
		}

		if ((Input.GetButtonDown ("Jump"))) {
			Vector3 veloc= rb.velocity;
			veloc.y= 6;
			rb.velocity= veloc;
			animator.SetTrigger ("Jump");
		}

		if (rb.velocity.magnitude > 0.1) {
			transform.forward = Vector3.Normalize (rb.velocity);
		}
	}
	
	void FixedUpdate(){
		float moveVertical = Input.GetAxis ("Vertical");
		float moveHorizontal = Input.GetAxis ("Horizontal");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.AddForce (movement * speed);


		//Quaternion rotation= new Quaternion();
		//rotation.SetFromToRotation(transform.forward,rb.velocity);
		//rb.rotation= rotation;
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("Cube")) {
			other.gameObject.SetActive (false);
			collected++;
			setScreenTextAddCollected ();
			if (collected==4) {
				endText.text= "YOU WIN!";
				Time.timeScale = 0.2f;
				//Application.LoadLevel("scene2");
			}
		}

		if (other.gameObject.CompareTag ("Zombie")) {
			endText.text= "YOU LOSE!";
			animator.SetTrigger ("Dies");
		}

		if (other.gameObject.CompareTag ("Cylinder")) {
			other.gameObject.SetActive (false);
			rb.velocity=new Vector3(0,0,0);
		}
	}

	void setScreenTextAddCollected(){
		screenText.text = "Collected: " + collected.ToString ();
	}


}