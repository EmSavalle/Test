using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossStarter : MonoBehaviour
{
    public GameObject bossRoom;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnTriggerEnter(Collider o)
    {
        bossRoom.GetComponent<BossRoom>().StartBoss();
    }
}
