using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitCam : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera camera1;
    public Camera camera2;

    private Rect camera1Rect;
    private Rect camera2Rect;

    void Start()
    {
        // Set up the camera rectangles
        camera1Rect = new Rect(0, 0, 0.5f, 1);
        camera2Rect = new Rect(0.5f, 0, 0.5f, 1);

        // Set the camera rects to the correct aspect ratio
        camera1Rect = AspectUtility.AdjustRect(camera1Rect, camera1.aspect);
        camera2Rect = AspectUtility.AdjustRect(camera2Rect, camera2.aspect);

        // Set the cameras to their respective rectangles
        camera1.rect = camera1Rect;
        camera2.rect = camera2Rect;
    }
}
