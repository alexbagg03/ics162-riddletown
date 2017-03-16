using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    private int currentRiddle;
    public GameObject riddle1;
    public GameObject presentationRiddle;
    public GameObject RD1Human;
    public GameObject RD1barrel;
    [SerializeField] private AudioClip wrong;           // the sound played when character leaves the ground.
    [SerializeField] private AudioClip correct;
    private AudioSource m_AudioSource;

    // Use this for initialization
    void Start () {
        currentRiddle = 1;
        m_AudioSource = GetComponent<AudioSource>();

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

        if (Input.GetButtonDown("presentation"))
        {
            PlayCorrectSound();
        }
	}

    public void TookPhoto()
    {
        if (currentRiddle == 1)
        {
            Vector3 screenPoint = Camera.main.WorldToViewportPoint(RD1Human.transform.position);
            bool onScreen1 = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;
            screenPoint = Camera.main.WorldToViewportPoint(RD1Human.transform.position);
            bool onScreen2 = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;

            if (onScreen1 && onScreen2)
            {
                PlayCorrectSound();
                currentRiddle = 2;
            }

            else
            {
                PlayWrongSound();
            }
        }

    }

    private void PlayCorrectSound()
    {
        m_AudioSource.clip = correct;
        m_AudioSource.Play();
    }

    private void PlayWrongSound()
    {
        m_AudioSource.clip = wrong;
        m_AudioSource.Play();
    }
}
