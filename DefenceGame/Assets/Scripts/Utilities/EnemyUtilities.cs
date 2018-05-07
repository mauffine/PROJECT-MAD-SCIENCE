/*
 * Script Written by Sean Mauff
 * Created on 18/11/17
 * A basic class to hold all the utility functions that will be used across the different kinds of enemies
 */
using UnityEngine;
using System.Collections;
namespace Utilities
{
    public class EnemyUtilities : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {

        }
        public float CalcDamage(Collision2D col)
        {
            float collisionForce = GetCollisionForce(col);
            collisionForce = Mathf.Abs(collisionForce);
            Debug.Log(collisionForce);
            if (collisionForce > 25.0f) //If the collision force is sufficient, remove health equal to collision force.
            {
                return collisionForce;
            }
            return 0.0f;
        }

        //Get the collision force
        private float GetCollisionForce(Collision2D collision)
        {
            return Vector3.Dot(collision.contacts[0].normal, collision.relativeVelocity) * 15.0f;
        }
        //TODO: finish this so I can have the Villager stand properly
        public float RotateVector2(Vector2 vector, float Radians)

    }
}

