using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
	[SerializeField]
	GameObject contract;

	[SerializeField]
	Text lifeLabel;
	[SerializeField]
	Text scoreLabel;
	[SerializeField]
	Image gameOverImage;
	[SerializeField]
	Text highScoreLabel;
	[SerializeField]
	Button resetBtn;



	private void initialize(){
	
		Player.Instance.Score = 0;
		Player.Instance.Life = 5;

		gameOverImage.enabled = false;
		highScoreLabel.gameObject.SetActive (false);
		resetBtn.gameObject.SetActive (false);

		lifeLabel.gameObject.SetActive (true);
		scoreLabel.gameObject.SetActive (true);
		StartCoroutine ("AddEnemy");
	}

	public void gameOver(){
		gameOverImage.enabled = true;
		highScoreLabel.gameObject.SetActive (true);
		resetBtn.gameObject.SetActive (true);

		lifeLabel.gameObject.SetActive (false);
		scoreLabel.gameObject.SetActive (false);
	}

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

	public void ResetBtnClick(){
	
		SceneManager.
			LoadScene (
				SceneManager.GetActiveScene ().name);
	
	}

	private IEnumerator AddEnemy(){
		int time = Random.Range (1, 25);
		yield return new WaitForSeconds ((float) time);
		Instantiate (contract);
		StartCoroutine ("AddEnemy");
	}

}
