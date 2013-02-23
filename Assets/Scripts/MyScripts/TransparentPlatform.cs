/*
 * Author: Rajesh Cherukuri
 * EECS 290 Project 2
 */
using UnityEngine;
using System.Collections;

public class TransparentPlatform : MonoBehaviour
{

    public Shader shader;

    void Start()
    {
        shader = Shader.Find("Transparent/Bumped Specular");
        changeAlpha(1f, false);
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
            changeAlpha(0.5f, true);
    }

    private void changeAlpha(float alpha, bool trigger)
    {
        foreach (Renderer r in GetComponentsInChildren<Renderer>())
        {
            Color color = r.material.color;
            color.a = alpha;
            r.material.color = color;
            if (trigger)
            {
                r.material.shader = shader;
                r.collider.isTrigger = trigger;
            }
        }
    }

}
