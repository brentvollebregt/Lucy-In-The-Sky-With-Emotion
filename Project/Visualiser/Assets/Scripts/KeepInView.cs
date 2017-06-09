using UnityEngine;
using System.Collections;
public class KeepInView : MonoBehaviour
{
    public Camera camera;
    void Update()
    {
        Vector3 pos = camera.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp01(pos.x);
        pos.y = Mathf.Clamp01(pos.y);
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }
}
