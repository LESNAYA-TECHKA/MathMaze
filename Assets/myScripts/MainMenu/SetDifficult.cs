using UnityEngine;

public class SetDifficult : MonoBehaviour
{

    public void Ez()
    {
        GameManager.Instance.difficult = Difficult.Easy;
    }

    public void Normal()
    {
        GameManager.Instance.difficult = Difficult.Normal;
    }

    public void Hard()
    {
        GameManager.Instance.difficult = Difficult.Hard;
    }

    public void SuperHard()
    {
        GameManager.Instance.difficult = Difficult.SuperHard;
    }
}
