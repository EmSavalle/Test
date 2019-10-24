using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
	public int health = 100;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void hit (int dmg){
		health -= dmg;
		Debug.Log ("hit");
		if(health<=0){
			Debug.Log ("Dead");
			Destroy (gameObject);
		}
	}
}
