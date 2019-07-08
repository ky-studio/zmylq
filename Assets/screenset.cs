using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screenset : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera mainCamera;
    private void Awake()
    {
        Screen.orientation = ScreenOrientation.LandscapeRight;
    }
    void Start()
    {
        Screen.orientation = ScreenOrientation.AutoRotation;

        Screen.autorotateToLandscapeLeft = true;

        Screen.autorotateToLandscapeRight = true;

        Screen.autorotateToPortrait = false;

        Screen.autorotateToPortraitUpsideDown = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
