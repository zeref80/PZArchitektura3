using UnityEngine;

public class ShowObjectOnMouseClick : MonoBehaviour
{
    public GameObject objectToShow; // Referencja do obiektu, który chcesz pokazać po kliknięciu

    private void OnMouseOver()
    {
        // Jeśli najechano myszką na obiekt i naciśnięto lewy przycisk myszy
        if (Input.GetMouseButtonDown(0))
        {
            // Sprawdź, czy obiektToShow nie jest null
            if (objectToShow != null)
            {
                // Ustaw obiektToShow jako aktywny (widoczny)
                objectToShow.SetActive(true);
            }
            else
            {
                Debug.LogWarning("Nie przypisano obiektu do pokazania!");
            }
        }
    }
}
