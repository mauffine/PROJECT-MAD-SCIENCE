using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour {
    [SerializeField]
    private float _health = 200;
    [SerializeField]
    GameObject gate;

    [SerializeField]
    private Sprite GateLvl1;
    [SerializeField]
    private Sprite GateLvl2;
    [SerializeField]
    private Sprite GateLvl3;

    [SerializeField]
    private Sprite HalfHealth;
    [SerializeField]
    private Sprite QuaterHealth;

    [SerializeField]
    private Sprite GateLvl1Broken;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (_health <= 0)
        { Die(); }
	}
    private void OnTriggerExit2D(Collider2D other)
    {
        other.GetComponent<EnemyBase>().StopAttacking();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        other.GetComponent<EnemyBase>().StartAttacking(gameObject);
    }
    public void TakeDamage(float damage)
    {
        _health -= damage;
    }
    private void Die()
    {
        Destroy(gate);
    }
}
