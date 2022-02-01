using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour {
	public AudioClip buttonSound;
	AudioSource audioSource;
	public Text score, bestScore;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();

		score.text = PlayerPrefs.GetInt ("100") + "";
		bestScore.text = PlayerPrefs.GetInt ("101") + "";
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void buttonClickSound(){
		audioSource.clip = buttonSound;
		audioSource.Play ();
	}

	public void loadScene(){
		SceneManager.LoadScene ("GamePlay");
	}

	public void loadHome(){
		SceneManager.LoadScene ("Home");
	}

}

