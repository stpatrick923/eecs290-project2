/*
 * Author: Rajesh Cherukuri
 * EECS 290 Project 2
 */
using UnityEngine;
using System.Collections;

public class ResetGame : MonoBehaviour {

	void Start () {
        GameData.Instance.reset();
	}

}
