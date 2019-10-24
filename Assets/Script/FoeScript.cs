using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoeScript : MonoBehaviour {
	public GameObject target;
	public float speed;
	private float time;
	public bool triggered = false;
    public int damage = 10;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt (target.transform);
		if (triggered) {
			transform.position += transform.forward * Time.deltaTime * speed;	
		}
    }
    public void trigger()
    {
        triggered = true;
    }
    public void untrigger()
    {
        triggered = false;
    }
    public void OnTriggerStay(Collider o){

		if (o.gameObject.name == "Player" && Time.time > time+3) {
			o.gameObject.GetComponent<HealthScript> ().hit (damage);
			time = Time.time;

		}
	}
}
