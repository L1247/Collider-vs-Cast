#region

using System.Linq;
using rStarUtility.Util.Extensions.Csharp;
using rStarUtility.Util.Helper;
using UnityEngine;

#endregion

namespace Shared.Scripts
{
    public class DamageHelper
    {
    #region Public Methods

        public static void DealDamage(Vector2 position , Vector2 range)
        {
            var damageables = CastHelper.GetAllWithBox<Damageable>(position , range);
            Debug.Log($"damageables count: {damageables.Count()}");
            damageables.ForEach(damageable => Debug.Log($"{damageable}"));
        }

    #endregion
    }
}