using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public Slider health;
    public TextMeshProUGUI text;

    private void Awake()
    {
        health.value = 100;
        //updateHealthInCanvas();
    }



    public void TakeDamage(int damage)
    {
        health.value -= damage;
        //updateHealthInCanvas();
    }

    //private void updateHealthInCanvas()
    //{
    //    text.text = health.ToString();

    //}

}
