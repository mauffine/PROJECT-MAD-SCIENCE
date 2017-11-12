﻿/* 
 * This script was written by John Ikonomou
 * Initial Creation Date: 4/8/17
 * Brief: Script used to allow player to manipulate physics objects (eg. Throw, Hold, Drop)
 * Unity Exposed Variables:
 *      JointMaxForce = This will set the maximum force used to reach the target (Mouse).
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    //Booleaans
    private bool IsOver = false;
    private bool IsGrabbed = false;
    //Mouse position vectors
    private Vector2 MousePositionWorldSpace;
    private Vector2 MousePosition2D;
    //TargetJoint.
    private TargetJoint2D TG = null;
    public float JointMaxForce = 8000;

    // Update is called once per frame
    private void Start()
    {
        TG = GetComponent<TargetJoint2D>();
        TG.maxForce = JointMaxForce;
        TG.enabled = false;
    }

    void Update()
    {
        //Update the mouse position
        MousePosition2D = Input.mousePosition;
        MousePositionWorldSpace = Camera.main.ScreenToWorldPoint(MousePosition2D);

        //if(Input.touchCount > 0)
        //{
        //    if(Input.GetTouch(0).phase == TouchPhase.Began)
        //    {
         
        //    }
        //    if (Input.GetTouch(0).phase == TouchPhase.Moved)
        //    {

        //    }
        //    if (Input.GetTouch(0).phase == TouchPhase.Ended)
        //    {

        //    }
        //}



        if (IsGrabbed)
        {
            //Set the targetjoint's target
            TG.target = MousePositionWorldSpace;
        }
    }

    private void OnMouseDown()
    {
        if(IsOver) //Pick the object up if it can be picked up
        {
            IsGrabbed = true;
            TG.enabled = true;
            TG.anchor = MousePositionWorldSpace - (Vector2)transform.position;
        }
    }

    void OnMouseUp()
    {
        if(IsGrabbed) //release the object if it has-been/is picked up.
        {
            IsGrabbed = false;
            TG.enabled = false;
        }
    }

    //IsOver governs whether or not the object can be picked up.
    private void OnMouseEnter()
    {
        IsOver = true;
    }
    private void OnMouseExit()
    {
        IsOver = false;
    }
}
