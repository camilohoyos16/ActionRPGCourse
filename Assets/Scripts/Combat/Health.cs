using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour {

    public int baseHealth;
    public UnityEvent onDeath;
    private int currentHealth;
    public int CurrentHealth {
        get {
            return currentHealth;
        }
        set {
            if (value > 0 && value <= baseHealth) {
                currentHealth = value;
            } else if (value > baseHealth) {
                CurrentHealth = baseHealth;
            } else {
                currentHealth = 0;
                if(onDeath != null) {
                    onDeath.Invoke();
                }
            }
        }
    }

    // Use this for initialization
    void Start() {
        CurrentHealth = baseHealth;
    }

    public void SetCurrentHealt(int amount) {
        CurrentHealth += amount;
    }

    private void DestroyGO()
    {
        Destroy(this.gameObject);
    }
}
