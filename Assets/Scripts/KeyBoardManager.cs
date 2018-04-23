using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBoardManager : MonoBehaviour {


	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(1)) {
			foreach (var go in GameObject.FindGameObjectsWithTag("BuildMenus")) {
					go.gameObject.SetActive (false);
			}
		}
	}
}
