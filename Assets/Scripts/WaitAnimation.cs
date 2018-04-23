using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WaitAnimation : MonoBehaviour {

    public GameObject parent;
    private PizzaPug pp;
    private Animator objAnim;
    // Use this for initialization
    void Start ()
    {
        objAnim = GetComponent<Animator>();
        pp = parent.GetComponent<PizzaPug>();
        objAnim.SetBool("Attack", false);
    }
    int counter = 0;
	// Update is called once per frame
	void Update () {

    }
    void Shoot()
    {
        pp.Shoot();
    }

    void BoolStop()
    {
        objAnim.SetBool("Attack", false);
    }
}
