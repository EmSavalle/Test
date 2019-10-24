using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {
	public GameObject bullet;
	public Light light;
	private float speed = 1f;
	public float initSpeed;
	public int sprintSpeed;
	public float jumpPower;
	public float speedH = 2f;
	public float speedV = 2f;
	private float yaw=0.0f;
	private float pitch=0.0f;
    private float timeAtInvicibleStart;
    private float starDuration;
    public GameObject invicible;
    public AudioClip starMusic;
    private AudioSource audioSource;
    public bool mobile = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        audioSource = GetComponent<AudioSource>();
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, gameObject.GetComponent<Rigidbody>().velocity.y, 0);
		Vector3 d = new Vector3(0,0,0);

        if (!mobile) { 
		    yaw += speedH * Input.GetAxis("Mouse X");
		    pitch -= speedV * Input.GetAxis("Mouse Y");
        }
        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
		if (Input.GetKey (KeyCode.LeftShift)) {
			speed = sprintSpeed * initSpeed;
		} else {
			speed = initSpeed;
		}
		if(Input.GetKeyDown(KeyCode.P)){
			speed *= 2;
		}
		if(Input.GetKeyDown(KeyCode.M)){
			speed *= 2;
		}
		if(Input.GetKey(KeyCode.Z)){
            d = d + new Vector3((transform.forward*Time.deltaTime*speed).x,0, (transform.forward * Time.deltaTime * speed).z);	
		}
		if(Input.GetKey(KeyCode.S))
        {
            d = d + new Vector3((transform.forward *-1* Time.deltaTime * speed).x, 0, (transform.forward * -1*Time.deltaTime * speed).z);
        }
		if(Input.GetKey(KeyCode.D)){
			d = d + transform.right*Time.deltaTime*speed;	
		}
		if(Input.GetKey(KeyCode.Q)){
			d = d + transform.right*-1*Time.deltaTime*speed;		
		}
		if(Input.GetKey(KeyCode.Space) && gameObject.GetComponent<Rigidbody>().velocity.y == 0)
        {
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0,jumpPower,0);
            //d = d + transform.up*Time.deltaTime*jumpPower;	
		}
		if(Input.GetKey(KeyCode.LeftControl)){
			d = d + transform.up*-1*Time.deltaTime*jumpPower 	;	
		}
		if(Input.GetKeyDown(KeyCode.L)){
			light.enabled=true;
		}
		if(Input.GetKeyUp(KeyCode.L)){
			light.enabled = false;
		}
		transform.position +=d;

		if (Input.GetKey (KeyCode.T)) {
			Instantiate (bullet,transform.position+Vector3.forward*0.2f,transform.rotation);
        }
        if (Input.GetKey(KeyCode.KeypadEnter))
        {
            QuitGame();
        }
        disableStar();
    }
    public void invincibleStart(float starTime)
    {
        invicible.SetActive(true);
        timeAtInvicibleStart = Time.time;
        starDuration = starTime;
        if(audioSource != null && starMusic != null)
        {
            audioSource.PlayOneShot(starMusic);
        }
    }
    public void disableStar()
    {
        if (Time.time > timeAtInvicibleStart + starDuration && invicible != null)
        {
            invicible.SetActive(false);
            audioSource.Stop();
        }
    }
    public void QuitGame()
    {
        // save any game data here
        #if UNITY_EDITOR
                 // Application.Quit() does not work in the editor so
                 // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
                 UnityEditor.EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
    }
    /*
		if(Input.GetKey(KeyCode.Z)){
		}
		if(Input.GetKey(KeyCode.S))
        {
        }
		if(Input.GetKey(KeyCode.D)){	
		}
		if(Input.GetKey(KeyCode.Q)){	
		}*/
    public void MoveForward() {

        transform.position += new Vector3((transform.forward * Time.deltaTime * speed).x, 0, (transform.forward * Time.deltaTime * speed).z);
    }
    public void MoveBackward() {

        transform.position += new Vector3((transform.forward * -1 * Time.deltaTime * speed).x, 0, (transform.forward * -1 * Time.deltaTime * speed).z);
    }
    public void MoveLeft()
    {
        transform.position += transform.right * -1 * Time.deltaTime * speed;
    }
    public void MoveRight()
    {
        transform.position+= transform.right * Time.deltaTime * speed;
    }
    public void LookUp()
    {
        pitch -= speedH ;

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }
    public void LookDown()
    {
        pitch += speedH ;

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }
    public void LookLeft()
    {
        yaw -= speedV ;

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }
    public void LookRight()
    {
        yaw += speedV;

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }
    public void fire()
    {
        WeaponScript go = gameObject.GetComponentInChildren<WeaponScript>();
        if(go != null)
        {
            go.fire();
        }
    }
}
