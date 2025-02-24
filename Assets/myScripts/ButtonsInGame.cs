using UnityEngine;

public class ButtonsInGame : MonoBehaviour
{
    
    public void RestartGame()
    {
        Time.timeScale = 1f;
        // ������������� ������� �����
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToMenu()
    {

        Time.timeScale = 1f;

        // ��������� ����� ���� (�������� "MenuScene" �� ��� ����� ����� ����)
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
