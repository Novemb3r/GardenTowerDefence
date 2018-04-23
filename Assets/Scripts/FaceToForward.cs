using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceToForward : MonoBehaviour {

    // Use this for initialization
    Transform RIG;
    Vector3 lastPosition;
    void Start () {
        RIG = transform.Find("RIG");
        lastPosition = RIG.position;


    }
	// Update is called once per frame
	void Update () {
        RIG.forward = (RIG.position - lastPosition).normalized;
        lastPosition = RIG.position;
    }
}
