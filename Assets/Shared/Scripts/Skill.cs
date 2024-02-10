#region

using rStarUtility.Util.Extensions.Csharp;
using UnityEngine;

#endregion

namespace Shared.Scripts
{
    public class Skill : MonoBehaviour
    {
    #region Private Methods

        /// <summary>
        ///     can be Non MonoBehaviour
        /// </summary>
        [ContextMenu("Cast")]
        private void Cast()
        {
            DamageHelper.DealDamage(transform.position);
        }

        /// <summary>
        ///     Required MonoBehaviour
        /// </summary>
        /// <param name="col"></param>
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent<Damageable>(out var damageable).IsFalse()) return;
            Debug.Log($"TriggerEnter: {damageable.gameObject}");
        }

    #endregion
    }
}