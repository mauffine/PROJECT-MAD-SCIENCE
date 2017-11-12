/* 
 * This script was written by John Ikonomou
 * Initial Creation Date: 5/8/17
 * Brief: Script used to control the enemy AI and calculate health based on collision forces.
 * Unity Exposed Variables:
 *      Health = This is the enemy's health value, the enemy will die when this reaches 0.
 *      Mass   = This is the object's mass in KG's.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float Health = 500.0f;
    public float Mass = 500.0f;

    private bool FirstCollision = false; //Has the first collision occured?

	// Use this for initialization
	void Start ()
    {
        //Set the rigidbodys mass
        Rigidbody2D RB = gameObject.GetComponent<Rigidbody2D>();
        RB.mass = Mass;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Check the health and destroy the object if the health gets too low.
	    if(Health <= 0.0f)
        {
            DestroyObject(gameObject);
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(FirstCollision) //Initial collision with ground has occured
        {
            float CollisionForce = GetCollisionForce(collision);
            Debug.Log(CollisionForce);

            if(CollisionForce > 25.0f) //If the collision force is sufficient, remove health equal to collision force.
            {
                Health -= CollisionForce;
            }
        }
        else //If first collision hasn;t occured, this is most likely it.
        {
            FirstCollision = true;
        }
    }

    //Get the collision force
    private float GetCollisionForce(Collision2D collision)
    {
        return Vector3.Dot(collision.contacts[0].normal, collision.relativeVelocity) * 15.0f;
    }
}
