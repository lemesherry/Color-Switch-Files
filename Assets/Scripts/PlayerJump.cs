using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour {

	public static PlayerJump instance;
	Rigidbody2D rb;
	public float force = 1f;
	bool firstJump = true;
	public Color Cyan, Yellow, Pink, Purple;
	SpriteRenderer spriteRenderer;
	string currentColor;
	AudioSource audioSource;

	void Awake(){
		instance = this;
	}

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		spriteRenderer = GetComponent<SpriteRenderer> ();
		selectRandomColor ();
		audioSource = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			if (firstJump) {
				rb.velocity = Vector3.up * force * 1.65f;
				firstJump = false;
				audioSource.Play ();
			} else {
				rb.velocity = Vector3.up * force;
				audioSource.Play ();
			}
		}
 }
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "playerBase") {
			rb.velocity = Vector2.zero;
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "star") {
			col.gameObject.SetActive (false);
			GamePlayController.instance.playStarSound ();
 		}
	}



	public void selectRandomColor(){
		int random = Random.Range (0, 4);
		switch (random) {

		case 0:
			spriteRenderer.color = Cyan;
			currentColor = "Cyan";
			break;

		case 1:
			spriteRenderer.color = Yellow;
			currentColor = "Yellow";
			break;

		case 2:
			spriteRenderer.color = Pink;
			currentColor = "Pink";
			break;

		case 3:
			spriteRenderer.color = Purple;
			currentColor = "Purple";
			break;
		
		default:
			spriteRenderer.color = Purple;
			currentColor = "Purple";
			break;

		}
	}


	public string getcurrentColor(){
		return currentColor;
	}

	public Color selectRandomColorAgain(){
		int rand = Random.Range (0, 4);
		switch (rand) {

		case 0:
			currentColor = "Cyan";
			return Cyan;
			break;
		
		case 1:
			currentColor = "Yellow";
			return Yellow;
			break;

		case 2:
			currentColor = "Pink";
			return Pink;
			break;

		case 3:
			currentColor = "Purple";
			return Purple;
			break;

		default:
			return Color.green;
			break;
 		
		}
	}
	public Color ColorChek(){
		Color currentColor = spriteRenderer.color;
		return currentColor;
	}

	public void SetPlayerColor(Color col){
		spriteRenderer.color = col;
	}



}


