using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//requires gameobject that has this script to have defined components 
[RequireComponent(typeof(TrailRenderer), typeof(BoxCollider))]

public class ClickAndSwipe : MonoBehaviour
{
    //private variables
    private GameManager gameManager;
    private Camera cam;
    private Vector3 mousePos;
    private TrailRenderer trail;
    private BoxCollider col;
    private bool swiping = false;

    // Awake is called while instance is loading
    void Awake()
    {
        cam = Camera.main;
        trail = GetComponent<TrailRenderer>();
        col = GetComponent<BoxCollider>();
        trail.enabled = false;
        col.enabled = false;

        gameManager= GameObject.Find("Game Manager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive)
        {
            //when player clicks and holds left mouse button swiping becomes true and Trail and Box collider are activated 
            if (Input.GetMouseButtonDown(0))
            {
                swiping= true;
                UpdateComponents();
            }
            //when player lets go of left mouse button deactivate swiping and components
            else if (Input.GetMouseButtonUp(0)) 
            {
                swiping= false;
                UpdateComponents();
            }
            //while swiping run mouse position method bringing actions to top of hierarchy to be seen
            if (swiping)
            {
                UpdateMousePosition();
            }
        }
    }

    void UpdateMousePosition()
    {
        //takes mouse position from player input and changes from screen position to world position putting it at the top of the hierarchy 
        mousePos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
        transform.position = mousePos;
    }

    //Trail and Box collider components will activiate and deactivate when the swiping bool changes
    void UpdateComponents()
    {
        trail.enabled = swiping;
        col.enabled = swiping;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Target>())
        {
            //Destroy target
            collision.gameObject.GetComponent<Target>().DestroyTarget();
        }
    }
}
