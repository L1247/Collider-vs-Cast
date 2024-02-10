#region

using rStarUtility.Util.Extensions.Csharp;
using UnityEngine;

#endregion

namespace Shared.Scripts
{
    public class Projectile : MonoBehaviour
    {
    #region Private Variables

        private Rigidbody2D rigidbody2D;

        // 100 會先移動下一幀才偵測
        // 180 穿過敵人，不觸發傷害
        [SerializeField]
        private float moveSpeed = 3f;

    #endregion

    #region Unity events

        private void Awake()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            // move by transform
            transform.position += Vector3.right * (Time.deltaTime * moveSpeed);
            // move by physics 
            // 間接 move by transform 
            // rigidbody2D.position += Vector2.right * (Time.deltaTime * moveSpeed);
            DamageHelper.DealDamage(transform.position);
        }

    #endregion

    #region Private Methods

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent<Damageable>(out var damageable).IsFalse()) return;
            damageable.TakeDamage();
        }

    #endregion
    }
}