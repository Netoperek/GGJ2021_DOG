using System.Collections;
using System.Collections.Generic;
using Platformer.Gameplay;
using UnityEngine;
using UnityEngine.UI;
using static Platformer.Core.Simulation;

namespace Platformer.Mechanics
{
    /// <summary>
    /// Represebts the current vital statistics of some game entity.
    /// </summary>
    public class Health : MonoBehaviour
    {
        [SerializeField] List<Image> iconsLive;
        [SerializeField] Color blackLife;
        [SerializeField] Color waithLife;




        /// <summary>
        /// The maximum hit points for the entity.
        /// </summary>
        public int maxHP = 1;

        /// <summary>
        /// Indicates if the entity should be considered 'alive'.
        /// </summary>
        public bool IsAlive => currentHP > 0;

        int currentHP;

        /// <summary>
        /// Increment the HP of the entity.
        /// </summary>
        public void Increment()
        {
            currentHP = Mathf.Clamp(currentHP + 1, 0, maxHP);
        }

        /// <summary>
        /// Decrement the HP of the entity. Will trigger a HealthIsZero event when
        /// current HP reaches 0.
        /// </summary>
        public void Decrement()
        {
            if (true)
            {


                currentHP = Mathf.Clamp(currentHP - 1, 0, maxHP);

                if (2 == currentHP)
                {
                    iconsLive[2].color = blackLife;


                }

                if (1 == currentHP)
                {
                    iconsLive[1].color = blackLife;

                }
                if (currentHP == 0)
                {
                    iconsLive[0].color = blackLife;
                    var ev = Schedule<HealthIsZero>();
                    ev.health = this;
                }

            }
        }


        IEnumerator Immortality()
        {
            
            yield return new WaitForSeconds(1f);
        }


        /// <summary>
        /// Decrement the HP of the entitiy until HP reaches 0.
        /// </summary>
        public void Die()
        {
            while (currentHP > 0) Decrement();
           
            StartCoroutine(heart());
        }

        void Awake()
        {
            iconsLive[0].color = waithLife;
            iconsLive[1].color = waithLife;
            iconsLive[2].color = waithLife;
            currentHP = maxHP;
        }
        IEnumerator heart()
        {
            yield return new WaitForSeconds(1.5f);
            iconsLive[0].color = waithLife;
            iconsLive[1].color = waithLife;
            iconsLive[2].color = waithLife;
            yield break;
        }
    }

    
}
