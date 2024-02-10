#region

using System.Collections.Generic;
using rStarUtility.Util.Extensions.Csharp;
using UnityEngine;

#endregion

namespace Shared.Scripts
{
    public class Dot : MonoBehaviour
    {
    #region Private Variables

        private const float damageTime = 1f;
        private       float damageRemainingTime;

        [SerializeField]
        private List<Damageable> damageables = new List<Damageable>();

        [SerializeField]
        private bool useCast;

    #endregion

    #region Unity events

        private void Awake()
        {
            ResetTimer();
        }

        private void Update()
        {
            damageRemainingTime -= Time.deltaTime;
            if (damageRemainingTime > 0) return;
            ResetTimer();
            if (useCast) DamageHelper.DealDamage(transform.position , Vector2.one);
            else DealDamageTo(damageables);
        }

    #endregion

    #region Private Methods

        private void DealDamageTo(IEnumerable<Damageable> list)
        {
            list.ForEach(damageable => damageable.TakeDamage());
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent<Damageable>(out var damageable).IsFalse()) return;
            // Debug.Log($"TriggerEnter: {damageable.gameObject}");
            damageables.Add(damageable);
        }

        private void OnTriggerExit2D(Collider2D col)
        {
            if (col.TryGetComponent<Damageable>(out var damageable).IsFalse()) return;
            // Debug.Log($"TriggerEnter: {damageable.gameObject}");
            damageables.Remove(damageable);
        }

        private void ResetTimer()
        {
            damageRemainingTime = damageTime;
        }

    #endregion
    }
}