using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    [SerializeField] GameObject door;

    void Start()
    {

    }

    void Update()
    {
        
    }

    void OpenRoomDoor()
    {
        door.GetComponent<Animator>().SetBool("opened", true);
    }
}
