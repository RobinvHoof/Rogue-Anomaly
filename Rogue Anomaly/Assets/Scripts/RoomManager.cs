using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    [SerializeField] GameObject[] doors;
    [SerializeField, Min(0)] int enemies;

    void Start()
    {

    }

    void Update()
    {
        if (enemies <= 0) OpenRoomDoor(0);
    }

    void OpenRoomDoor(int roomNum)
    {
        doors[roomNum].GetComponent<Animator>().SetBool("opened", true);
    }

    void CloseRoomDoor(int roomNum)
    {
        doors[roomNum].GetComponent<Animator>().SetBool("opened", false);
    }

    public void RemoveEnemyFromRoom()
    {
        enemies--;
    }
}
