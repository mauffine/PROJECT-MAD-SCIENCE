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
        _scoreText.text = Scorekeeper._score.ToString();
        _fundsText.text = Scorekeeper._funds.ToString();
	}
}
