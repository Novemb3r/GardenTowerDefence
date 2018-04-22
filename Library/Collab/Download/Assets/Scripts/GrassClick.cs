using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassClick : MonoBehaviour
{
	public Transform prefab;
    public Transform rightfab;

    void OnMouseDown(){
		Debug.Log ("H!");
		Debug.Log (this.name);
        if (Event.current.button==1)
        {
            Instantiate(prefab, this.gameObject.transform.position
                + new Vector3(0, 0.5f, 0), Quaternion.identity);
        }
        if (Event.current.button == 0)
        {
            Instantiate(rightfab, this.gameObject.transform.position
                + new Vector3(0, 0.5f, 0), Quaternion.identity);
        }

    }

}