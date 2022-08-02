using UnityEngine;
using EnemySystem.Controller;

namespace EnemySystem.Controller.Level
{
    public class ControllerEnemyLevel : ControllerEnemy
    {
        private const byte MaxLevel = 15;
        private const byte ToLevel = 150;

        private static float currentEXP;
        private float Multiplier;
        public byte currentlevel;
        private attacking.attackingAI attacking;

        private void Start()
        {
            Multiplier = 5.5F;
            currentlevel++;
            GetExp = 0.5F;
            attacking = FindObjectOfType<attacking.attackingAI>();
        }

        private void Update()
        {
            currentEXP += Time.deltaTime / Multiplier;
            IsNewLevel();
        }

        private void IsNewLevel()
        {

            if (currentEXP < 0)
                currentEXP += ToLevel;
            //Add new level and add new exp to next level
            if (currentlevel != MaxLevel)
                if (currentEXP >= ToLevel)
                {
                    if (MaxHP == 0)
                        Setup();

                    MaxHP += 15F;
                    currentlevel++;
                    Multiplier += 0.5F;
                    currentEXP = 0;
                    attacking.DamageEnemy = attacking.DamageEnemy + 2.5F;
                    GetExp += 0.5F;
                    Debug.LogAssertion("Add level " + currentlevel + " Left to level " + currentEXP + " And to do new level is " + ToLevel);
                }
        }
    }
}