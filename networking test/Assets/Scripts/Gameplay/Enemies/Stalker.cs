using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stalker : MonoBehaviour
{
    bool cloaked = false;
    float cloakedValue = 0.1f;
    float decloakedValue = 1f;

    SpriteRenderer[] child_SR;

    void Start()
    {
        child_SR = this.GetComponentsInChildren<SpriteRenderer>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            if (!cloaked)
            {
                Debug.Log("cloack");

                for (int i = 0; i < child_SR.Length; i++)
                {
                    Color tmp = child_SR[i].color;
                    tmp.a = cloakedValue;
                    child_SR[i].color = tmp;
                }

                cloaked = true;
            }
            else
            {
                Debug.Log("decloak");

                for (int i = 0; i < child_SR.Length; i++)
                {
                    Color tmp = child_SR[i].color;
                    tmp.a = decloakedValue;
                    child_SR[i].color = tmp;
                }
                
                cloaked = false;
            }
        }
    }
}
