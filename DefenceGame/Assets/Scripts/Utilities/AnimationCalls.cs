using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationCalls : MonoBehaviour {
    private EnemyBase enemyScript;
	// Use this for initialization
	void Start () {
        enemyScript = GetComponentInParent<EnemyBase>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Walk()
    {
        enemyScript.Walk();
    }
    public void Attack()
    {
        enemyScript.AttackGate();
    }
}
