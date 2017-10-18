///Source File: /Assets/Scripts/GameController.cs
/// Author: Dylan Roberts	
/// Last Modified By: Dylan Roberts
/// Date Last Modified: 18/10/2017
/// Program Description: This controls basic game function such as enabling UI elements,
/// instantiates the player class and adds enemies

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	[SerializeField]
	//floating enemy that looks like a contract
	GameObject contract;
	[SerializeField]
	//label that shows your lives
	Text lifeLabel;
	[SerializeField]
	//label that shows your score
	Text scoreLabel;
	[SerializeField]
	//text that lets you know your game is over
	Image gameOverImage;
	[SerializeField]
	//high score label shows you your high score
	Text highScoreLabel;
	[SerializeField]
	//reset button to start over
	Button resetBtn;



	private void initialize(){
	
		Player.Instance.Score = 0;
		Player.Instance.Life = 5;

		gameOverImage.enabled = false;
		highScoreLabel.gameObject.SetActive (false);
		resetBtn.gameObject.SetActive (false);
		lifeLabel.gameObject.SetActive (true);
		scoreLabel.gameObject.SetActive (true);
		//adds enemies at random times
		StartCoroutine ("AddEnemy");
	}

	//enable/disables UI elements on game over
	public void gameOver(){
		gameOverImage.enabled = true;
		highScoreLabel.gameObject.SetActive (true);
		resetBtn.gameObject.SetActive (true);

		lifeLabel.gameObject.SetActive (false);
		scoreLabel.gameObject.SetActive (false);
	}

	//updates UI with scores
	public void updateUI(){
	
		scoreLabel.text = "Score: " + Player.Instance.Score;
		lifeLabel.text = "Life: " + Player.Instance.Life;
		highScoreLabel.text = "High Score: " + PlayerPrefs.GetInt("highscore");
	}

	// Use this for initialization
	void Start () {
		Player.Instance.gCtrl = this;
		initialize ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//on click of reset button, restart the main scene
	public void ResetBtnClick(){
	
		SceneManager.
			LoadScene (
				SceneManager.GetActiveScene ().name);
	
	}
	 
	//adds extra enemy to the screen at random intervels
	private IEnumerator AddEnemy(){
		int time = Random.Range (1, 25);
		yield return new WaitForSeconds ((float) time);
		Instantiate (contract);
		StartCoroutine ("AddEnemy");
	}

}
