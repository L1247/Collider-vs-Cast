#region

using System.Collections.Generic;
using System.Linq;
using rStarUtility.Util.Extensions.Csharp;
using UnityEngine;

#endregion

namespace Shared.Scripts
{
    public class CastHelper
    {
    #region Public Methods

        /// <summary>
        ///     return casted enemies
        /// </summary>
        /// <param name="centerPosition"></param>
        /// <param name="colliderSize"></param>
        /// <returns></returns>
        public static IEnumerable<Damageable> Cast(Vector2 centerPosition , Vector2 colliderSize)
        {
            // var collider2Ds =
            //         Physics2D.BoxCastAll(centerPosition , colliderSize , 0 , Vector2.zero , 0)
            //                  .Select(hit2D => hit2D.collider.GetComponent<Damageable>())
            //                  .Where(damageable => damageable.IsNotNull());
            var collider2Ds =
                    Physics2D.OverlapBoxAll(centerPosition , colliderSize , 0)
                             .Select(collider2D => collider2D.GetComponent<Damageable>())
                             .Where(damageable => damageable.IsNotNull());

            return collider2Ds;
        }

    #endregion
    }
}