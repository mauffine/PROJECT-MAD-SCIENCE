using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public bool left = true;
    [SerializeField]
    float leftPositionX;
    [SerializeField]
    float rightPositionX;
    [SerializeField]
    float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (left && transform.position.x > leftPositionX)
        {
            transform.position -= new Vector3(speed * Time.deltaTime,0);
            if (transform.position.x < leftPositionX)
            { transform.position = new Vector3(leftPositionX, transform.position.y, transform.position.z); }
        }
        else if (!left && transform.position.x < rightPositionX)
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0);
            if (transform.position.x > rightPositionX)
            { transform.position = new Vector3(rightPositionX, transform.position.y, transform.position.z); }
        }
	}
    public void Move()
    {
        if (left)
        {
            left = false;
        }
        else
        {
            left = true;
        }
    }

}
