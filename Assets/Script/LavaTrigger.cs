using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaTrigger : MonoBehaviour {
    public GameObject respawnPoint;
    public int lavaDmg;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnTriggerEnter(Collider o)
    {
        Debug.Log("Lava");
        o.gameObject.transform.position = respawnPoint.transform.position;
        o.gameObject.GetComponent<HealthScript>().hit(lavaDmg);
    }
}
