using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HotspotClick : MonoBehaviour
{
    // Przypisz obiekty, do których chcesz dodać hotspotty
    public GameObject hotspot1;
    public GameObject hotspot2;

    public CameraMovement cameraMovement;
    
    void Update()
    {
        // Sprawdź czy użytkownik kliknął na ekranie
        if (Input.GetMouseButtonDown(0))
        {
            // Tworzymy promień od kamery do punktu kliknięcia myszą
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Sprawdź czy promień trafia w obiekt
            if (Physics.Raycast(ray, out hit))
            {
                // Sprawdź czy trafia w jeden z hotspotów
                if (hit.collider.gameObject == hotspot1)
                {
                   // cameraMovement.MoveCameraBy(10f, 0f, 0f);
                    // Wywołaj funkcję lub wykonaj jakieś działanie dla hotspot1
                    Debug.Log("Kliknięto w Hotspot 1");
                    SceneManager.LoadScene("Scene2");
                }
                else if (hit.collider.gameObject == hotspot2)
                {
                    // Wywołaj funkcję lub wykonaj jakieś działanie dla hotspot2
                    Debug.Log("Kliknięto w Hotspot 2");
                }
            }
        }
    }
}