using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class evolution : MonoBehaviour {

    public Sprite form1 = null;
    public Sprite form2 = null;
    public Sprite form3 = null;
    public Sprite form4 = null;
    public Sprite form5 = null;

    public int evTime1to2 = 100;
    public int evTime2to3 = 100;
    public int evTime3to4 = 100;
    public int evTime4to5 = 100;

    public int goldForHarvest = 100;

    private List<Transform> plants;
    private List<Sprite> forms;
    private List<int> goals;
    private int form_now = 0;
    private int forms_count;
    // Use this for initialization
    void Start ()
    {
        forms = new List<Sprite> { form1, form2, form3, form4, form5, null };
        forms_count = 0;
        while (forms[forms_count] != null)
            forms_count += 1;
        
        goals = new List<int> { evTime1to2, evTime2to3, evTime3to4, evTime4to5 };

        plants = new List<Transform> { };

        int num = 1;
        Transform buff;
        buff = transform.Find(num++.ToString());
        while (buff != null) 
        {
            plants.Add(buff);
            buff = transform.Find(num++.ToString());
        }
        gold_update.gold = forms_count;
        foreach (Transform plant in plants)
        {
            plant.GetComponent<SpriteRenderer>().sprite = forms[0];
        }
    }

    // Update is called once per frame
    int tick_count = 0;
    bool finish = false;
	void Update ()
    {
        if (!finish)
        {
            tick_count += 1;
            if (tick_count == goals[form_now])
            {
                form_now += 1;
                tick_count = 0;
                foreach (Transform plant in plants)
                {
                    plant.GetComponent<SpriteRenderer>().sprite = forms[form_now];
                }
                if (form_now >= forms_count - 1)
                {
                    finish = true;
                    return;
                }
            }
        }
    }
    void OnMouseDown()
    {
        Debug.Log("H!");
        Debug.Log(this.name);
        if(finish)
        {
            gold_update.gold += goldForHarvest;
            form_now = 0;
            tick_count = 0;
            finish = false;
        }

    }
}
