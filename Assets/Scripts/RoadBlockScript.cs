using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoadBlockScript : MonoBehaviour {

	public Transform roadBlockPrefab;
	public Canvas buildCanvas;
	public int targetRotation;

	Button buildbtn;
	Canvas buildMenu;
	private bool isBuildingAvaliable = true;

	void Start()
	{
		buildMenu = Instantiate (buildCanvas, this.gameObject.transform.position + new Vector3(0,2f,0), Quaternion.identity);
		buildMenu.transform.rotation = Camera.main.transform.rotation;
		buildMenu.transform.parent = this.transform;
		buildbtn = buildMenu.transform.Find("Button").GetComponent<Button> ();
		buildbtn.onClick.AddListener (buildbtnListener);
		buildMenu.gameObject.SetActive (false);

	}

	void buildbtnListener()
	{
		int needed_gold = 100;
			Quaternion rot = new Quaternion ();
			switch (targetRotation) {
			case 1:
				rot = new Quaternion (0, 0, 0, 0);
				needed_gold =  100;
				break;
			case 2:
				rot = new Quaternion (0, 1f, 0, 1);
				needed_gold = 500;
				break;
			case 3: 
				rot = new Quaternion (0, 1, 0, 0);
				needed_gold = 1000;
				break;
			}

		if (gold_update.gold > needed_gold) {

			Instantiate (roadBlockPrefab, this.gameObject.transform.position
			+ new Vector3 (0, 0.5f, 0), rot);
			isBuildingAvaliable = false;
			Waypoints.waypointIndex++;
			buildMenu.gameObject.SetActive (false);
			gold_update.gold -= needed_gold;
		}

	}

	void OnMouseDown(){


		foreach (var go in GameObject.FindGameObjectsWithTag("BuildMenus"))
		{
			if (!go.GetComponent<Canvas>().Equals(buildMenu))
				go.gameObject.SetActive (false);
		}
			
		switch (targetRotation) {
		case 1:
			if (Waypoints.waypointIndex != 0)
				return;
			break;
		case 2:
			if (Waypoints.waypointIndex != 1)
				return;
			break;
		case 3:
			if (Waypoints.waypointIndex != 2)
				return;
			break;
		}


		buildMenu.gameObject.SetActive(true);

	}
}
