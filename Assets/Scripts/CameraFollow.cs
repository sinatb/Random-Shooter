using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private GameObject Player;
    void Update()
    {
        gameObject.transform.position = new Vector3(Player.transform.position.x,
                                                    Player.transform.position.y,
                                                    -10);
    }
}
