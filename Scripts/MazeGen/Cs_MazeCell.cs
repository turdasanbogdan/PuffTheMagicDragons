using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cs_MazeCell : MonoBehaviour
{
    
    public intVector2 iCoordinates;
	private int initializedEdgeCount;

    private Cs_MazeCellEdge[] edges = new Cs_MazeCellEdge[MazeDirections.Count];

	public Cs_MazeCellEdge GetEdge (MazeDirection direction) {
		return edges[(int)direction];
	}

	
	public bool IsFullyInitialized {
		get {
			return initializedEdgeCount == MazeDirections.Count;
		}
	}
	
	public void SetEdge (MazeDirection direction, Cs_MazeCellEdge edge) {
		edges[(int)direction] = edge;
		initializedEdgeCount += 1;
	}

	public MazeDirection RandomUninitializedDirection {
		get {
			int skips = Random.Range(0, MazeDirections.Count - initializedEdgeCount);
			for (int i = 0; i < MazeDirections.Count; i++) {
				if (edges[i] == null) {
					if (skips == 0) {
						return (MazeDirection)i;
					}
					skips -= 1;
				}
			}
			throw new System.InvalidOperationException("MazeCell has no uninitialized directions left.");
		}
	}

}
