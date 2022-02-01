using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftColliderScript : MonoBehaviour {
	float height,width;
	// Use this for initialization
	void Start () {
		this.transform.localScale = new Vector3 (1f, Camera.main.orthographicSize * 2.5f, 1f);
		height = Camera.main.orthographicSize * 2;
		width = height * Screen.width / Screen.height;

		this.transform.position = new Vector3 (Camera.main.transform.position.x - width/2 -.5f,Camera.main.transform.position.y,1f);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
