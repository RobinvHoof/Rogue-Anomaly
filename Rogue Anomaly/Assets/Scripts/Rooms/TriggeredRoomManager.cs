using System.Collections;
using UnityEngine;

public class TriggeredRoomManager : RoomManager
{
    [SerializeField] float timeToOpenDoors = 10;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(TimedTrigger());
            GetComponent<Collider>().enabled = false;
        }
    }

    IEnumerator TimedTrigger()
    {
        yield return new WaitForSeconds(timeToOpenDoors);
        TriggerRoomCleared();
    }
}
