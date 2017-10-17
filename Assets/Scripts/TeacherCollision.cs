using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeacherCollision : MonoBehaviour {

	[SerializeField]
	GameController gameController;

	[SerializeField]
	GameObject explosion;


	private AudioSource _collisionSound;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void OnTriggerEnter2D(Collider2D other){

		_collisionSound = other.GetComponent<AudioSource> ();

		if (other.gameObject.tag.Equals ("cash")) {
			Debug.Log ("Collision cash\n");
			if (_collisionSound != null) {
				_collisionSound.Play ();
			}
			//Add points
			Player.Instance.Score+=100;
		}else if(other.gameObject.tag.Equals ("enemy")){
			Debug.Log ("Collision enemy\n");
			if (_collisionSound != null) {
				_collisionSound.Play ();
				Instantiate (explosion)
					.GetComponent<Transform> ()
					.position = other.gameObject
						.GetComponent<Transform> ()
						.position;

				other.gameObject.
				GetComponent<ContractController> ()
					.Reset ();
				Player.Instance.Life -= 1;

				StartCoroutine ("Blink");
			}
		}

	}

	private IEnumerator Blink(){

		Color c;
		Renderer renderer = 
			gameObject.GetComponent<Renderer> ();
		for (int i = 0; i < 3; i++) {
			for (float f = 1f; f >= 0; f -= 0.1f) {
				c = renderer.material.color;
				c.a = f;
				renderer.material.color = c;
				yield return new WaitForSeconds (.1f);
			}
			for (float f = 0f; f <= 1; f += 0.1f) {
				c = renderer.material.color;
				c.a = f;
				renderer.material.color = c;
				yield return new WaitForSeconds (.1f);
			}
		}
	}

}
