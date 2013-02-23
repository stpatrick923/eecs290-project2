/*
 * Author: Rajesh Cherukuri
 * EECS 290 Project 2
 */
using UnityEngine;
using System.Collections;

public class StartScreen : MonoBehaviour
{

    void OnGUI()
    {
        GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 200), "Welcome to Lerpz Odyssey!");
		GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 200), "EECS 290 Project 2");
		GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 25, 200, 200), "Rajesh Cherukuri, Patrick Melvin, Robert Meyer, Joe Conley");


        if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 15, 200, 30), "Play"))
        {
            Application.LoadLevel("Level_1");
        }
        if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 65, 200, 30), "Exit"))
        {
            Application.Quit();
        }
    }
}
