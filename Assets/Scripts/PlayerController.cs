using UnityEngine;

public class PlayerController : MonoBehaviour, IInteractor
{
    public void TeleportTo(Transform teleportationPlace)
    {
        transform.position = teleportationPlace.position;

        GetComponentInChildren<CharacterController>().transform.position = teleportationPlace.position;
    }
}
