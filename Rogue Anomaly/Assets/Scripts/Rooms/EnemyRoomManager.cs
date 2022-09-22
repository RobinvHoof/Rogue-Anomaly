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
            WakeEnemies();
            StartCoroutine(CheckEnemies());
            GetComponent<Collider>().enabled = false;
        }
    }
    
    void Start()
    {
        foreach (EnemyHealth enemy in enemies)
        {
            enemy.gameObject.SetActive(false);
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
