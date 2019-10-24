using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {
	public GameObject door;
	public Material d;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider other){
		Debug.Log ("Touched");
		door.GetComponent<Renderer> ().material = d;
		door.GetComponent<DoorScript> ().open ();
		Destroy (gameObject);
	}
}
