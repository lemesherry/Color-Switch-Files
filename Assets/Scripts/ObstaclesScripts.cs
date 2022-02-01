using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesScripts : MonoBehaviour {
 	public GameObject DestroyedParticles;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "ObstacleDeleter") {
			Destroy (gameObject);
			return;
		}
		string getPlayerColor = PlayerJump.instance.getcurrentColor ();
		if (gameObject.tag == getPlayerColor) {
		} else {
			GamePlayController.instance.SetCurrentScore ();
			GamePlayController.instance.SetbestScore ();

			GamePlayController.instance.playplayerdeadSound ();
			GamePlayController.instance.cameraShake ();
 			Instantiate (DestroyedParticles, col.gameObject.transform.position, Quaternion.identity);
			col.gameObject.SetActive(false);
			StartCoroutine(gameOverDelay());
		}
	}

	IEnumerator gameOverDelay(){
		yield return new WaitForSeconds (1f);
		GamePlayController.instance.loadDestroyScene();
	}
}

