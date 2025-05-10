using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;

public class PlaceDrone : MonoBehaviour
{
    public GameObject dronePrefab; // Your drone model
    private GameObject spawnedDrone;
    public ARRaycastManager raycastManager;

    void Update()
    {
        if (Input.touchCount == 0 || spawnedDrone != null)
            return;

        Touch touch = Input.GetTouch(0);
        List<ARRaycastHit> hits = new List<ARRaycastHit>();

        if (raycastManager.Raycast(touch.position, hits, TrackableType.PlaneWithinPolygon))
        {
            Pose hitPose = hits[0].pose;
            spawnedDrone = Instantiate(dronePrefab, hitPose.position, hitPose.rotation);
        }
    }
}
