/* 
 * This script was written by Sean Mauff
 * Created on 18/11/17
 * Base Parent class of all enemies in the game
 */
  
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;
public class EnemyBase : MonoBehaviour
{

    protected EnemyUtilities _enemyUtilites = new EnemyUtilities();
    //floats
    [SerializeField]
    protected float _health = 500.0f;
    [SerializeField]
    protected float _mass = 1.0f;
    [SerializeField]
    protected float _damage;
    [SerializeField]
    protected float _speed;
    [SerializeField]
    protected float _points;
    //bools
    //Has the first collision occured?
    protected bool _firstcollision = false; 
    [SerializeField]
    protected bool _left = true;

    Rigidbody2D _rb;
    // Use this for initialization
    protected void Start()
    {
        //Set the rigidbodys mass
        _rb = gameObject.GetComponent<Rigidbody2D>();
        _rb.mass = _mass;
    }
    virtual protected void Update()
    {
        if (!this.gameObject.GetComponent<Controller>().isGrabbed)
            Move();
        
    }
    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {

        if (!collision.collider.CompareTag(this.tag))
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        }
            //Initial collision with ground has occured
            if (_firstcollision) 
        {
            _health -= _enemyUtilites.CalcDamage(collision);
        }
        //If first collision hasn;t occured, this is most likely it.
        else
        {
            _firstcollision = true;
        }
    }
    protected void Die()
    {
        Scorekeeper._score += (uint)_points;
        Scorekeeper._funds += (uint)_points;
        Destroy(gameObject);
    }
    protected void Move()
    {
        if(_left)
        {
            _rb.MovePosition(transform.position += new Vector3(_speed * Time.deltaTime, 0, 0));
        }
        else
        {
            _rb.MovePosition(transform.position += new Vector3(_speed * -Time.deltaTime, 0, 0));
        }
    }
}