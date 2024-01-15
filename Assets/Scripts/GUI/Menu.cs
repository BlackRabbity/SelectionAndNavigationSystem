using UnityEngine;

public class Menu : MonoBehaviour
{
    public void QuitGame ()
    {
        Debug.Log("Quit");
        Application.Quit ();
    }
}
