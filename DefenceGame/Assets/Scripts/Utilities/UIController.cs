using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
    [SerializeField]
    Text _scoreText;
    [SerializeField]
    Text _fundsText;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        _scoreText.text = "Score: " + Scorekeeper._score;
        _fundsText.text = "Funds: " + Scorekeeper._funds;
	}
}
