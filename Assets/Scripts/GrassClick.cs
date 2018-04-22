using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrassClick : MonoBehaviour
{
	private bool isBuildingAvaliable = true;
	public Transform iceTurretPrefab, fireTurretPrefab, TurretPrefab,MopsPrefab;

	public Canvas buildCanvas;
	Canvas buildMenu;

	private Button turretBtn, farmBtn, iceTurretBtn, fireTurretBtn; 

	void Start()
	{
		buildMenu = Instantiate (buildCanvas, this.gameObject.transform.position + new Vector3(0,2f,0), Quaternion.identity);
		buildMenu.transform.rotation = Camera.main.transform.rotation;
		buildMenu.transform.parent = this.transform;
		//buildMenu = this.gameObject.transform.Find("BuildMenu").GetComponent<Canvas> ();
		turretBtn = buildMenu.transform.Find("TurretBuildButton").GetComponent<Button> ();
		farmBtn = buildMenu.transform.Find ("SeedBuildButon").GetComponent<Button> ();
		iceTurretBtn = buildMenu.transform.Find ("IceTurretBuildButton").GetComponent<Button> ();
		fireTurretBtn = buildMenu.transform.Find ("FireTurretBuildButton").GetComponent<Button> ();

		turretBtn.onClick.AddListener (turretBtnListener);
		farmBtn.onClick.AddListener (farmBtnListener);
		iceTurretBtn.onClick.AddListener (iceTurretBtnListener);
		fireTurretBtn.onClick.AddListener (fireTurretBtnListener);

		buildMenu.gameObject.SetActive (false);
	}

	void turretBtnListener()
	{
		Instantiate(TurretPrefab, this.gameObject.transform.position
			   + new Vector3(0, 0.5f, 0), Quaternion.identity);
		isBuildingAvaliable = false;
		buildMenu.gameObject.SetActive (false);
	}

	void iceTurretBtnListener()
	{
		Instantiate(iceTurretPrefab, this.gameObject.transform.position
			+ new Vector3(0, 0.5f, 0), Quaternion.identity);
		isBuildingAvaliable = false;
		buildMenu.gameObject.SetActive (false);
	}

	void fireTurretBtnListener()
	{
		Instantiate(fireTurretPrefab, this.gameObject.transform.position
			+ new Vector3(0, 0.5f, 0), Quaternion.identity);
		isBuildingAvaliable = false;
		buildMenu.gameObject.SetActive (false);
	}

	void farmBtnListener()
	{
		Instantiate(MopsPrefab, this.gameObject.transform.position
			+ new Vector3(0, 2f, 0), Camera.main.transform.rotation);
		isBuildingAvaliable = false;
		buildMenu.gameObject.SetActive (false);
	}

    void OnMouseDown(){
		Debug.Log (this.name);
        //if (Event.current.button == 1)
       // {

		foreach (var go in GameObject.FindGameObjectsWithTag("BuildMenus"))
		{
			if (!go.GetComponent<Canvas>().Equals(buildMenu))
				go.gameObject.SetActive (false);
		}
			
		if (isBuildingAvaliable)
			buildMenu.gameObject.SetActive(true);

    }

}