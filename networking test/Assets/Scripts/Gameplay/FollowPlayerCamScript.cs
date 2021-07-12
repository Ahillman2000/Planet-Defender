using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerCamScript : MonoBehaviour
{
    public GameObject playerToFollow;

    void Update()
    {
        this.transform.position = playerToFollow.transform.position;
    }
}
