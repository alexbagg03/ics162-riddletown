using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public int currentRiddle;

    //Canvase Objects that display the current riddle
    public GameObject riddle1;
    public GameObject riddle2;
    public GameObject riddle3;

    //Model Objects (solutions) found in the Riddle Town.
    public GameObject Firebarrel; //solution to riddle 1
    public GameObject WaterTower; //solution to riddle 2
    public GameObject Crane; //solution to riddle 3

    [SerializeField] private AudioClip wrong;           // the sound played when character leaves the ground.
    [SerializeField] private AudioClip correct;
    private AudioSource m_AudioSource;

    //Used to calculate the frustrum of the camera and to determine if an object's collider is in the frustrum
    private Camera cam;
    private Plane[] planes;
    public Collider anObjCollider;

    // Use this for initialization
    void Start () {
        currentRiddle = 1;
        m_AudioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {

        DisplayRiddle();
	}

    public void TookPhoto()
    {
        cam = Camera.main;
        planes = GeometryUtility.CalculateFrustumPlanes(cam);
        if (currentRiddle == 1)
        {
            anObjCollider = Firebarrel.GetComponent<Collider>();
            if (GeometryUtility.TestPlanesAABB(planes, anObjCollider.bounds))
            {
                RaycastHit hit;
                Physics.Linecast(Camera.main.transform.position, Firebarrel.transform.position, out hit);
                if (hit.transform.name == "Solution1")
                {
                    PlayCorrectSound();
                    currentRiddle++;
                }

                else
                {
                    PlayWrongSound();
                }
            }
                
            else
            {
                PlayWrongSound();
            }
        }

        else if (currentRiddle == 2)
        {
            anObjCollider = WaterTower.GetComponent<Collider>();
            if (GeometryUtility.TestPlanesAABB(planes, anObjCollider.bounds))
            {
                RaycastHit hit;
                Physics.Linecast(Camera.main.transform.position, WaterTower.transform.position, out hit);
                if (hit.transform.name == "Solution2")
                {
                    PlayCorrectSound();
                    currentRiddle++;
                }

                else
                {
                    PlayWrongSound();
                }
            }

            else
            {
                PlayWrongSound();
            }
        }

        else if (currentRiddle == 3)
        {
            anObjCollider = Crane.GetComponent<Collider>();
            if (GeometryUtility.TestPlanesAABB(planes, anObjCollider.bounds))
            {
                RaycastHit hit;
                Physics.Linecast(Camera.main.transform.position, Crane.transform.position, out hit);
                if (hit.transform.name == "Solution3")
                {
                    PlayCorrectSound();
                    currentRiddle++;
                }

                else
                {
                    PlayWrongSound();
                }
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

    //Displays current riddle on the screen
    private void DisplayRiddle()
    {
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
                if (riddle2.activeSelf)
                {
                    riddle2.SetActive(false);
                }

                else
                {
                    riddle2.SetActive(true);
                }
            }

            if (currentRiddle == 3)
            {
                if (riddle3.activeSelf)
                {
                    riddle3.SetActive(false);
                }

                else
                {
                    riddle3.SetActive(true);
                }
            }
        }
    }
}
