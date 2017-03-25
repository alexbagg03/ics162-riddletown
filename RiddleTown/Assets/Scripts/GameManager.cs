using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public int currentRiddle;

    //Canvase Objects that display the current riddle
    public GameObject riddle1;
    public GameObject riddle2;
    public GameObject riddle3;
    public GameObject riddle4;
    public GameObject riddle5;
    public GameObject riddle6;
    public GameObject riddle7;
    public GameObject finished;

    //Model Objects (solutions) found in the Riddle Town.
    public GameObject Firebarrel; //solution to riddle 1
    public GameObject WaterTower; //solution to riddle 2
    public GameObject RunningMan; //solution to riddle 3
    public GameObject Crane; //solution to riddle 4
    public GameObject Windmill; //solution to riddle 5
    public GameObject Bike; //solution to riddle 6
    public GameObject Key; //solution to riddle 7

    //Audio that plays when a player tries to solve a riddle
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

    //Player has taken a photo. Game Manager checks if object is in camera's frustrum then does a linecast to make sure nothing is blocking object
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
            anObjCollider = RunningMan.GetComponent<BoxCollider>();
            if (GeometryUtility.TestPlanesAABB(planes, anObjCollider.bounds))
            {
                RaycastHit hit;
                Physics.Linecast(Camera.main.transform.position, RunningMan.transform.position, out hit);
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

        else if (currentRiddle == 4)
        {
            anObjCollider = Crane.GetComponent<Collider>();
            if (GeometryUtility.TestPlanesAABB(planes, anObjCollider.bounds))
            {
                RaycastHit hit;
                Physics.Linecast(Camera.main.transform.position, Crane.transform.position, out hit);
                if (hit.transform.name == "Solution4")
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

        else if (currentRiddle == 5)
        {
            anObjCollider = Windmill.GetComponent<BoxCollider>();
            if (GeometryUtility.TestPlanesAABB(planes, anObjCollider.bounds))
            {
                RaycastHit hit;
                Physics.Linecast(Camera.main.transform.position, Windmill.transform.position, out hit);
                if (hit.transform.name == "Solution5")
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

        else if (currentRiddle == 6)
        {
            anObjCollider = Bike.GetComponent<BoxCollider>();
            if (GeometryUtility.TestPlanesAABB(planes, anObjCollider.bounds))
            {
                RaycastHit hit;
                Physics.Linecast(Camera.main.transform.position, Bike.transform.position, out hit);
                if (hit.transform.name == "Solution6")
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

        else if (currentRiddle == 7)
        {
            anObjCollider = Key.GetComponent<BoxCollider>();
            if (GeometryUtility.TestPlanesAABB(planes, anObjCollider.bounds))
            {
                RaycastHit hit;
                Physics.Linecast(Camera.main.transform.position, Key.transform.position, out hit);
                if (hit.transform.name == "Solution7")
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

            if (currentRiddle == 4)
            {
                if (riddle4.activeSelf)
                {
                    riddle4.SetActive(false);
                }

                else
                {
                    riddle4.SetActive(true);
                }
            }

            if (currentRiddle == 5)
            {
                if (riddle5.activeSelf)
                {
                    riddle5.SetActive(false);
                }

                else
                {
                    riddle5.SetActive(true);
                }
            }

            if (currentRiddle == 6)
            {
                if (riddle6.activeSelf)
                {
                    riddle6.SetActive(false);
                }

                else
                {
                    riddle6.SetActive(true);
                }
            }

            if (currentRiddle == 7)
            {
                if (riddle7.activeSelf)
                {
                    riddle7.SetActive(false);
                }

                else
                {
                    riddle7.SetActive(true);
                }
            }

            if (currentRiddle == 8)
            {
                if (finished.activeSelf)
                {
                    finished.SetActive(false);
                }

                else
                {
                    finished.SetActive(true);
                }
            }
        }
    }
}
