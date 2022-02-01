using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {
	AudioSource audioSource;
	bool playOnce = true;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		//if (Input.GetKeyDown (KeyCode.Space)) {
		//	audioSource.Play ();
		//};
		
	}

	void OnMouseUp(){
		if (playOnce) {
			audioSource.Play ();
			playOnce = false;
		}
		StartCoroutine (soundDelay ());
		//SceneManager.LoadScene ("GamePlay");
	}

	IEnumerator soundDelay(){
		yield return new WaitForSeconds (.2f);
		SceneManager.LoadScene ("GamePlay");
	}
}
