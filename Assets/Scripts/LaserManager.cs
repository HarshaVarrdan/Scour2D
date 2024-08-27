using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserManager : MonoBehaviour
{

    [SerializeField] Transform endTransform;


    [SerializeField] GameObject lineRendererGO;
    LineRenderer lineRenderer;

    Quaternion rotation;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = lineRendererGO.GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        LR_RayCast();
    }

    void LR_RayCast()
    {
        Vector2 direction = (Vector2)lineRendererGO.transform.position - (Vector2)endTransform.position;
        float distance = Vector3.Distance(lineRendererGO.transform.position,endTransform.position);
        RaycastHit2D hit = Physics2D.Raycast(lineRendererGO.transform.position,-direction.normalized,distance);
        Debug.DrawRay(lineRendererGO.transform.position,-direction.normalized,Color.blue,distance);
        if(hit)
        {
            float hitObjectDistance = Vector3.Distance(hit.collider.gameObject.transform.position,lineRendererGO.transform.position);
            lineRenderer.SetPosition(1,new Vector3(hitObjectDistance,0,0));
            Debug.Log(hit.collider.gameObject.name);
            Debug.Log(hit.point.x + " " +hit.point.y);
            Debug.Log(direction.normalized + " " + distance);
        }
    }
}
