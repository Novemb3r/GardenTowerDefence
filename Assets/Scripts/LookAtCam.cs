using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCam : MonoBehaviour {

    // Use this for initialization
    private GameObject cam;
	void Start () {
        cam = GameObject.Find("MainCamera");

    }
	
	// Update is called once per frame
	void Update () {
        //transform.LookAt(cam.transform.position);
        transform.forward = cam.transform.forward;
	}
}
