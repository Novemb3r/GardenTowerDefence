using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopAnimation : MonoBehaviour {

    // Use this for initialization
    private Animator objAnim;
    public string key1;
    public string key2;
    void Start () {
        objAnim = GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void Update () {
    }
    void Stop()
    {
            objAnim.SetBool(key1, false);
    }
    void Stop2()
    {
        objAnim.SetBool(key1, true);
        objAnim.SetBool(key2, false);
    }
}
