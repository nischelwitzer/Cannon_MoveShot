using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyCube : MonoBehaviour {

    private AudioSource cubeSound;
    private bool destroyMe = false;

    static private int cubeCount = 0; // counts number and destroys
    private Text cubeText;

    private void Start()
    {
        cubeCount++; // each new cube object gets count
        Debug.Log("startup cube "+ this.gameObject.name + " >> " + cubeCount);
        cubeSound = GetComponent<AudioSource>();
        cubeText = GameObject.Find("CountCubeText").GetComponent<Text>();
    }

    // Use this for initialization
    void Update () {

        if (this.gameObject.transform.position.y < -10 && !destroyMe) // destroyMe to call only ONCE!
        {
            destroyMe = true;
            cubeSound.Play(); // first play and then destroy

            cubeCount--;
            Debug.Log("***** destroy cube: " + this.gameObject.name + " " + cubeCount);
            cubeText.text = "Cube: " + cubeCount;

            Destroy(this.gameObject, 5.0F); // delete after 5 sec
        }
    }

}
