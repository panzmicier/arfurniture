using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaneDetect : MonoBehaviour
{
    private ARRaycastManager raycastManager;
    private GameObject spawnedObject;

    [SerializeField] GameObject prefabToSpawn;

    static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();

    void Awake()
    {
        raycastManager = GetComponent<ARRaycastManager>();
    }

    void Update()
    {
        if (!TryGetTouchPosition(out Vector2 touchPosition))
        {
            return;
        }

        if (raycastManager.Raycast(touchPosition, s_Hits, TrackableType.PlaneWithinPolygon))
        {
            var hitPose = s_Hits[0].pose;
            if (spawnedObject == null)
                spawnedObject = Instantiate(prefabToSpawn, hitPose.position, hitPose.rotation);
            else
            {
                spawnedObject.transform.position = hitPose.position;
                spawnedObject.transform.rotation = hitPose.rotation;
            }
        }
    }

    public bool TryGetTouchPosition (out Vector2 touchPosition)
    {
        if (Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }
        else
        {
            touchPosition = default;
            return false;
        }
    }



}
