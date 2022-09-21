using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRoomManager : RoomManager
{
    [SerializeField] List<EnemyHealth> enemies;

    float sweepTime = 1;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !Cleared && !Active)
        {
            TriggerRoomEnter();
            WakeEnemies();
            StartCoroutine(CheckEnemies());
        }
    }

    void WakeEnemies()
    {
        foreach (EnemyHealth enemy in enemies)
        {
            enemy.gameObject.SetActive(true);
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
