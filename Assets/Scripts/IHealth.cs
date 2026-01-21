public interface IHealth
{
    float MaxHealth     {get;}
    float CurrentHealth {get; set;}

    void TakeDamage (float damage);
}
