using UnityEngine;


// Sets a custom cursor and starts it visually in the center of the screen.
//to make the cursor cutesy bee shape 
public class StartCursor : MonoBehaviour
{
    [Header("Custom Cursor Settings")]
    public Texture2D cursorTexture; // Assign in Inspector
    public Vector2 hotspot = Vector2.zero; // Cursor hotspot (pivot point)
    public CursorMode cursorMode = CursorMode.Auto;

    void Start()
    {
        // Set custom cursor if provided
        if (cursorTexture != null)
        {
            Cursor.SetCursor(cursorTexture, hotspot, cursorMode);
        }

        // Lock and unlock to force cursor to center
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
