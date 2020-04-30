using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CsGameManager : MonoBehaviour
{
	// public intVector2 iSize;
	// public Cs_MazeCell mazeCellPrefab;
	// private Cs_MazeCell mazeCellInstance;
	// private Cs_MazeCell[] cells;

	public Cs_Maze mazePrefab;
	private Cs_Maze mazeInstance;
    // Start is called before the first frame update
    private void Start()
    {
        BeginGame();
    }

    // Update is called once per frame
    private void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			RestartGame();
		}
	}

    private void BeginGame(){

    	mazeInstance = Instantiate(mazePrefab) as Cs_Maze;	
    	StartCoroutine(mazeInstance.Generate());
    }

    private void RestartGame(){
    	StopAllCoroutines();
    	Destroy(mazeInstance.gameObject);
    	BeginGame();
    }
}
