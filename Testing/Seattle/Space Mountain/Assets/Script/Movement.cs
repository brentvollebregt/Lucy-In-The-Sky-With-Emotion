using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public float rotateSpeed;

	public float moveSpeed;

	ParticleSystem.ColorOverLifetimeModule colour;

	bool IsInputEnabled;

	public Transform centre;

	float count;

	public GameObject collisionParticle;

	Quaternion Xrotation, Yrotation, Zrotation;

	void Start ()
	{
		colour = GetComponent<ParticleSystem> ().colorOverLifetime;
		IsInputEnabled = true;
		Xrotation = Quaternion.Euler (new Vector3(0, 0, 90));
		Yrotation = Quaternion.Euler (new Vector3(0, 0, 0));
		Zrotation = Quaternion.Euler (new Vector3(90, 0, 0));
	}
	void OnCollisionEnter(Collision collision) 
	{
		if (collision.gameObject.CompareTag("Wall")) {
			IsInputEnabled = false;
			colour.enabled = true;
			count = Time.time + 0.5f;
			collisionParticle.transform.position = transform.position;

			collisionParticle.GetComponent<ParticleSystem> ().Play();


		}
	}
		void Update(){


		if (count < Time.time) {
			IsInputEnabled = true;
			colour.enabled = false;
		}
		if(IsInputEnabled)
		{
			if (Input.GetAxis ("x") > 0) {
				colour.enabled = true;
			} else {
				colour.enabled = false;
			}
			float rotateHorizontal = Input.GetAxis ("LookLeftRight");
			float rotateVertical = Input.GetAxis ("LookUpDown");
		Vector3 rotatePlayer = new Vector3 (rotateVertical, rotateHorizontal, 0.0f);
			float moveForward = Input.GetAxis ("MoveForwardBackward");
		transform.Rotate (rotatePlayer * Time.deltaTime * rotateSpeed);
		transform.Translate(Vector3.forward * Time.deltaTime * moveForward * moveSpeed);
		}
		else{
			transform.position = Vector3.MoveTowards(transform.position, centre.position, Time.deltaTime*moveSpeed*2);

		}
}
	public void CollidedWithWall(Collision wall){



	}
}
