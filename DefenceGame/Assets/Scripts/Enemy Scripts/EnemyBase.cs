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
    [SerializeField]
    protected float _getUpTicker;
    [SerializeField]
    protected float _getUpDelay = 2;
    [SerializeField]
    protected float velocity;
    //bools
    //Has the first collision occured?
    protected bool _firstcollision = false; 
    [SerializeField]
    protected bool _left = true;

    protected Controller _controller;

    protected Rigidbody2D _rb;
    // Use this for initialization
    protected void Start()
    {
        //Set the rigidbodys mass
        _rb = gameObject.GetComponent<Rigidbody2D>();
        _rb.mass = _mass;
        _controller = gameObject.GetComponent<Controller>();
        _getUpTicker = _getUpDelay;
    }
    virtual protected void Update()
    {
        if (!_controller.isGrabbed && _controller.isGrounded)
            Move();
        velocity = _rb.velocity.magnitude;
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
    protected bool CheckGetUp()
    {
        if (_rb.velocity.magnitude < .2 && !_controller.canWalk && _getUpTicker >= 0)
        {
            _getUpTicker -= Time.deltaTime;
        }
        else if (_getUpTicker < 0)
        {
            _getUpTicker = _getUpDelay;
            gameObject.transform.position += new Vector3(0, .05f, 0);
            gameObject.transform.rotation = Quaternion.Euler(Vector3.zero);
            return true;
        }
        return false;
    }
}