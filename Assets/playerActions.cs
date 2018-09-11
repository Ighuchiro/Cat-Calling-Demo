using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerActions : MonoBehaviour {
    public int itemID = 0;
    private GameObject AttractorTool;
    private GameObject RepellerTool;

    // Use this for initialization
    void Start () {
        AttractorTool = this.transform.Find("Attractor").gameObject;
        RepellerTool = this.transform.Find("Repellor").gameObject;
        AttractorTool.SetActive(false);
        RepellerTool.SetActive(false);
    }

    // Update is called once per frame
    void Update () {
        var x = Input.GetAxis("Horizontal");
        var usingAttractor = Input.GetKeyDown(KeyCode.Q);
        var usingRepeller = Input.GetKeyDown(KeyCode.E);
        var usingNone = Input.GetKeyDown(KeyCode.R);
        if (usingNone == true)
        {
            itemID = 0;
            AttractorTool.SetActive(false);
            RepellerTool.SetActive(false);
        }
        if ( usingAttractor == true)
        {
            itemID = 1;
            AttractorTool.SetActive(true);
            RepellerTool.SetActive(false);

        }
        else if ( usingRepeller == true)
        {
            itemID = 2;
            AttractorTool.SetActive(false);
            RepellerTool.SetActive(true);
        }

    }

    void attractBehavior()
    {

    }

    void repelBehavior()
    {

    }
}
