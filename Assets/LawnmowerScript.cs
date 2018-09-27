using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LawnmowerScript : MonoBehaviour {
    public Vector3 startPos;
    public Vector3 endPos;
    float moveSpeed;
    Rigidbody body;
    public AudioSource sound;
	// Use this for initialization
	void Start () {
        startPos = this.transform.position;
        body = this.GetComponent<Rigidbody>();
        moveSpeed = .5f;
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Noise")
        {
            GameObject noiseObj = GameObject.FindGameObjectWithTag("noise");
            noiseObj.gameObject.GetComponent<Renderer>().enabled = true;
            sound.volume = sound.volume * 2;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Noise")
        {
            GameObject noiseObj = GameObject.FindGameObjectWithTag("noise");
            noiseObj.gameObject.GetComponent<Renderer>().enabled = false;
            sound.volume = sound.volume / 2;

        }
    }

    // Update is called once per frame
    void Update () {
        if (Mathf.Abs(this.transform.position.z - endPos.z) <= .1)
        {
            Vector3 temp = endPos;
            endPos = startPos;
            startPos = temp;
        }
        Vector3 target = endPos;
        this.transform.LookAt(target);
        Vector3 targetDir = new Vector3(endPos.x - this.transform.position.x, 1.48f, endPos.z - this.transform.position.z);  //= this.transform.forward;
        Vector3 nextPos = this.transform.position + targetDir.normalized * Time.deltaTime * 3.0f;
        nextPos.y = this.transform.position.y;
        body.MovePosition(nextPos);
    }
}
