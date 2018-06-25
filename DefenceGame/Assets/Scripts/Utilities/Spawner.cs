using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
enum lane
{
    Lane1,
    Lane2,
    Lane3
};
public class Spawner : MonoBehaviour {
    private lane _lane;
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    float _spawnDelay = 5;
    [SerializeField]
    float _spawnTicker;

    public bool _spawn = false;
    //Indicates whether it's on the left side
    [SerializeField]
    private bool _left = true;
    [SerializeField]
    GameObject gate;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (_spawn && _spawnTicker < 0)
        {
            SpawnUnit(_left);
            _spawnTicker = _spawnDelay;
        }
        if (_spawnTicker >= 0)
        {
            _spawnTicker -= Time.deltaTime;
        }
        //_spawnDelay -= Time.deltaTime / 60;
	}
    private void SpawnUnit(bool left)
    {
        float random = UnityEngine.Random.Range(0, 3);
        var spawnedEnemy = Instantiate(_enemyPrefab, new Vector3(transform.position.x, transform.position.y, random), Quaternion.identity);
        spawnedEnemy.GetComponent<EnemyBase>()._left = left;
        spawnedEnemy.GetComponent<EnemyBase>().gate = gate;
        _lane = (lane)random;
        spawnedEnemy.tag = Enum.GetName(typeof(lane), _lane);
    }
}
