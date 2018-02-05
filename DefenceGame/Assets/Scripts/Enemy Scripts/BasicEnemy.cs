using UnityEngine;
using System.Collections;

public class BasicEnemy : EnemyBase {
	// Update is called once per frame
	void Update () {
        if (_health <= 0)
            Die();
        if (!_controller.isGrabbed && _controller.isGrounded && _controller.canWalk)
            Move();
        else if (!_controller.isGrabbed && _controller.isGrounded && !_controller.canWalk)
            _controller.canWalk = CheckGetUp();
    }

}
