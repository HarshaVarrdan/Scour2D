using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchDetection : MonoBehaviour
{
    public bool correct;
    private GameObject touchedObject;
    public static TouchDetection instance;

    //private Camera mainCamera;
    //private CinemachineVirtualCamera vcam;
    public LayerMask raycastLayerMask;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        //mainCamera = Camera.main;
        //vcam = FindObjectOfType<CinemachineVirtualCamera>();
    }
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            //Vector3 touchPosition = mainCamera.ScreenToWorldPoint(Input.GetTouch(0).position);
            //touchPosition.z = 0f;

            // Offset the raycast origin slightly forward
            //Vector3 raycastOrigin = touchPosition + mainCamera.transform.forward * 0.1f;
            //RaycastHit2D hit = Physics2D.Raycast(raycastOrigin, Vector2.zero, Mathf.Infinity, raycastLayerMask);

            RaycastHit2D hit = Physics2D.Raycast(touchPosition, Vector2.zero, 100f, raycastLayerMask);

            if (hit.collider != null)
            {
                touchedObject = hit.collider.gameObject;
                Debug.Log("Touched object: " + touchedObject.name);
                // Perform any actions you want with the touchedObject

                if (touchedObject.CompareTag("Answer"))
                {
                    correct = true;
                }
                else if (touchedObject.CompareTag("WrongAnswer"))
                {
                    ChangeColorToRed();
                }
            }
        }

    }

    void ChangeColorToRed()
    {
        Renderer rend = touchedObject.GetComponent<Renderer>();
        rend.material.color = Color.red;

        Invoke("ChangeColorToWhite", 0.5f);
    }
    void ChangeColorToWhite()
    {
        Renderer rend = touchedObject.GetComponent<Renderer>();
        rend.material.color = Color.white;
    }
}