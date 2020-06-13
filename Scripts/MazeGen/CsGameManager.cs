using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CsGameManager : MonoBehaviour
{
	// public intVector2 iSize;
	// public Cs_MazeCell mazeCellPrefab;
	// private Cs_MazeCell mazeCellInstance;
	// private Cs_MazeCell[] cells;
	// public Cs_Player playerPrefab;

	// private Cs_Player playerInstance;

	public Cs_Maze mazePrefab;
	private Cs_Maze mazeInstance;
    // Start is called before the first frame update
    private void Start()
    {
       StartCoroutine(BeginGame());
    }

    // Update is called once per frame
    private void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			RestartGame();
		}
	}

    private IEnumerator BeginGame(){

    	mazeInstance = Instantiate(mazePrefab) as Cs_Maze;	
    	yield return StartCoroutine(mazeInstance.Generate());
		// playerInstance = Instantiate(playerPrefab) as Cs_Player;
		// playerInstance.SetLocation(mazeInstance.GetCell(mazeInstance.RandomCoordinates));
    }

    private void RestartGame(){
    	StopAllCoroutines();
    	Destroy(mazeInstance.gameObject);
    	// if (playerInstance != null) {
		// 	Destroy(playerInstance.gameObject);
		// }
		StartCoroutine(BeginGame());
    }
}
