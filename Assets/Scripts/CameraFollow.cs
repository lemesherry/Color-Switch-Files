using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	public GameObject player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(player.transform.position.y > this.transform.position.y && player.activeInHierarchy){
			transform.position = new Vector3 (transform.position.x,player.transform.position.y,transform.position.z);
		}



	}
}
