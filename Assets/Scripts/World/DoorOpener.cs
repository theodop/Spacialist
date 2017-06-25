using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour {
    private Boolean opening = false;
    private Boolean opened = false;

	// Update is called once per frame
	void Update () {

	}

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject.tag == "Player")
        {
            if (!opened)
            {
                opened = true;
                transform.position += new Vector3(0, 0, -1);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.gameObject.tag == "Player")
        {
            if (opened)
            {
                opened = false;
                transform.position += new Vector3(0, 0, 1);
            }
        }
    }
}
