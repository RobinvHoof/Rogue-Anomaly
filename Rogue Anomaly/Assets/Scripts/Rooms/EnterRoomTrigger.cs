using UnityEngine;

public class EnterRoomTrigger : MonoBehaviour
{
    [SerializeField] RoomManager parentRoom;

    private void OnTriggerEnter(Collider other)
    {
        parentRoom.TriggerRoomEnter();
    }
}
