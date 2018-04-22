using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotating : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
    static int a = 1;
	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.Euler(0f, a, 0f);
        transform.position = new Vector3(-140 + a/1000f, 3.51f, 50.55001f);
        a += 1;
    }
}
