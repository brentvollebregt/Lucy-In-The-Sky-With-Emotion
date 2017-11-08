using UnityEngine;
using System.Collections;

public class Force : MonoBehaviour
{

    public GameObject windObject;
    Rigidbody rigidbody;
    Vector3 initialPos;

    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
        initialPos = gameObject.GetComponent<Transform>().position;
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.X))
            rigidbody.AddForce(windObject.transform.forward * 1000f);
        if (Input.GetKeyDown(KeyCode.Z))
        {
            GetComponent<Transform>().position = initialPos;
            rigidbody.velocity = Vector3.zero;
        }
    }
}