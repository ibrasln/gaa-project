using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private int currentHealth;
    [SerializeField] private Sprite sprite1, sprite2, sprite3;
    private SpriteRenderer sr;

    [SerializeField] private Text healthText;
    [SerializeField] private Image fadeScreen;
    [SerializeField] private Button restartButton;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        currentHealth = maxHealth;
        healthText.text = "HEALTH: " + currentHealth;
    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            fadeScreen.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
        }
        else if (currentHealth < 5)
        {
            sr.sprite = sprite3;
        }
        else if (currentHealth < 12)
        {
            sr.sprite = sprite2;
        }
        else if (currentHealth < 19)
        {
            sr.sprite = sprite1;
        }
    }

    public void TakeDamage()
    {
        currentHealth -= 1;
        healthText.text = "HEALTH: " + currentHealth;
    }
}
