using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class Cs_Maze : MonoBehaviour
{
	public intVector2 iSize;
	public Cs_MazeCell mazeCellPrefab;
	private Cs_MazeCell mazeCellInstance;
	private Cs_MazeCell[,] cells;

	public Cs_MazePassage passagePrefab;
	public Cs_MazeWall wallPrefab;

    
    public float fGenerationStepDelay;

	public Cs_MazeCell GetCell(intVector2 coordinates){
		return cells[coordinates.x, coordinates.z];
	}
    
    public IEnumerator Generate(){
    	WaitForSeconds delay = new WaitForSeconds(fGenerationStepDelay);
    	cells = new Cs_MazeCell[iSize.x,iSize.z];
		
		List<Cs_MazeCell> activeCells = new List<Cs_MazeCell>();
		
		doFirstGenerationStep(activeCells);

		while(activeCells.Count >0){
			yield return delay;
			DoNextGenerationStep(activeCells);
		}
    }

    private Cs_MazeCell CreateCell(intVector2 a_Coordinates){
    	Cs_MazeCell newCell = Instantiate(mazeCellPrefab) as Cs_MazeCell;
    	cells[a_Coordinates.x, a_Coordinates.z] = newCell;
    	newCell.iCoordinates = a_Coordinates;
    	newCell.name = "MazeCell" + a_Coordinates.x + "," + a_Coordinates.z;

    	newCell.transform.parent = transform;

    	newCell.transform.localPosition = new Vector3(a_Coordinates.x - iSize.x* 0.5f + 0.5f, 0f,a_Coordinates.z - iSize.z * 0.5f + 0.5f);

		return newCell;
    }

	public intVector2 RandomCoordinates{
		get{
			return new intVector2(Random.Range(0,iSize.x), Random.Range(0, iSize.x));
		}
	
	}

	public bool ContainsCoordinates(intVector2 coordinate){
		return coordinate.x >= 0 && coordinate.x < iSize.x && coordinate.z >= 0 && coordinate.z < iSize.z;
	}

	private void doFirstGenerationStep(List<Cs_MazeCell> activeCells){
		activeCells.Add(CreateCell(RandomCoordinates));
	}

	private void DoNextGenerationStep(List<Cs_MazeCell> activeCells){
		int currentIndex = activeCells.Count -1;
		Cs_MazeCell currentCell = activeCells[currentIndex];
		if (currentCell.IsFullyInitialized) {
			activeCells.RemoveAt(currentIndex);
			return;
		}
		MazeDirection direction = currentCell.RandomUninitializedDirection;
		intVector2 coordinates = currentCell.iCoordinates + direction.toIntVector2();

		if (ContainsCoordinates(coordinates)) {
			Cs_MazeCell neighbor = GetCell(coordinates);
			if (neighbor == null) {
				neighbor = CreateCell(coordinates);
				CreatePassage(currentCell, neighbor, direction);
				activeCells.Add(neighbor);
			}
			else {
				CreateWall(currentCell, neighbor, direction);
				
			}
		}
		else {
			CreateWall(currentCell, null, direction);
			
		}

	}

	private void CreatePassage (Cs_MazeCell cell, Cs_MazeCell otherCell, MazeDirection direction) {
		Cs_MazePassage passage = Instantiate(passagePrefab) as Cs_MazePassage;
		passage.Initialize(cell, otherCell, direction);
		passage = Instantiate(passagePrefab) as Cs_MazePassage;
		passage.Initialize(otherCell, cell, direction.GetOpposite());
	}


	private void CreateWall (Cs_MazeCell cell, Cs_MazeCell otherCell, MazeDirection direction) {
		Cs_MazeWall wall = Instantiate(wallPrefab) as Cs_MazeWall;
		wall.Initialize(cell, otherCell, direction);
		if (otherCell != null) {
			wall = Instantiate(wallPrefab) as Cs_MazeWall;
			wall.Initialize(otherCell, cell, direction.GetOpposite());
		}
	}

}
