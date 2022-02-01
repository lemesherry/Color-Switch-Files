using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDestroyer : MonoBehaviour {
	public GameObject DestroyedParticles;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void onTriggerEnter2d(Collider2D col){
		if (col.gameObject.tag == "Player") {
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
