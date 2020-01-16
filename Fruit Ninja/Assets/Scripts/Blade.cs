using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    public GameObject bladeTrailPrefab;
    GameObject currentBladeTrail;
    bool isCutting = false;
    Rigidbody2D rb;
    Camera cam;
    CircleCollider2D circleCollider;

    public float minCuttingVelocity = 0.005f;

    Vector2 previousPosition;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //Touch touch = Input.GetTouch(0)

        if(Input.GetMouseButtonDown(0)) //if(Input.touch(0))
        {
            StartCutting();
        }
        if(Input.GetMouseButtonUp(0))
        {
            StopCutting();
        }
        if(isCutting)
        {
            UpdateCut(/*touch*/);
        }
    }

    void StartCutting()
    {
        isCutting = true;
        currentBladeTrail = Instantiate(bladeTrailPrefab, transform);
        previousPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        circleCollider.enabled = true;
        
    }

    void StopCutting()
    {
        isCutting = false;
        currentBladeTrail.transform.SetParent(null);
        Destroy(currentBladeTrail, 2.0f);
        circleCollider.enabled = false;
    }

    void UpdateCut()
    {
        Vector2 newPosition = cam.ScreenToWorldPoint(Input.mousePosition);

        rb.position = newPosition;
        float velocity = (newPosition - previousPosition).magnitude * Time.deltaTime;
        if (velocity > minCuttingVelocity)
        {
            circleCollider.enabled = true;
        }
        else
            circleCollider.enabled = false;


        previousPosition = newPosition;

    }
}
