using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Resizes an image to be the same size as teh canvas
public class ImageResizer : MonoBehaviour {
    public GameObject canvas;

    // Use this for initialization
    void Start()
    {
        RectTransform crt = canvas.GetComponent<RectTransform>();
        this.GetComponent<RectTransform>().sizeDelta = new Vector2(crt.sizeDelta.x, crt.sizeDelta.y);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
