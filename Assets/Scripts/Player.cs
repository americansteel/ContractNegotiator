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
