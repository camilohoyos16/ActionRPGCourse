using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour {

    public int baseHealth;
    public int myHealth { get { return baseHealth + healthModifier; } }
    private int currentHealth;
    public int healthModifier;

    public Image healthBarImage;
    public UnityEvent onDeath;

    public int CurrentHealth {
        get {
            return currentHealth;
        }
        set {
            if (value > 0 && value <= myHealth) {
                currentHealth = value;
            } else if (value > myHealth) {
                CurrentHealth = myHealth;
            } else {
                currentHealth = 0;
                gameObject.layer = 12;
                if(onDeath != null) {
                    onDeath.Invoke();
                }
            }
        }
    }

    // Use this for initialization
    void Start() {
        CurrentHealth = myHealth;
    }

    public void SetCurrentHealt(int amount) {
        CurrentHealth += amount;
        if(healthBarImage != null) {
            UpdateHealthBar();
        }
    }

    private void UpdateHealthBar()
    {
        this.healthBarImage.fillAmount = ( (float)currentHealth / (float)myHealth );
    }

    public void ModifyBaseHealth(int value)
    {
        baseHealth += value;
        UpdateHealthBar();
    }

    private void DestroyGO()
    {
        Destroy(this.gameObject);
    }
}
