using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public struct intVector2{
	public int x,z;

	public intVector2(int x, int z){
		this.x = x;
		this.z = z;
	}

	public static intVector2 operator+(intVector2 a_A, intVector2 a_B){
		intVector2 iTemp;
		iTemp.x = a_A.x + a_B.x; 
		iTemp.z = a_A.z + a_B.z;

		return iTemp; 
	}


}
