using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TakeDamage : MonoBehaviour
{
    private HealthInformation targetHealth;

    // Start is called before the first frame update
    void Start()
    {
        targetHealth = GetComponent<HealthInformation>();
    }

    public void TakeDamageNow(float damage)
    {

        targetHealth.Health -= damage;

        Debug.Log(targetHealth.Health);
        if (targetHealth.Health <= 0) Invoke(nameof(DestroyTarget), .5f);
    }
    private void DestroyTarget()
    {
        SceneManager.LoadScene("GameOver");
    }
}
