using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public TileManager tileScript;


	void Awake () {
        tileScript = GetComponent<TileManager>();
        InitGame();
	}
	
    void InitGame()
    {
        tileScript.SetupScene();
    }
	
	void Update () {
		
	}
}
