using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private Transform SpawnPos;
    [SerializeField]
    private float ShootTimer = 0.25f;
    private bool _canSpawn = true;

    private IEnumerator shoot_delay()
    {
        if (!_canSpawn)
        {
            yield return new WaitForSeconds(ShootTimer);
            _canSpawn = true;
        }
    }
    private void Update()
    {
        var mouse_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var deltaX = mouse_pos.x - transform.position.x;
        var deltaY = mouse_pos.y - transform.position.y;
        var angle = math.degrees(math.atan2(deltaY, deltaX));
        transform.rotation = Quaternion.Euler(0,0,angle - 90.0f);
        if (Input.GetMouseButton(0) && _canSpawn)
        {
            Instantiate(bullet, SpawnPos.position, transform.rotation);
            _canSpawn = false;
            StartCoroutine(shoot_delay());
        }
    }
}
