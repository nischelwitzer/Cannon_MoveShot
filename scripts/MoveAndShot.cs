using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveAndShot : MonoBehaviour {

    public Rigidbody projectile;        // ball for shot (prefab with destroy)
    public Transform shotPos;           // get the shot direction
    public float shotForce = 1000f;     // power for AddForce

    private int myShotCount = 0;
    private Text myText;                // text for show shot counts
    private AudioSource soundShot;      // sound for shot, needs AudioSource

    public Camera[] cameras;
    public GameObject myLight;

    // Use this for initialization
    void Start () {

        print("##### CamSwitcher init " + cameras.Length);

        myText = GameObject.Find("CountText").GetComponent <Text> ();
        soundShot = this.gameObject.GetComponent<AudioSource>();
	}
        
    // based on: https://unity3d.com/de/learn/tutorials/topics/physics/brick-shooter

    void Update() {
        float h = Input.GetAxis("Horizontal"); // gamepad 
        float v = Input.GetAxis("Vertical");

        Vector3 myRotate = new Vector3(v * 40.0F+0.0F-20F, h * 60.0F, 0.0F); // more left/right (60)
        transform.rotation =  Quaternion.Euler(myRotate); 

        // 1..A 2..B 3..X 4..Y 5..LB 6..RB 7..Back 8..Start
        if (Input.GetButtonUp("Fire1")) myShot(); // fire1 button pressed, with GetButton - always fire

        // Kamerawechsel Button X Y
        if (Input.GetButtonUp("Fire3"))
        {
            cameras[0].enabled = false;
            cameras[1].enabled = true;
        }
        if (Input.GetButtonUp("Fire4"))
        {
            cameras[0].enabled = true;
            cameras[1].enabled = false;
        }

        if (Input.GetButtonUp("Fire2"))
        {
            myLight.SetActive(!myLight.activeSelf);
        }

    }

    void myShot()
    {

        Rigidbody shot = Instantiate(projectile, shotPos.position, shotPos.rotation) as Rigidbody; 
        shot.AddForce(shotPos.forward * shotForce);

        myShotCount++;
        Debug.Log("##### shooting... " + myShotCount);
        myText.text = "Shot: " + myShotCount;

        soundShot.Play(); // to AudioSource
    }
}
