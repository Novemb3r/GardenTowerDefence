using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class gold_update : MonoBehaviour {

	// Use this for initialization
    private Text text;
    void Start () {
        text = GameObject.Find("gold_text").GetComponent<Text>();

    }
    public static int gold;
	// Update is called once per frame
	void Update () {
        text.text = gold.ToString();
    }
}
