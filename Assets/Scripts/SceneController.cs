using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GoogleARCore;

public class SceneController : MonoBehaviour
{
    public Camera firstPersonCamera;
    public TableController table;

    public Vector2 startTouchPos;

    // Start is called before the first frame update
    void Start()
    {
        QuitOnConnectionErrors();
    }

    // Update is called once per frame
    void Update()
    {
        if (Session.Status != SessionStatus.Tracking)
        {
            int lostTrackingSleepTimeout = 15;
            Screen.sleepTimeout = lostTrackingSleepTimeout;
            return;
        }
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        ProcessTouches();
    }

    void QuitOnConnectionErrors()
    {
        if (Session.Status == SessionStatus.ErrorPermissionNotGranted)
        {
            StartCoroutine(CodelabUtils.ToastAndExit("Camera permission is needed to run this application.", 5));
        }
        else if (Session.Status.IsError())
        {
            StartCoroutine(CodelabUtils.ToastAndExit("ARCore encountered a problem connecting. Please restart the app.", 5));
        }
    }

    void SetSelectedPlane(DetectedPlane selectedPlane)
    {
        table.SetPlane(selectedPlane);
    }

    void ProcessTouches()
    {
        //Touch touch;
        //if (Input.touchCount < 1 || (touch = Input.GetTouch(0)).phase != TouchPhase.Began)
        //{
        //    return;
        //}

        //TrackableHit hit;
        //TrackableHitFlags raycastFilter = TrackableHitFlags.PlaneWithinBounds | TrackableHitFlags.PlaneWithinPolygon;

        //if (Frame.Raycast(touch.position.x, touch.position.y, raycastFilter, out hit))
        //{
        //    SetSelectedPlane(hit.Trackable as DetectedPlane);
        //}

        if (Input.GetMouseButtonDown(0) && GameManager.instance.table == null)
        {
            if (GameManager.instance.table == null)
            {
                TrackableHit hit;
                TrackableHitFlags raycastFilter = TrackableHitFlags.PlaneWithinBounds | TrackableHitFlags.PlaneWithinPolygon;

                if (Frame.Raycast(Input.mousePosition.x, Input.mousePosition.y, raycastFilter, out hit))
                {
                    SetSelectedPlane(hit.Trackable as DetectedPlane);
                }
            }
        }

        if (Input.touchCount > 0 && GameManager.instance.ball != null) 
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                startTouchPos = touch.position;
            }
            if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
            {
                GameManager.instance.dragDistance = startTouchPos - touch.position;
            }
        }
    }
}
