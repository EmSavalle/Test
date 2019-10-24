using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    public GameObject explo;
    public int health = 100;
    public GameObject reward = null;
    public AudioClip hurt;
    public GameObject flareOnDeath;
    public Text t;
    public Slider sl;
    // Use this for initialization
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        if (sl)
        {
            sl.value = health;
        }
        if (t && t.name != "BossHealthText")
        {
            t.text = "Health : " + Convert.ToString(health) + " / 100";
        }
        if (health <= 0)
        {
            if (gameObject.tag == "Player")
            {
                SceneManager.LoadScene(5);
            }
            else
            {
                Debug.Log("Dead");
                Instantiate(explo, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
    }
    public void hit(int dmg)
    {
        AudioSource audio = gameObject.GetComponent<AudioSource>();
        if(hurt != null && audio != null)
        {
            audio.PlayOneShot(hurt);
        }
        health -= dmg;

        if (health <= 0)
        {
            if (gameObject.tag == "Player")
            {
                SceneManager.LoadScene(5);
            }
            else
            {
                Debug.Log("Dead");
                if (flareOnDeath)
                {
                    flareOnDeath.SetActive(true);
                }
                Instantiate(explo, transform.position, transform.rotation);
                if(reward != null)
                {
                    reward.SetActive(true);
                }
                Destroy(gameObject);

            }
        }
        if (t)
        {
            t.text = "Health : "+Convert.ToString(health)+" / 100";
        }
    }
}
