using UnityEngine;

public class SetSigns : MonoBehaviour
{
  
    public void Plus()
    {
        GameManager.Instance.signs = Signs.Plus;
    }

    public void Minus()
    {
        GameManager.Instance.signs = Signs.Minus;
    }

    public void Divided()
    {
        GameManager.Instance.signs = Signs.Divide;
    }

    public void Multiply()
    {
        GameManager.Instance.signs = Signs.Multiply;
    }

}
