using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTrigger : MonoBehaviour
{
    public GameManager gameManager;
    public Hud hud;

    private void OnTriggerEnter(Collider other)
    {
        
        if  (other.gameObject.tag == "LvlTrigger") 
        {
            hud.ChangeCursorTips("Press E");
        }
        else if (other.gameObject.tag == "WindowPuzzle")
        {
            hud.ChangeCursorTips("Press E");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "LvlTrigger" && Input.GetKey(KeyCode.E))
        {
            gameManager.levelNumber++;
            hud.ChangeCursorTips("");
            Debug.Log("Start Lvl " + gameManager.levelNumber);
            Destroy(other.gameObject);

            //Level System
            if (gameManager.levelNumber==1){
                gameManager.Level1();
            }
        }
        else if (other.gameObject.tag == "WindowPuzzle" && Input.GetKey(KeyCode.E))
        {
            hud.ChangeCursorTips("");
            Debug.Log("Puzzle Start");
            other.gameObject.SetActive(false);
            gameManager.Level2();
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.tag == "LvlTrigger")
        {
            hud.ChangeCursorTips("");
        }
        else if (other.gameObject.tag == "WindowPuzzle")
        {
            hud.ChangeCursorTips("");
        }
    }

    
}
