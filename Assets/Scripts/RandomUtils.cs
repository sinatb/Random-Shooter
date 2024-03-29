using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomUtils
{
    public Vector2 getRandomPos(float radius)
    {
        Vector2 pos = new Vector2(Random.Range(-8,8),Random.Range(-4,4));
        while (Vector2.Distance(pos,new Vector2(0, 0)) < radius)
        {
            pos = new Vector2(Random.Range(-10, 10), Random.Range(-4, 4));
        }
        return pos;
    }
}
