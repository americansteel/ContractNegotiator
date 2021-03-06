﻿///Source File: /Assets/Scripts/CityController.cs
/// Author: Dylan Roberts
/// Last Modified By: Dylan Roberts
/// Date Last Modified: 18/10/2017
/// Program Description: Controls the way the background image moves

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityController : MonoBehaviour {
	//Public variables
	[SerializeField]
	private float speed = 5f;
	[SerializeField]
	private float startX;
	[SerializeField]
	private float endX;

	//private variables
	private Transform _transform;
	private Vector2 _currentPos;

	// Use this for initialization
	void Start () {
		_transform = gameObject.GetComponent<Transform> ();
		_currentPos = _transform.position;
		Reset ();
	}

	// Update is called once per frame
	void Update () {
		_currentPos = _transform.position;
		//move ocean down
		_currentPos -= new Vector2 (speed, 0);

		//check if we need to reset
		if (_currentPos.x < endX) {
			//reset
			Reset ();
		}
		//apply changes
		_transform.position = _currentPos;

	}


	private void Reset(){

		_currentPos = new Vector2 (startX, -120);
	}
}
