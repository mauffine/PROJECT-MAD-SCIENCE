//Use this Exclusively for phyisics interactions and player interactions
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    //Booleaans
    private bool isOver = false;
    public bool isGrabbed = false;
    public bool isGrounded = false;
    public bool canWalk = true;
    //Mouse position vectors
    private Vector2 MousePositionWorldSpace;
    //TargetJoint.
    private TargetJoint2D TG = null;
    public float JointMaxForce = 8000;
    private Animator _animator;

    [SerializeField]
    private float rayLen;
    [SerializeField]
    private float rayYPos;

    [SerializeField]
    GameObject DropShadowOriginal;

    public GameObject _dropshadow;
    // Update is called once per frame
    private void Start()
    {
        TG = GetComponent<TargetJoint2D>();
        TG.maxForce = JointMaxForce;
        TG.enabled = false;
        _animator = gameObject.GetComponentInChildren<Animator>();
    }
    private void Awake()
    {
        _dropshadow = Instantiate(DropShadowOriginal, transform.position, Quaternion.identity);
        _dropshadow.transform.localScale = transform.localScale;
    }
    void Update()
    {
        //Update the mouse position
        MousePositionWorldSpace = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(Quaternion.Euler(transform.rotation.eulerAngles) * new Vector2(0,rayYPos) + transform.position,
            Vector2.down, rayLen, LayerMask.GetMask("Platform"),transform.position.z, transform.position.z);
        if (hit.collider != null && hit.collider.CompareTag(gameObject.tag))
        {
            isGrounded = true;
            Debug.DrawRay(Quaternion.Euler(transform.rotation.eulerAngles) * new Vector2(0, rayYPos) + transform.position, Vector2.down * rayLen, Color.green);
        }
        else
        {
            isGrounded = false;
            Debug.DrawRay(Quaternion.Euler(transform.rotation.eulerAngles) * new Vector2(0, rayYPos) + transform.position, Vector2.down * rayLen, Color.red);
        }
        RaycastHit2D shadow = Physics2D.Raycast(transform.position ,Vector2.down, Mathf.Infinity, LayerMask.GetMask("Platform"), transform.position.z, transform.position.z);
        if (shadow.collider != null && shadow.collider.CompareTag(gameObject.tag))
        {
            _dropshadow.transform.position = new Vector2(transform.position.x, transform.position.y - shadow.distance);
        }
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



            if (isGrabbed)
        {
            //Set the targetjoint's target
            TG.target = MousePositionWorldSpace;
        }
    }

    private void OnMouseDown()
    {
        if(isOver) //Pick the object up if it can be picked up
        {
            isGrabbed = true;
            canWalk = false;
            TG.enabled = true;
            TG.anchor = MousePositionWorldSpace - (Vector2)transform.position + Vector2.up * 2f;
            _animator.SetBool("Falling", true);
        }
    }

    void OnMouseUp()
    {
        if(isGrabbed) //release the object if it has-been/is picked up.
        {
            isGrabbed = false;
            TG.enabled = false;
        }
    }

    //IsOver governs whether or not the object can be picked up.
    private void OnMouseEnter()
    {
        isOver = true;
    }
    private void OnMouseExit()
    {
        isOver = false;
    }
    public Vector2 RotateVector2(Vector2 v, float degrees)
    {
        return Quaternion.Euler(0, 0, degrees) * v;
    }
}
