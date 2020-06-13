using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Cs_MazeCellEdge : MonoBehaviour
{
   public Cs_MazeCell cell, otherCell;

   public MazeDirection direction;

    public void Initialize (Cs_MazeCell cell, Cs_MazeCell otherCell, MazeDirection direction) {
		this.cell = cell;
		this.otherCell = otherCell;
		this.direction = direction;
		cell.SetEdge(direction, this);
		transform.parent = cell.transform;
		transform.localPosition = Vector3.zero;
		transform.localRotation = direction.ToRotation();
	}



}  