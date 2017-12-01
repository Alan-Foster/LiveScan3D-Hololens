using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using HoloToolkit.Unity;

public class KeyWordController : MonoBehaviour
{
    public TextToSpeech textToSpeech;
    public Vector3 pointCloudOriginalPosition;
    public Vector3 pointCloudOriginalRotation;
    public Transform pointCloudTransform;

    void Start()
    {
        pointCloudOriginalPosition = pointCloudTransform.position;
        pointCloudOriginalRotation = pointCloudTransform.eulerAngles;
    }
    public void ZoomIn()
    {

        pointCloudTransform.localScale = pointCloudTransform.localScale + new Vector3(0.2f, 0.2f, 0.2f);
        textToSpeech.StartSpeaking("Zooming in.");
    }


    public void ZoomOut()
    {
        if (pointCloudTransform.localScale.x > 0.25f)
        {
            pointCloudTransform.localScale = pointCloudTransform.localScale - new Vector3(0.2f, 0.2f, 0.2f);
            textToSpeech.StartSpeaking("Zooming out.");
        }

        else
        {
            textToSpeech.StartSpeaking("Cannot zoom out further.");
        }
    }

    public void Reset()
    {

        pointCloudTransform.position = pointCloudOriginalPosition;
        pointCloudTransform.localEulerAngles = pointCloudOriginalRotation;
        pointCloudTransform.localScale = new Vector3(1, 1, 1);
        textToSpeech.StartSpeaking("Resetting the point cloud.");
    }
}
