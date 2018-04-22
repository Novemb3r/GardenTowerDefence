using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class gold_rotate : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    private int angle = 0;
	void Update () {
        angle += 1;
        transform.rotation = Quaternion.Euler(0f, angle, 0f);
    }
}
