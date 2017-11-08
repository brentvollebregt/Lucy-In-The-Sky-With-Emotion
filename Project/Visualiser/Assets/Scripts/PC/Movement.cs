using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float moveSpeed;
    public float rotateSpeed;
    bool IsInputEnabled;
    float count;
    public GameObject collisionParticle;
    public Transform centre;
    // Use this for initialization
    void Start () {
        IsInputEnabled = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (count < Time.time)
        {
            IsInputEnabled = true;
        }
        if (IsInputEnabled)
        {

            float rotateHorizontal = Input.GetAxis("Horizontal");
            float rotateVertical = Input.GetAxis("Vertical");
            Vector3 rotatePlayer = new Vector3(rotateVertical, rotateHorizontal, 0.0f);

            transform.Rotate(rotatePlayer * Time.deltaTime * rotateSpeed);
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, centre.position, Time.deltaTime * moveSpeed * 2);

        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            IsInputEnabled = false;
            count = Time.time + 0.5f;
            collisionParticle.transform.position = transform.position;

            collisionParticle.GetComponent<ParticleSystem>().Play();


        }
    }
}
