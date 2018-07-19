using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    [SerializeField]
    private int _currentHealth;
    public int CurrentHealth
    {
        get { return _currentHealth; }
        protected set
        {
            _currentHealth = value;
            gameObject.SendMessage("HealthChanged", value, SendMessageOptions.DontRequireReceiver);
        }
    }

    [SerializeField]
    private int _maxHealth;
    public int MaxHealth
    {
        get { return _maxHealth; }
        protected set
        {
            _maxHealth = value;
            if (CurrentHealth>_maxHealth)
            {
                CurrentHealth = _maxHealth;
            }
        }
    }

    Player player;
    public Slider healthBar;
	// Use this for initialization
	void Start () {
        CurrentHealth = MaxHealth;
        player = GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
        healthBar.value = CurrentHealth;
        if (CurrentHealth<=0)
        {
            player.OnRespawn();
            CurrentHealth = MaxHealth;
        }
	}

    public void HealthChange(int deltaChange)
    {
        CurrentHealth += deltaChange;
    }
}
