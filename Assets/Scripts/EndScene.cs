/*
 * Author: Rajesh Cherukuri
 * EECS 290 Project 2
 */
using UnityEngine;
using System.Collections;

public class EndScene : MonoBehaviour
{
    public GUIStyle GameDataStyle;

    void OnGUI()
    {

        if (GameData.Instance.Deaths == 0 && GameData.Instance.SpecialCoins == 5)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 100, 300, 200), "Congratulations - you did it!", GameDataStyle);
        }
        else
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 100, 300, 200), "Congratulations - you did it! Will you find all 5 secrets without dying? Try again?", GameDataStyle);
        }
        GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 20, 100, 30), "Score: " + GameData.Instance.Score, GameDataStyle);
        GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 + 10, 100, 30), "Deaths: " + GameData.Instance.Deaths, GameDataStyle);
        GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 + 40, 100, 30), "Specials: (" + GameData.Instance.SpecialCoins + "/5)", GameDataStyle);

        if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 70, 200, 30), "Play"))
        {
            Application.LoadLevel("Level_1");
        }
        if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 110, 200, 30), "Exit"))
        {
            Application.Quit();
        }
    }
}
