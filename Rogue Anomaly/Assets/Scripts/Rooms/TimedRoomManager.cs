using System.Collections;
using UnityEngine;

public class TimedRoomManager : RoomManager
{
    [SerializeField] float timeToOpenDoors = 10;

    void Start()
    {
        StartCoroutine(TimedTrigger());
    }

    IEnumerator TimedTrigger()
    {
        yield return new WaitForSeconds(timeToOpenDoors);
        TriggerRoomCleared();
    }
}
