using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRoomManager : RoomManager
{
    [SerializeField, Min(1)] int enemies = 1;

    void Update()
    {
        if (enemies <= 0)
        {
            TriggerRoomCleared();
        }
    }
}
