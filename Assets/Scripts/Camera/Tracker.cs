using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracker : MonoBehaviour {

    public GameObject Subject = null;
    public Camera camera = null;

    public void Awake()
    {
        camera = GetComponent<Camera>();
    }

    public void Update()
    {
        if (Subject != null)
        {
            camera.transform.position = new Vector3(Subject.transform.position.x, Subject.transform.position.y, camera.transform.position.z);
        }
    }
}
