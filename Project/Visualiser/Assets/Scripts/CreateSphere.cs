using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class CreateSphere : MonoBehaviour {
    public GameObject parentSphere;
    public List<Material> materials = new List<Material>();
    static int colourIndex = 0;
    public Transform parentInHierachy;

    void MakeBall()
    {
        AudioSource source = Camera.main.GetComponent<AudioSource>();
        AudioClip clip = (AudioClip)Resources.Load("Woosh");
        source.clip = clip;
        source.Play();

        Material m = materials[colourIndex % materials.Count];
        colourIndex++;
        Vector3 point = Camera.main.ViewportToWorldPoint(new Vector3(1.5f, 0.5f, 0.0f)); //TODO make mesh fade in
        GameObject g = Instantiate(parentSphere, point, parentSphere.transform.rotation);
        g.SetActive(true);
        g.AddComponent<Rigidbody>();
        g.GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.Continuous;
        g.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * 200);
        g.GetComponent<MeshRenderer>().material = m;
        g.transform.parent = parentInHierachy;

        //StartCoroutine("FadeIn", g);
    }

    //IEnumerator FadeIn(GameObject g)
    //{
    //    Color c = g.GetComponent<MeshRenderer>().material.color;
    //    c.a = 0f;
    //    yield return null;
    //}
}
