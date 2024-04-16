using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Funkcja przesuwająca kamerę o określony dystans
    public void MoveCameraBy(float deltaX, float deltaY, float deltaZ)
    {
        // Przesuń kamerę o określony dystans wzdłuż poszczególnych osi
        transform.Translate(deltaX, deltaY, deltaZ, Space.World);
    }
}