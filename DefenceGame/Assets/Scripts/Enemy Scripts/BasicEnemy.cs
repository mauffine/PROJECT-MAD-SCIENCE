using UnityEngine;
using System.Collections;

public class BasicEnemy : EnemyBase {
	// Update is called once per frame
	void Update () {
        base.Update();
        if (_health <= 0)
            Die();
    }

}
