using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    private int currentRiddle;
    public GameObject riddle1;
    public GameObject presentationRiddle;

	// Use this for initialization
	void Start () {
        currentRiddle = 1;
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("riddle"))
        {
            if (currentRiddle == 1)
            {
                if (riddle1.activeSelf)
                {
                    riddle1.SetActive(false);
                }

                else
                {
                    riddle1.SetActive(true);
                }
            }

            if (currentRiddle == 2)
            {
                if (presentationRiddle.activeSelf)
                {
                    presentationRiddle.SetActive(false);
                }

                else
                {
                    presentationRiddle.SetActive(true);
                }
            }
        }
	}

    public void TookPhoto()
    {

    }
}
