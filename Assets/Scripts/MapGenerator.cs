using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MapGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject Wall;

    [SerializeField]
    private int MinSize;
    [SerializeField]
    private int MaxSize;
    [SerializeField]
    private int RoomNumber;

    private void Awake()
    {
        Generate();
    }
    private void CleanWall(UnitWallManager u,int x,int y, int size)
    {
        if (x == 0) 
        {
            if (y == 0)
            {
                u.InitWalls(false,false,true,true);
            }
            else if (y == size - 1)
            {
                u.InitWalls(true,false,false,true);
            }
            else
            {
                u.InitWalls(false,false,false,true);
            }
        }
        else if (x == size - 1) 
        {
            if (y == 0) 
            {
                u.InitWalls(false, true, true, false);
            }
            else if (y == size / 2)
            {
                u.InitWalls(false, false, false, false);
            }
            else if (y == size - 1)
            {
                u.InitWalls(true, true, false, false);
            }
            else 
            {
                u.InitWalls(false, true, false, false);
            }
        }
        else if (y == 0) 
        { 
            u.InitWalls(false, false, true, false);
        }
        else if (y == size - 1) 
        {
            u.InitWalls(true, false, false, false);
        }
        else 
            u.InitWalls(false, false, false, false);
    }
    private void CleanCorridor(UnitWallManager u)
    {
        u.InitWalls(true, false, true, false);
    }
    private void Generate()
    {
        float offset = 0.0f;
        int previous_size = 0;
        for (int i = 0; i < RoomNumber; i++)
        {
            int size = Random.Range(MinSize, MaxSize+1);
            for (int j = 0; j < size; j++)
            {
                for(int k = 0; k < size; k++)
                {
                    var position = new Vector3((k+offset) * 2.8f , j * 2.8f, 0);
                    var wu = Instantiate(Wall,
                                position,
                                Quaternion.identity
                        );
                    if (k == 0 && j == previous_size/2 && previous_size != 0)
                    {
                        if (previous_size / 2 + 1 == size)
                        {
                            wu.GetComponent<UnitWallManager>().InitWalls(true, false, false, false);
                        }
                        else
                        {
                            wu.GetComponent<UnitWallManager>().InitWalls(false, false, false, false);
                        }
                    }
                    else
                    {
                        CleanWall(wu.GetComponent<UnitWallManager>(),
                            k,
                            j,
                            size
                            );
                    }
                }
            }
            if (i<RoomNumber-1)
            {
                int corridor_length = Random.Range(3, 12);
                for (int j = 0; j < corridor_length; j++)
                {
                    var position = new Vector3((j + size + offset) * 2.8f, size / 2 * 2.8f, 0.0f);
                    var wu = Instantiate(Wall,
                                position,
                                Quaternion.identity);
                    CleanCorridor(wu.GetComponent<UnitWallManager>());
                }
                offset += size + corridor_length;
            }
            previous_size = size;
        }
    }

}
