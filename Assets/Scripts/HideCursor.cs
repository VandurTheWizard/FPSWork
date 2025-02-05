using UnityEngine;

public class HideCursor : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Bloquea el cursor en el centro de la pantalla
        Cursor.visible = false; // Oculta el cursor
    }

    void Update()
    {
        // Si presionas Escape, desbloquea y muestra el cursor
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
