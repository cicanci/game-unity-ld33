using UnityEngine;

public class ButtonController : MonoBehaviour {

    public void OnClick(int sceneIndex)
    {
        Time.timeScale = 1; //unpause game
        Application.LoadLevel(sceneIndex);
    }
}
