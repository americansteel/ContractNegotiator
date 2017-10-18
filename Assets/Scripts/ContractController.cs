///Source File: /Assets/Scripts/ContractController.cs
/// Author: Dylan Roberts
/// Last Modified By: Dylan Roberts
/// Date Last Modified: 18/10/2017
/// Program Description: Controls the way the 'Contract' object moves within the scene
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContractController : MonoBehaviour {

	[SerializeField]
	float minYSpeed = -2f;
	[SerializeField]
	float maxYSpeed = 2f;
	[SerializeField]
	float minXSpeed = 5f;
	[SerializeField]
	float maxXSpeed = 10f;

	private Transform _transform;
	private Vector2 _currentSpeed;
	private Vector2 _currentPosition;

	// Use this for initialization
	void Start () {
		_transform = gameObject.GetComponent<Transform> ();
		Reset ();
	}

	public void Reset(){

		float xSpeed = Random.Range (minXSpeed, maxXSpeed);
		float ySpeed = Random.Range (minYSpeed, maxYSpeed);

		_currentSpeed = new Vector2 (xSpeed, ySpeed);

		float y = Random.Range (-350, 360); 
		_transform.position = 
			new Vector2 ( 460 + Random.Range (0, 100), y);

	}

	// Update is called once per frame
	void Update () {
		_currentPosition = _transform.position;
		_currentPosition -= _currentSpeed;
		_transform.position = _currentPosition;

		if (_currentPosition.x<= -520) {
			Reset ();
		}
	}
}
