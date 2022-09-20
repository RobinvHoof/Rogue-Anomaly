using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRoomManager : RoomManager
{
    [SerializeField] List<EnemyHealth> enemies;

    float sweepTime = 1;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            TriggerRoomEnter();
            StartCoroutine(CheckEnemies());
        }
    }

    IEnumerator CheckEnemies()
    {
        while (!Cleared)
        {
            if (enemies.Find(x => x.IsDead == false) == null) TriggerRoomCleared();
            yield return new WaitForSeconds(sweepTime);
        }
    }
}
