///Source File: /Assets/Scripts/Player.cs
/// Author: Dylan Roberts
/// Last Modified By: Dylan Roberts
/// Date Last Modified: 18/10/2017
/// Program Description: Player object. Stores scores, lives, and controls the high score

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player {

	static private Player _instance;
	static public Player Instance{
		get{ 
			if (_instance == null) {
				_instance = new Player ();
			}
			return _instance;
		}
	}
	private Player(){
	


	}

	public GameController gCtrl;

	private int _score = 0;
	private int _life = 5;
	private static int _highscore = PlayerPrefs.GetInt ("highscore", _highscore);

	//getters and setters for players score
	//adds high score if score beats stored high score
	public int Score{
		get{ return _score; }
		set{ 
			_score = value;
			if (_score > _highscore) {
				_highscore = _score;
				PlayerPrefs.SetInt ("highscore", _highscore);
			}
			//scoreLabel.text = "Score: " + _score;
			gCtrl.updateUI();
		}

	}
	//getters and setters for players lives
	public int Life{
		get{ return _life; }
		set{ 
			_life = value;


			if (_life <= 0) {
				//game over
				gCtrl.gameOver();
			}else{
				//lifeLabel.text = "Life: " + _life;
				gCtrl.updateUI();
			}
		}
	}
}
