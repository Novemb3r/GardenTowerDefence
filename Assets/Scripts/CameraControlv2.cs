﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControlv2 : MonoBehaviour {

	public int Boundary  = 25;
	public float speed  = 7f;

    public float wheel_speed = 50f;
    public float min_zoom = 14;
    public float max_zoom = 100;
    private Vector3 max_zoom_vector;
    private Vector3 min_zoom_vector;

    private int theScreenWidth;
	private int theScreenHeight;

    private float zoom_now;

    private Vector3 right_vec;
    private Vector3 up_vec;

    void Start() 
	{
		theScreenWidth = Screen.width;
		theScreenHeight = Screen.height;
        //Вычисление текущего зума за счет поиска проекции текущего вектора камеры
        //на вектор-движение
        zoom_now = transform.forward.x * transform.position.x +
                   transform.forward.y * transform.position.y +
                   transform.forward.z * transform.position.z;
        zoom_now /= -transform.forward.magnitude;
        max_zoom_vector = transform.position + transform.forward * ( zoom_now - max_zoom);
        min_zoom_vector = transform.position + transform.forward * ( zoom_now - min_zoom);

        right_vec = new Vector3(transform.right.x, 0, transform.right.z).normalized;
        up_vec = new Vector3(transform.up.x, 0, transform.up.z).normalized;
    }

	void Update()
    {
        float mw = Input.GetAxis("Mouse ScrollWheel");
        float delta;
        if (mw != 0 && !Camera.main.orthographic)
        {
            delta = mw * wheel_speed;
            zoom_now += -delta;
            if (zoom_now <= min_zoom)
            {
                zoom_now = min_zoom;
            }
            else if (zoom_now >= max_zoom)
            {
                zoom_now = max_zoom;
            }
            else
                transform.position += transform.forward * delta;
        }
        if (Input.mousePosition.x > theScreenWidth - Boundary)
		{
			transform.Translate (speed * Time.deltaTime * right_vec.x,
                                 0,
                                 speed * Time.deltaTime * right_vec.z, Space.World);
		}

		if (Input.mousePosition.x < 0 + Boundary)
        {
            transform.Translate(-speed * Time.deltaTime * right_vec.x,
                                0,
                                -speed * Time.deltaTime * right_vec.z, Space.World);
        }

		if (Input.mousePosition.y > theScreenHeight - Boundary)
        {
            transform.Translate(speed * Time.deltaTime * up_vec.x,
                                0,
                                speed * Time.deltaTime * up_vec.z, Space.World);
        }

		if (Input.mousePosition.y < 0 + Boundary)
        {
            transform.Translate(-speed * Time.deltaTime * up_vec.x,
                                0,
                                -speed * Time.deltaTime * up_vec.z, Space.World);
        }

    }   
}
