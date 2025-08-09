using UnityEngine;

public class UnitHealth : MonoBehaviour
{
    private int health;

    public void TakeDamage(int dmg)
    {
        if (health - dmg > 0)
            health -= dmg;
        else
            PlayerDeath();
    }

    private void PlayerDeath()
    {
        Debug.LogWarning("Player Died");
    }
}
