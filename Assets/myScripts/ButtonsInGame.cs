using UnityEngine;

public class ButtonsInGame : MonoBehaviour
{
    
    public void RestartGame()
    {
        Time.timeScale = 1f;
        // Перезагружаем текущую сцену
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToMenu()
    {

        Time.timeScale = 1f;

        // Загружаем сцену меню (замените "MenuScene" на имя вашей сцены меню)
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
