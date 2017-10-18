///Source File: /Assetts/Scripts/CashController.cs
/// Author: Dylan Roberts
/// Last Modified By: Dylan Roberts
/// Date Last Modified: 18/10/2017
/// Program Description: This controls the 'Cash' object.
/// Determines where and how fast it moves

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CashController : MonoBehaviour {

	//Public variables
	[SerializeField]
	private float speed = 5f;
	[SerializeField]
	private float startY = 360;
	[SerializeField]
	private float endY = -360;
	[SerializeField]
	private float startX = 480;
	[SerializeField]
	private float endX = -480;

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

		float y = Random.Range (startY, endY);
		float dx = Random.Range (0, 100);
		_currentPos = new Vector2 (startX+dx, y);
	}
}
