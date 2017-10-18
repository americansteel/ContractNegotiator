///Source File: /Assets/Scripts/UIControl.cs
/// Author: Dylan Roberts
/// Last Modified By: Dylan Roberts
/// Date Last Modified: 18/10/2017
/// Program Description: This loads the main game from the start menu

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIControl : MonoBehaviour {

	public void ChangeScene(int sceneName)
	{

		//load scene thats passed in
		SceneManager.LoadScene(sceneName);
	}

}
