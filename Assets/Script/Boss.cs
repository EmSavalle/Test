using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour {
    public float rotationSpeed = 1f;
    public GameObject target;
    public GameObject model;
    public GameObject explo;
    public GameObject laser;
    public int hitPointCpt = 5;
    public int fireRate;
    private float timeAtChargingStart;
    public float chargeDuration;
    public int laserDuration;
    public bool firing = false;
    public bool charging = false;
    private float lastShot;
    public AudioClip laserSound;
    public AudioClip laserCharge;
    public float rotateSpeed = 3f;
    public Text healthtext;
    private bool preventFirstShot = false;
    // Use this for initialization
    void onEnable () {
        Debug.Log("Start");
        lastShot = Time.time;
	}
	
	// Update is called once per frame
	void Update ()
    {

        AudioSource audio = gameObject.GetComponent<AudioSource>();
        healthtext.text = "Boss health : "+Convert.ToString(gameObject.GetComponent<HealthScript>().health);
        HealthScript[] hs = gameObject.GetComponentsInChildren<HealthScript>();
        if(hs == null || hs.Length == 0)
        {

            Instantiate(explo, transform.position, transform.rotation);
            Destroy(healthtext);
            Destroy(gameObject);
        }
        else
        {
            if(hs.Length != hitPointCpt)
            {
                gameObject.GetComponent<HealthScript>().hit(100);
                rotationSpeed += 1;
                chargeDuration -= 0.4f;
                laserDuration -= 1;
                hitPointCpt = hs.Length;
            }
        }
        if(preventFirstShot == false)
        {
            lastShot = Time.time;
            preventFirstShot = true;
        }
        if (fireRate + lastShot < Time.time && firing == false && charging == false)
        {
            charging = true;
            timeAtChargingStart = Time.time;
            if (laserCharge != null && audio != null)
            {
                audio.PlayOneShot(laserCharge);
            }
        }
        else
        {
            if (charging)
            {
                if (timeAtChargingStart + chargeDuration < Time.time)
                {
                    fireLaser();
                    firing = true;
                    charging = false;
                    lastShot = Time.time;
                    if (laserSound != null && audio != null)
                    {
                        audio.Stop();
                        audio.PlayOneShot(laserSound);
                    }
                }
            }
            else if (firing)
            {
                if(lastShot+laserDuration < Time.time)
                {
                    if (laserSound != null && audio != null)
                    {
                        audio.Stop();
                    }
                    fireLaser();
                    firing = false;
                }
            }
            else
            {
                //transform.LookAt(target.transform);
                Vector3 targetDir = target.transform.position - transform.position;

                // The step size is equal to speed times frame time.
                float step = rotateSpeed * Time.deltaTime;

                Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
                transform.rotation = Quaternion.LookRotation(newDir);
                model.transform.Rotate(new Vector3(0, 0, rotationSpeed));
            }
        }

	}
    public void fireLaser() {
        laser.SetActive(!laser.activeSelf);
    }
}
