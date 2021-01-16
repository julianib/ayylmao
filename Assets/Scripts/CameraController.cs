using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    void Start()
    {
        SnapToPlayer();
    }

    void Update()
    {

    }

    private void LateUpdate()
    {
        SnapToPlayer();
    }

    private void SnapToPlayer()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
    }
}
