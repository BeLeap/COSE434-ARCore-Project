using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GoogleARCore;

#if UNITY_EDITOR
using Input = GoogleARCore.InstantPreviewInput;
#endif

public class SceneController : MonoBehaviour
{
    public Camera firstPersonCamera;
    public TableController table;
    public ForceArrowManager forceArrow;

    private Vector2 startTouchPos;

    public float maxDragDistance = 100;

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
        if (Input.touchCount < 1)
        {
            return;
        }

        Touch touch = Input.GetTouch(0);

        if (touch.phase == TouchPhase.Began)
        {
            startTouchPos = touch.position;
        }
        else if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
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

            if (GameManager.instance.ball != null)
            {
                Vector3 start = GameManager.instance.ball.transform.position;

                GameManager.instance.dragDistance = (startTouchPos - touch.position) * 0.001f;
                Vector3 end = new Vector3(start.x + GameManager.instance.dragDistance.x, start.y, start.z + GameManager.instance.dragDistance.y);
                forceArrow.Draw(start, end);
            }
        }
        else if (touch.phase == TouchPhase.Ended && GameManager.instance.ball != null)
        {
            GameManager.instance.ball.GetComponent<BallManager>().Hit(GameManager.instance.dragDistance);
            forceArrow.Destroy();
        }
    }
}
