using UnityEngine;
using System.Collections;

public class BasicEnemy : EnemyBase {
	// Update is called once per frame
	void Update () {
        if (_health <= 0)
            Die();
        if (!gameObject.GetComponent<Controller>().isGrabbed && gameObject.GetComponent<Controller>().isGrounded)
            Move();
    }

}
