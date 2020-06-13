using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject completeLevelUI;
    
    public void CompletLevel(){
        Debug.Log("Level Won");
        completeLevelUI.SetActive(true);
    }




}
