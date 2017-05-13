using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public float rotateSpeed;

	private Rigidbody rb;

	private bool collided;

	public float moveSpeed;

	private ParticleSystem.MainModule settings;


	void Start ()
	{
		settings = GetComponent<ParticleSystem>().main;
		//rb = GetComponent<Rigidbody>();
	}
//
//	void FixedUpdate ()
//	{
//		
//		float moveHorizontal = Input.GetAxis ("Horizontal");
//		float moveVertical = Input.GetAxis ("Vertical");
//
//		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
//
//		rb.AddForce (movement * speed);
//	}
	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.name == "wall") {
			float stopTime = Time.deltaTime + 5;
			ParticleSystem.MainModule settings = GetComponent<ParticleSystem>().main;
			settings.startColor = new ParticleSystem.MinMaxGradient (Color.red);
			while (stopTime > Time.deltaTime) {
			}
			settings.startColor = new ParticleSystem.MinMaxGradient (Color.red);
		}
	}
		void Update(){
		if (Input.GetAxis ("Colour") > 0) {
			ParticleSystem.MainModule settings = GetComponent<ParticleSystem> ().main;
			settings.startColor = new ParticleSystem.MinMaxGradient (Color.red);
		} else {
			ParticleSystem.MainModule settings = GetComponent<ParticleSystem> ().main;
			settings.startColor = new ParticleSystem.MinMaxGradient (Color.white);
		}
			float rotateHorizontal = Input.GetAxis ("LookLeftRight");
			float rotateVertical = Input.GetAxis ("LookUpDown");
		Vector3 rotatePlayer = new Vector3 (rotateVertical, rotateHorizontal, 0.0f);
			float moveForward = Input.GetAxis ("MoveForwardBackward");
		transform.Rotate (rotatePlayer * Time.deltaTime * rotateSpeed);
		transform.Translate(Vector3.forward * Time.deltaTime * moveForward * moveSpeed);
		}




//		Vector3 mouseMovement = (Input.mousePosition - (new Vector3(Screen.width, Screen.height, 0) / 2.0f)) * 1;
//		transform.Rotate(new Vector3(-mouseMovement.y, mouseMovement.x, -mouseMovement.x) * 0.025f);
//		transform.Translate(Vector3.forward * Time.deltaTime*currrentSpeed);
	

	
}
