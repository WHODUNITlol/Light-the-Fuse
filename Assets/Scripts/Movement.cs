using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	//variable initialization for movement
	public float walkSpeed = 5;
	public float jumpHeight = 8;
	public bool isGrounded = true;




	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {



		//jumping
		if(Input.GetKeyDown(KeyCode.Space) && isGrounded == true) {
			GetComponent<Animator>().SetBool("jumping", true);
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, jumpHeight);
		}
		//ends jump cycle
		else
			GetComponent<Animator>().SetBool("jumping", false);

		//walking
		if (Input.GetKey (KeyCode.D)) {
			GetComponent<Animator> ().SetBool ("Running", true);
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (walkSpeed, GetComponent<Rigidbody2D> ().velocity.y);
			transform.localRotation = Quaternion.Euler (0, 0, 0);
			GetComponent<Animator> ().SetBool ("Idle", false);
		}  
		else if (Input.GetKey (KeyCode.A)) {
			GetComponent<Animator> ().SetBool ("Running", true);
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (-walkSpeed, GetComponent<Rigidbody2D> ().velocity.y);
			transform.localRotation = Quaternion.Euler (0, 180, 0);
			GetComponent<Animator> ().SetBool ("Idle", false);
		} 
		//resets to idle
		else {
			GetComponent<Animator> ().SetBool ("Idle", true);
			GetComponent<Animator> ().SetBool ("Running", false);
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, GetComponent<Rigidbody2D> ().velocity.y);
		}

		if (isGrounded == false) {
			GetComponent<Animator> ().SetBool ("falling", true);
		}

	}

	void OnCollisionEnter2D()
	{
		isGrounded = true;
	}

	void OnCollisionExit2D()
	{
		isGrounded = false;
	}

}