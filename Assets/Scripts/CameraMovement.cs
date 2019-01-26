using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public class CameraMovement : MonoBehaviour
{
    public float speed = 1.0f;
    public Transform horizontal;
    public Transform vertical;

    private Vector3 mouseStart;
    private Vector3 currentPos;
    private Quaternion origRot;

    private bool rotating = false;
    bool hasRotated = false;

    public Ease ease = Ease.InOutExpo;
    public float moveTime = 0.5f;

    public BoxCollider fitObject;
    public float fitMultiplier = 2.0f;
    public float rotSensitivity = 10.0f;
    public float swipeThreshold = 0.1f;

    public CameraRotateEvent OnHorizontalMove = new CameraRotateEvent();
    public CameraRotateEvent OnVerticalMove = new CameraRotateEvent();

    private bool movementHijacked;

    void Start()
    {
        origRot = transform.localRotation;
        //FitScreen();
        Input.gyro.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (movementHijacked) return;

        bool swiped = CheckSwipe();
    }

    void FitScreen()
    {
        Vector3 xyz = fitObject.size;
        float distance = Mathf.Max(xyz.x, xyz.y, xyz.z);
        distance /= (2.0f * Mathf.Tan(0.5f * Camera.main.fieldOfView * Mathf.Deg2Rad));
        // Move camera in -z-direction; change '2.0f' to your needs
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, -distance * fitMultiplier);
        fitObject.gameObject.SetActive(false);
    }

    public void HijackMovement()
    {
        transform.DOKill();
        movementHijacked = true;
    }

    public void ResumeControl()
    {
        transform.DOKill();
        movementHijacked = false;
    }

    bool CheckSwipe()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetMouseButtonDown(1) || (Input.touchCount > 1 && Input.GetTouch(1).phase == TouchPhase.Began))
        {
            mouseStart = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetMouseButtonUp(1) || Input.touchCount > 1 && (Input.GetTouch(1).phase == TouchPhase.Ended || Input.GetTouch(1).phase == TouchPhase.Canceled))
        {
            hasRotated = false;
        }
        else if (Input.GetKey(KeyCode.LeftShift) || Input.GetMouseButton(1) || (Input.touchCount > 1))
        {
            if (!hasRotated && !rotating)
            {
                currentPos = Camera.main.ScreenToViewportPoint(Input.mousePosition);

                //Left
                if (currentPos.x - mouseStart.x > swipeThreshold)
                {
                    //Debug.Log("Left");
                    OnHorizontalMove.Invoke(-1);
                    rotating = true;
                    horizontal.DOLocalRotate(Vector3.up * 90 * (vertical.eulerAngles.x < 0 || vertical.eulerAngles.x > 180 ? -1 : 1), moveTime, RotateMode.LocalAxisAdd).SetEase(ease).OnComplete(() => { rotating = false; });
                    hasRotated = true;
                    return true;
                }
                //Right
                else if (currentPos.x - mouseStart.x < -swipeThreshold)
                {
                    //Debug.Log("Right");
                    OnHorizontalMove.Invoke(1);
                    rotating = true;
                    horizontal.DOLocalRotate(-Vector3.up * 90 * (vertical.eulerAngles.x < 0 || vertical.eulerAngles.x > 180 ? -1 : 1), moveTime, RotateMode.LocalAxisAdd).SetEase(ease).OnComplete(() => { rotating = false; });
                    hasRotated = true;
                    return true;
                }
            }
        }
        return false;
    }

}
    [System.Serializable]
    public class CameraRotateEvent : UnityEvent<int> { }
