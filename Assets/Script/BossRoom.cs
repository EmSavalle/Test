using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoom : MonoBehaviour {
    public Light mainLight;
    public GameObject boss;
    public GameObject lightManager;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnTriggerEnter(Collider o)
    {
        mainLight.enabled = false;
    }
    public void StartBoss()
    {
        boss.SetActive(true);
        lightManager.SetActive(true);
    }
}
