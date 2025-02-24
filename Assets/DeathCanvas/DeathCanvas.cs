using UniRx;
using UnityEngine;

public class DeathCanvas: MonoBehaviour
{
    [SerializeField] private GameObject deathScreen;

    private CompositeDisposable disposables = new CompositeDisposable();
    private void Start()
    {
        PlayerHealth.instance.HealthValue
            .Where(health => health <= 0)          
            .Subscribe(
            health => PlayerDie())
            .AddTo(disposables);

    }

    private void PlayerDie()
    {
        deathScreen.SetActive (true);
        Cursor.lockState = CursorLockMode.Confined;
        Time.timeScale = 0f;
        //Debug.Log("Player Die");
    }





    private void OnDestroy()
    {
        disposables.Dispose();
    }

}
