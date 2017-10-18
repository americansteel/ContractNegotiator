///Source File: /Assets/Scripts/TeacherController.cs
/// Author: Dylan Roberts
/// Last Modified By: Dylan Roberts
/// Date Last Modified: 18/10/2017
/// Program Description: Controls the way the Player object moves

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeacherController : MonoBehaviour {

	[SerializeField]
	private float speed = 7f;
	[SerializeField]
	private float topY;
	[SerializeField]
	private float bottomY;
	[SerializeField]
	private float rightX;
	[SerializeField]
	private float leftX;

	private Transform _transform;
	private Vector2 _currentPos;


	// Use this for initialization
	void Start () {
		_transform = gameObject.GetComponent<Transform> ();
		_currentPos = _transform.position;
	}

	// Update is called once per frame
	void Update () {

		_currentPos = _transform.position;

		if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
		{
			//if down arrow is pressed, move down
			_currentPos -= new Vector2(0, speed);
		}
		if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
		{
			//up arrow is pressed, move up
			_currentPos += new Vector2(0, speed);
		}
		if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) {
			//left arrow is pressed, move left
			_currentPos -= new Vector2 (speed, 0);
		}
		if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
			//right arrow is pressed, move right
			_currentPos += new Vector2 (speed, 0);
		}
		CheckBounds ();
		_transform.position = _currentPos;
	}

	private void CheckBounds(){
		//checks the bounds of the screen
		//so player cannot exit the screen
		if (_currentPos.y < bottomY) {
			_currentPos.y = bottomY;
		}

		if (_currentPos.y > topY) {
			_currentPos.y = topY;
		}
		if (_currentPos.x < leftX) {
			_currentPos.x = leftX;
		}

		if (_currentPos.x > rightX) {
			_currentPos.x = rightX;
		}
	}
}
