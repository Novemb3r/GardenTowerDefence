using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GrassClick : MonoBehaviour
{
	private bool isBuildingAvaliable = true;
	public Transform woofPugPrefab, fireMagePrefab, pizzaPugPrefab, carrotFarmPrefab, pumkinFarmPrefab, tomatoFarmPrefab;
	public Sprite fireA,fireD,turretA,turretD,carrotA,carrotD,pumkinA,pumkinD,tomatoA,tomatoD, sleepA, sleepD, notavalBuild;

	public Canvas buildCanvas, arrow;
	Canvas buildMenu, arrowCanv;

	private Button pizzaPugBtn, carrotFarmBtn, woofPugBtn, fireMageBtn, pumkinFarmBtn, tomatoFarmBtn; 



	void Start()
	{
		buildMenu = Instantiate (buildCanvas, this.gameObject.transform.position + new Vector3(0,2f,0), Quaternion.identity);
		buildMenu.transform.rotation = Camera.main.transform.rotation;
		buildMenu.transform.parent = this.transform;

		carrotFarmBtn = buildMenu.transform.Find ("CarrotBuildButon").GetComponent<Button> ();
        carrotFarmBtn.transform.Find("Text").GetComponent<Text>().text = carrotFarmPrefab.GetComponent<evolution>().cost.ToString();

        pumkinFarmBtn = buildMenu.transform.Find ("PumkinBuildButton").GetComponent<Button> ();
        pumkinFarmBtn.transform.Find("Text").GetComponent<Text>().text = pumkinFarmPrefab.GetComponent<evolution>().cost.ToString();

        tomatoFarmBtn = buildMenu.transform.Find ("TomatoBuildButton").GetComponent<Button> ();
        tomatoFarmBtn.transform.Find("Text").GetComponent<Text>().text = tomatoFarmPrefab.GetComponent<evolution>().cost.ToString();

        pizzaPugBtn = buildMenu.transform.Find ("TurretBuildButton").GetComponent<Button> ();
        pizzaPugBtn.transform.Find("Text").GetComponent<Text>().text = pizzaPugPrefab.GetComponent<PizzaPug>().cost.ToString();

        woofPugBtn = buildMenu.transform.Find ("IceTurretBuildButton").GetComponent<Button> ();
        woofPugBtn.transform.Find("Text").GetComponent<Text>().text = woofPugPrefab.GetComponent<WoofPug>().cost.ToString();

        fireMageBtn = buildMenu.transform.Find ("FireTurretBuildButton").GetComponent<Button> ();
        fireMageBtn.transform.Find("Text").GetComponent<Text>().text = fireMagePrefab.GetComponent<FireMage>().cost.ToString();

        carrotFarmBtn.onClick.AddListener (carrotFarmBtnListener);
		pumkinFarmBtn.onClick.AddListener (pumkinFarmBtnListener);
		tomatoFarmBtn.onClick.AddListener (tomatoFarmBtnListener);


		pizzaPugBtn.onClick.AddListener (turretBtnListener);
		woofPugBtn.onClick.AddListener (iceTurretBtnListener);
		fireMageBtn.onClick.AddListener (fireTurretBtnListener);

		buildMenu.gameObject.SetActive (false);
	}

	void turretBtnListener()
	{
		Instantiate(pizzaPugPrefab, this.gameObject.transform.position
			   + new Vector3(0, 0.5f, 0), Quaternion.identity);
		isBuildingAvaliable = false;
		buildMenu.gameObject.SetActive (false);
		//Destroy (arrowCanv);
		arrowCanv.gameObject.SetActive(false);
		gold_update.gold -= pizzaPugPrefab.GetComponent<PizzaPug> ().cost;
		StatManager.pizzaStat++;
	}

	void iceTurretBtnListener()
	{
		Instantiate(woofPugPrefab, this.gameObject.transform.position
			+ new Vector3(0, 0.5f, 0), Quaternion.identity);
		isBuildingAvaliable = false;
		buildMenu.gameObject.SetActive (false);
		//Destroy (arrowCanv);
		arrowCanv.gameObject.SetActive(false);
		gold_update.gold -= woofPugPrefab.GetComponent<WoofPug> ().cost;
        StatManager.woofStat++;
	}

	void fireTurretBtnListener()
	{
		Instantiate(fireMagePrefab, this.gameObject.transform.position
			+ new Vector3(0, 0.5f, 0), Quaternion.identity);
		isBuildingAvaliable = false;
		buildMenu.gameObject.SetActive (false);
		//Destroy (arrowCanv);
		arrowCanv.gameObject.SetActive(false);
		gold_update.gold -= fireMagePrefab.GetComponent<FireMage> ().cost;
        StatManager.fireStat++;
	}

	void carrotFarmBtnListener()
	{
		Instantiate(carrotFarmPrefab, this.gameObject.transform.position
			+ new Vector3(-0.6f, 2f, 3.7f), new Quaternion (0,0,1,1));
		
		isBuildingAvaliable = false;
		buildMenu.gameObject.SetActive (false);
		//Destroy (arrowCanv);
		arrowCanv.gameObject.SetActive(false);
		gold_update.gold -= carrotFarmPrefab.GetComponent<evolution> ().cost;
        StatManager.carrotStat++;
	}

	void pumkinFarmBtnListener()
	{
		Instantiate(pumkinFarmPrefab, this.gameObject.transform.position
			+ new Vector3(-0.6f, 2f, 3.7f),  new Quaternion (0,0,1,1));
		isBuildingAvaliable = false;
		buildMenu.gameObject.SetActive (false);
		//Destroy (arrowCanv);
		arrowCanv.gameObject.SetActive(false);
		gold_update.gold -= pumkinFarmPrefab.GetComponent<evolution> ().cost;
        StatManager.pumpkinStat++;
	}

	void tomatoFarmBtnListener()
	{
		Instantiate(tomatoFarmPrefab, this.gameObject.transform.position
			+ new Vector3(-0.6f, 2f, 3.7f), new Quaternion (0,0,1,1));
		isBuildingAvaliable = false;
		buildMenu.gameObject.SetActive (false);
		//Destroy (arrowCanv);
		arrowCanv.gameObject.SetActive(false);
		gold_update.gold -= tomatoFarmPrefab.GetComponent<evolution> ().cost;
        StatManager.tomatoStat++;
	}

    void OnMouseDown(){
		if (!EventSystem.current.IsPointerOverGameObject ()) {
			
			Debug.Log (this.name);

			foreach (var go in GameObject.FindGameObjectsWithTag("BuildMenus")) {
				if (!go.GetComponent<Canvas> ().Equals (buildMenu))
					go.gameObject.SetActive (false);
			}
			
			if (isBuildingAvaliable) {

				arrowCanv = Instantiate (arrow, this.gameObject.transform.position + new Vector3(0,4f,0), Quaternion.identity);
				arrowCanv.transform.rotation = Camera.main.transform.rotation * Quaternion.Euler(-15,0,0);



				if (carrotFarmPrefab.GetComponent<evolution> ().cost > gold_update.gold) {
					carrotFarmBtn.enabled = false;
					carrotFarmBtn.GetComponent<Image> ().sprite = carrotD;
				} else {
					carrotFarmBtn.enabled = true;
					carrotFarmBtn.GetComponent<Image> ().sprite = carrotA;
				}

				if (pumkinFarmPrefab.GetComponent<evolution> ().cost > gold_update.gold) {
					pumkinFarmBtn.enabled = false;
					pumkinFarmBtn.GetComponent<Image> ().sprite = pumkinD;
				} else {
					pumkinFarmBtn.enabled = true;
					pumkinFarmBtn.GetComponent<Image> ().sprite = pumkinA;
				}

				if (tomatoFarmPrefab.GetComponent<evolution> ().cost > gold_update.gold) {
					tomatoFarmBtn.enabled = false;
					tomatoFarmBtn.GetComponent<Image> ().sprite = tomatoD;
				} else {
					tomatoFarmBtn.enabled = true;
					tomatoFarmBtn.GetComponent<Image> ().sprite = tomatoA;
				}





				if (pizzaPugPrefab.GetComponent<PizzaPug> ().cost > gold_update.gold) {
					pizzaPugBtn.enabled = false;
					pizzaPugBtn.GetComponent<Image> ().sprite = turretD;
				} else {
					pizzaPugBtn.enabled = true;
					pizzaPugBtn.GetComponent<Image> ().sprite = turretA;
				}


				if (woofPugPrefab.GetComponent<WoofPug> ().cost > gold_update.gold) {
					woofPugBtn.enabled = false;
					woofPugBtn.GetComponent<Image> ().sprite = sleepD;
				} else {
					woofPugBtn.enabled = true;
					woofPugBtn.GetComponent<Image> ().sprite = sleepA;
				}

				if (fireMagePrefab.GetComponent<FireMage> ().cost > gold_update.gold) {
					fireMageBtn.enabled = false;
					fireMageBtn.GetComponent<Image> ().sprite = fireD;
				} else {
					fireMageBtn.enabled = true;
					fireMageBtn.GetComponent<Image> ().sprite = fireA;
				}
			
				buildMenu.gameObject.SetActive (true);
			}

		}
	}

}