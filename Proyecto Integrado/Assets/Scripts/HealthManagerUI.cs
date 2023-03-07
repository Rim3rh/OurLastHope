using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManagerUI : MonoBehaviour
{
    [SerializeField] private GameObject _dashCD;
    [SerializeField] private GameObject _healthTaker;
    [SerializeField] private Slider _healthSlider;

    private float _currentHealth;
    private float _maxHealth;

    void Start()
    {
        _maxHealth = _healthTaker.GetComponent<HealthManager>()._maxHealth;
        SetMaxHealth();
    }

    void Update()
    {

       
    }
    private void FixedUpdate()
    {
        CheckCurrentHealth();
        UpdateHealth();
    }

    private void CheckCurrentHealth()
    {
        _currentHealth = _healthTaker.GetComponent<HealthManager>()._currentHealth;
    }
    private void UpdateHealth()
    {
        
        _healthSlider.value = _currentHealth;
    }
    private void SetMaxHealth()
    {
        _healthSlider.maxValue = _maxHealth;
    }

}
