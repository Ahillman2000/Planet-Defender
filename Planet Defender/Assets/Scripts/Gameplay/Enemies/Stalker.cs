using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stalker : MonoBehaviour
{
    private bool cloaked = false;

    public float cloakedValue = 0.1f;
    public float decloakedValue = 1f;

    public float cloakCooldown = 2.5f;

    SpriteRenderer[] child_SR;

    void Start()
    {
        child_SR = this.GetComponentsInChildren<SpriteRenderer>();
    }

    private void ChangeCloakValue(float cloakValue)
    {
        for (int i = 0; i < child_SR.Length; i++)
        {
            Color _tmp = child_SR[i].color;
            _tmp.a = cloakValue;
            child_SR[i].color = _tmp;
        }
    }

    IEnumerator Cloak()
    {
        ChangeCloakValue(cloakedValue);
        Debug.Log("cloacked");

        yield return new WaitForSeconds(cloakCooldown);

        ChangeCloakValue(decloakedValue);
        Debug.Log("decloaked");
        cloaked = false;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            if (!cloaked)
            {          
                StartCoroutine(Cloak());
            }
        }
    }
}
