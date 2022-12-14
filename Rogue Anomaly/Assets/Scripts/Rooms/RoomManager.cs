using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    [SerializeField] GameObject[] doors;

    public bool Cleared { get; private set; } = false;
    public bool Active { get; private set; } = false;

    public void TriggerRoomEnter()
    {
        Active = true;
        CloseAllDoors();
    }

    public void TriggerRoomCleared()
    {
        Cleared = true;
        Active = false;
        OpenAllDoors();
    }

    protected void OpenAllDoors()
    {
        foreach (GameObject door in doors)
        {
            door.GetComponent<Animator>().SetBool("opened", true);
            door.GetComponent<Collider>().enabled = false;
            door.GetComponent<AudioSource>().PlayDelayed(0.6f);
        }
    }

    protected void CloseAllDoors()
    {
        foreach (GameObject door in doors)
        {
            door.GetComponent<Animator>().SetBool("opened", false);
            door.GetComponent<Collider>().enabled = true;
            door.GetComponent<AudioSource>().PlayDelayed(1f);
        }
    }

    // Unused methods, for now...
    //
    // protected void OpenDoor(int doorNum)
    // {
    //     doors[doorNum].GetComponent<Animator>().SetBool("opened", true);
    // }

    // protected void CloseDoor(int doorNum)
    // {
    //     doors[doorNum].GetComponent<Animator>().SetBool("opened", false);
    // }
}
