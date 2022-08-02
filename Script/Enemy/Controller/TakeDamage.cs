using EnemySystem.Controller;
using UnityEngine;


namespace EnemySystem.TakeDamage
{
    public class TakeDamage : ControllerEnemy
    {
        private Player.Contriller.ControllerPlayer ConntrolerPlayer;
        private EnemySystem.counter.EnemyCounter EnemyCounter;
        private DropItemFromEnemy DropItemfromEnemy;
        public bool Armor;

        private void Start()
        {
            ConntrolerPlayer = FindObjectOfType<Player.Contriller.ControllerPlayer>();
            EnemyCounter = FindObjectOfType<EnemySystem.counter.EnemyCounter>();
            DropItemfromEnemy = FindObjectOfType<DropItemFromEnemy>();
            EnemyCounter.CurrentAmmoutOfEnemy = EnemyCounter.EnemyC.Length;
            IsArmor = Armor;
            Setup();
        }

        /// <summary>
        /// Check collision 
        /// </summary>
        /// <param name="collision"></param>

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.tag == "Bullet")
            {
                if (Armor)
                {
                    //Mathf Damage with armor and round to int this type of damage 
                    float DamageWithArmor = ((float)ConntrolerPlayer.Damage) * ArmorValue;

                    if (DamageWithArmor <= 0)
                        DamageWithArmor = 0.5f;

                    TakeDmage(DamageWithArmor);

                    Debug.Log(DamageWithArmor + "   <DamageWithArmor ");
                }
                else
                    TakeDmage((float)ConntrolerPlayer.Damage);

            }
            return;
        }
        /// <summary>
        /// Take Damage in enemy 
        /// </summary>
        /// <param name="Damage"></param>
        public void TakeDmage(float Damage)
        {
            HP -= Damage;
            if (HP <= 0)
            {
                EnemyCounter.CurrentAmmoutOfEnemy = EnemyCounter.EnemyC.Length - 1;
                DropItemfromEnemy.SpawnItme(gameObject.transform.position);
                Destroy(gameObject, 0.02F);
                EnemyCounter.RomveEnemy();
                ConntrolerPlayer.CurrentEXP += GetExp;
                EnemyCounter.MaxAmmoutEnemy++;
                Debug.Log("Enemy die");
            }
        }
    }
}
