using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    [SerializeField] GameObject[] doors;

    public bool Cleared { get; private set; } = false;

    public void TriggerRoomEnter()
    {
        CloseAllDoors();
    }

    public void TriggerRoomCleared()
    {
        OpenAllDoors();
        Cleared = true;
    }

    protected void OpenDoor(int doorNum)
    {
        doors[doorNum].GetComponent<Animator>().SetBool("opened", true);
    }

    protected void CloseDoor(int doorNum)
    {
        doors[doorNum].GetComponent<Animator>().SetBool("opened", false);
    }

    protected void OpenAllDoors()
    {
        foreach (GameObject door in doors)
        {
            door.GetComponent<Animator>().SetBool("opened", true);
        }
    }

    protected void CloseAllDoors()
    {
        foreach (GameObject door in doors)
        {
            door.GetComponent<Animator>().SetBool("opened", false);
        }
    }
}
