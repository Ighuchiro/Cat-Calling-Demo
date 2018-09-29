using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class goalScript : MonoBehaviour {
    private GameObject scoreStatus;
    private int score = 0;
    private int scoreBoost = 0;
    private float timer = 0.0f;
    public float timeLimit = 10.0f;
    public Text txt;


    // Use this for initialization
    void Start () {
        scoreStatus = GameObject.FindGameObjectWithTag("UI");
        //
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Cat")
        {
            other.gameObject.SetActive(false);
            if (timer >= timeLimit)
            {
                timer = 0.0f;
                score += 10;
                scoreBoost = 10;
                txt.text = score.ToString();
            }
            else
            {
                score += (10 + scoreBoost);
                scoreBoost+=10;
                txt.text = score.ToString();
            }

        }
    }

        // Update is called once per frame
    void Update ()
    {
        timer += Time.deltaTime;

    }
}
