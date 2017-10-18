///Source File: /Assets/Animations/explosion.cs
/// Author: Dylan Roberts
/// Last Modified By: Dylan Roberts
/// Date Last Modified: 18/10/2017
/// Program Description: Destroys an object
/// 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour {

	public void DestroyMe(){
		Destroy (gameObject);
	}
}
