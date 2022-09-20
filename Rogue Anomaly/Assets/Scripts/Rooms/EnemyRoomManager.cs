using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRoomManager : RoomManager
{
    [SerializeField] int enemies = 0;

    void Update()
    {
        if (enemies <= 0) OpenAllRoomDoors();
    }
}
