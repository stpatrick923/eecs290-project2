/*
 * Author: Rajesh Cherukuri
 * EECS 290 Project 2
 */
using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour
{
    public GUIStyle GameDataStyle;
    public GUIStyle DialogStyle;

    void OnGUI()
    {

        GUI.Box(new Rect(10, 10, 120, 40), "Score: " + GameData.Instance.Score, GameDataStyle);
        GUI.Box(new Rect(10, 50, 120, 40), "Deaths: " + GameData.Instance.Deaths, GameDataStyle);
        GUI.Box(new Rect(10, 90, 120, 40), "Specials (" + GameData.Instance.SpecialCoins+"/5)", GameDataStyle);



        if (GameData.Instance.dialog != null)
        {
            GameData.Instance.Paused = true;
            GUI.Label(new Rect(Screen.width / 2 - 200, Screen.height / 2 - 100, 400, 200), GameData.Instance.dialog.text, DialogStyle);
            bool clicked = GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height / 2 + 125, 400, 30), "Okay");
            if (clicked || (Event.current.type == EventType.KeyDown && Event.current.keyCode == KeyCode.Tab))
            {
                GameData.Instance.dialog = null;
                GameData.Instance.Paused = false;
            }
        }
    }
}
