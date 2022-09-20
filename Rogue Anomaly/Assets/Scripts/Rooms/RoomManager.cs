using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    [SerializeField] GameObject[] doors;

    public bool Cleared { get; set; } = false;

    protected void OpenRoomDoor(int doorNum)
    {
        doors[doorNum].GetComponent<Animator>().SetBool("opened", true);
    }

    protected void CloseRoomDoor(int doorNum)
    {
        doors[doorNum].GetComponent<Animator>().SetBool("opened", false);
    }

    protected void OpenAllRoomDoors()
    {
        foreach (GameObject door in doors)
        {
            door.GetComponent<Animator>().SetBool("opened", true);
        }
    }

    protected void CloseAllRoomDoors()
    {
        foreach (GameObject door in doors)
        {
            door.GetComponent<Animator>().SetBool("opened", false);
        }
    }
}
