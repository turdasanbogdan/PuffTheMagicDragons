using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MazeDirection {
    North,
    East,
    South,
    West
}

public static class MazeDirections {
    public const int Count = 4;

    public static MazeDirection RandomValue {
        get{
            return(MazeDirection)Random.Range(0, Count);
        }
    }

    private static intVector2[] vectors = {
        new intVector2(0,1),
        new intVector2(1,0),
        new intVector2(0,-1),
        new intVector2(-1,0)

    };

    public static intVector2 toIntVector2 (this MazeDirection direction){
        return vectors[(int)direction];
    } 

  private static MazeDirection[] opposites = {
		MazeDirection.South,
		MazeDirection.West,
		MazeDirection.North,
		MazeDirection.East
	};

	public static MazeDirection GetOpposite (this MazeDirection direction) {
		return opposites[(int)direction];
	}
    private static Quaternion[] rotations = {
		Quaternion.identity,
		Quaternion.Euler(0f, 90f, 0f),
		Quaternion.Euler(0f, 180f, 0f),
		Quaternion.Euler(0f, 270f, 0f)
	};
	
	public static Quaternion ToRotation (this MazeDirection direction) {
		return rotations[(int)direction];
	}
    public static MazeDirection GetNextClockwise (this MazeDirection direction) {
		return (MazeDirection)(((int)direction + 1) % Count);
	}

	public static MazeDirection GetNextCounterclockwise (this MazeDirection direction) {
		return (MazeDirection)(((int)direction + Count - 1) % Count);
	}
}