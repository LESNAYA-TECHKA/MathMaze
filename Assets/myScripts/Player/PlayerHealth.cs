using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int health;
    public TextMeshProUGUI text;

    private void Awake()
    {
        health = 100;
        updateHealthInCanvas();
    }



    public void TakeDamage(int damage)
    {
        health -= damage;
        updateHealthInCanvas();
    }

    private void updateHealthInCanvas()
    {
        text.text = health.ToString();

    }

}
