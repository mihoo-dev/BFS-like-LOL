﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MapGenerator : MonoBehaviour {
    NewBehaviourScript map;
    private Vector2 mousePos;
    Rect rect;

    void Awake()
    {
        map = GameObject.Find("Sphere").GetComponent<NewBehaviourScript>();
    }

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < map.mapSize; i++)
        {
            for (int j = 0; j < map.mapSize; j++)
            {
                Debug.DrawLine(new Vector3(i - .5f, j - .5f, 0), new Vector3(i + .5f, j - .5f, 0), Color.blue);
                Debug.DrawLine(new Vector3(i - .5f, j - .5f, 0), new Vector3(i - .5f, j + .5f, 0), Color.blue);
                Debug.DrawLine(new Vector3(i - .5f, j + .5f, 0), new Vector3(i + .5f, j + .5f, 0), Color.blue);
                Debug.DrawLine(new Vector3(i + .5f, j + .5f, 0), new Vector3(i + .5f, j - .5f, 0), Color.blue);
            }
        }
        if (Input.GetButtonDown("Fire1"))
        {
            mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z));
            for (int i = 0; i < map.mapSize; i++)
            {
                for (int j = 0; j < map.mapSize; j++)
                {
                    if (mousePos.x > i - .5f && mousePos.x < i + .5f &&
                        mousePos.y < j + .5f && mousePos.y > j - .5f)
                    {
                        if (map.graph[j, i].gameObject.activeSelf == true)
                        {
                            Debug.DrawLine(new Vector3(i - .5f, j - .5f, 0), new Vector3(i + .5f, j - .5f, 0), Color.yellow, 1);
                            Debug.DrawLine(new Vector3(i - .5f, j - .5f, 0), new Vector3(i - .5f, j + .5f, 0), Color.yellow, 1);
                            Debug.DrawLine(new Vector3(i - .5f, j + .5f, 0), new Vector3(i + .5f, j + .5f, 0), Color.yellow, 1);
                            Debug.DrawLine(new Vector3(i + .5f, j + .5f, 0), new Vector3(i + .5f, j - .5f, 0), Color.yellow, 1);
                        }
                        else
                        {
                            Debug.DrawLine(new Vector3(i - .5f, j - .5f, 0), new Vector3(i + .5f, j - .5f, 0), Color.red, 1);
                            Debug.DrawLine(new Vector3(i - .5f, j - .5f, 0), new Vector3(i - .5f, j + .5f, 0), Color.red, 1);
                            Debug.DrawLine(new Vector3(i - .5f, j + .5f, 0), new Vector3(i + .5f, j + .5f, 0), Color.red, 1);
                            Debug.DrawLine(new Vector3(i + .5f, j + .5f, 0), new Vector3(i + .5f, j - .5f, 0), Color.red, 1);
                        }
                    }
                    
                }
            }
        }  
    }

    
}
