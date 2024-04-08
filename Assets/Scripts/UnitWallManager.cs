using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitWallManager : MonoBehaviour
{
    [SerializeField]
    private GameObject UpperWall;
    [SerializeField]
    private GameObject RightWall;
    [SerializeField]
    private GameObject DownWall;
    [SerializeField]
    private GameObject LeftWall;

    public void InitWalls(bool upper,bool right, bool down, bool left)
    {
        UpperWall.SetActive(upper);
        RightWall.SetActive(right);
        DownWall.SetActive(down);
        LeftWall.SetActive(left);
    }
}
