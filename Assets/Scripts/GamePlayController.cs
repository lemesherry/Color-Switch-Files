using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePlayController : MonoBehaviour {
	public static GamePlayController instance;
	public GameObject pausePanel;
	public AudioClip buttonSound, starSound, colorSwitchSound, playerdeadSound;
	AudioSource audioSource;
	public Text updateScore;
	int count = 0;
	public GameObject[] obstacles;

	Vector3 positionChange;
	float generatedfinalValue;

	Vector3 newTransform;

	public Transform camTransform;

	//How long the object should shake for.
	float shakeDuration = 0f;

	//Amplitude of the sake. A larger value shakes the camera harder.
	public float shakeAmount;
	public float decreaseFactor;
	bool cameraShakeOn;
	Vector3 origialPos;

	void Awake(){
		instance = this;
	}

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
		pausePanel.SetActive (false);
		newTransform = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
		positionChange = new Vector3 (transform.position.x, transform.position.y + 10.58f, transform.position.z);
		for (int i = 0; i < 5; i++) {
			int randomValue = Random.Range (0,3);

			if (randomValue == 0) {
				Instantiate (obstacles[0],new Vector3(transform.position.x,positionChange.y,transform.position.z),Quaternion.identity);
					positionChange.y += 5.29f;

			}else if (randomValue == 1) {
				Instantiate (obstacles[1],new Vector3(transform.position.x,positionChange.y,transform.position.z),Quaternion.identity);
				positionChange.y += 5.29f;

			}else if (randomValue == 2) {
				
				Instantiate (obstacles[2], new Vector3(transform.position.x,positionChange.y,transform.position.z),Quaternion.identity);
				positionChange.y += 5.29f;
			}

			if (i == 4) {
				generatedfinalValue = positionChange.y;
			}
 		}

 
 	}
	 
	// Update is called once per frame
	void Update () {
		if (cameraShakeOn) {
			if (shakeDuration > 0) {
				camTransform.localPosition = origialPos + Random.insideUnitSphere * shakeAmount;
				shakeDuration -= Time.deltaTime * decreaseFactor;
			} 
			/*else {
				shakeDuration = 0f;
				camTransform.localPosition = origialPos;
			}
			*/
		}
	}

	public void cameraShake(){
		origialPos = camTransform.localPosition;
		shakeDuration = .7f;
		cameraShakeOn = true;
		StartCoroutine (stopp());
 	}

	IEnumerator stopp(){
 		yield return new WaitForSeconds(.8f);
		cameraShakeOn = false;
	}

	public void pausePanelOn(){
		pausePanel.SetActive (true);
		audioSource.clip = buttonSound;
		audioSource.Play ();
		Time.timeScale = 0f;
	}

	public void playButtononClick(){
		pausePanel.SetActive (false);
		audioSource.clip = buttonSound;
		audioSource.Play ();
		Time.timeScale = 1f;
 	}

	public void LoadHomeScene(){
		audioSource.clip = buttonSound;
		audioSource.Play ();
		Time.timeScale = 1f;
		StartCoroutine (soundDelay ());
	}

	IEnumerator soundDelay(){
		yield return new WaitForSeconds (.2f);
		SceneManager.LoadScene ("Home");
	}

	public void playStarSound(){
		audioSource.clip = starSound;
		audioSource.Play ();
	}

	public void playcolorSwitchSound(){
		audioSource.clip = colorSwitchSound;
		audioSource.Play ();
	}

	public void playplayerdeadSound(){
		audioSource.clip = playerdeadSound;
		audioSource.Play ();
	}

	public void updateGameScore(){
		count++;
		updateScore.text = count.ToString ();
		generatePrefab ();
	}

	public void ColorSwitcher(){
		Color receiveColor = PlayerJump.instance.selectRandomColorAgain ();
		Color currentPlayerColor = PlayerJump.instance.ColorChek ();
		if(receiveColor != currentPlayerColor){
			PlayerJump.instance.SetPlayerColor (receiveColor);
		} else {
			ColorSwitcher();
		}
 	}

	void generatePrefab(){
		int randomValue = Random.Range (0,3);

		if (randomValue == 0) {
			Instantiate (obstacles[0],new Vector3(transform.position.x, newTransform.y+generatedfinalValue, transform.position.z),Quaternion.identity);
			newTransform.y += 5.29f;

		}else if (randomValue == 1) {
			Instantiate (obstacles[1],new Vector3(transform.position.x, newTransform.y+generatedfinalValue, transform.position.z),Quaternion.identity);
			newTransform.y += 5.29f;

		}else if (randomValue == 2) {

			Instantiate (obstacles[2], new Vector3(transform.position.x, newTransform.y+generatedfinalValue, transform.position.z),Quaternion.identity);
			newTransform.y += 5.29f;
		}
 	}
	public void loadDestroyScene(){
		SceneManager.LoadScene ("GameOver");
	}

	public void SetCurrentScore(){
		int currentScore = int.Parse (updateScore.text);
		PlayerPrefs.SetInt ("100", currentScore);
	}

	public void SetbestScore(){
		int currentScore = int.Parse (updateScore.text);
		if (currentScore > PlayerPrefs.GetInt ("101", 0)) {
			PlayerPrefs.SetInt ("101",currentScore);
		}
	}
}


