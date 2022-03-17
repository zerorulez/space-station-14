using System.Collections.Generic;
using Content.Server.Weapon.Guns.Components;
using Robust.Shared.Containers;
using Robust.Shared.GameObjects;
using Robust.Shared.Prototypes;
using Robust.Shared.Serialization.Manager.Attributes;
using Robust.Shared.Serialization.TypeSerializers.Implementations.Custom.Prototype;

namespace Content.Server.Weapon.Ranged.Ammunition.Components
{
    /// <summary>
    /// Used to load certain ranged weapons quickly
    /// </summary>
    [RegisterComponent]
    public sealed class MagazineSpeedLoaderComponent : Component
    {
        /// <summary>
        ///
        /// </summary>
        [DataField("caliber", required: true)]
        public CaliberComponent Caliber = default!;

        /// <summary>
        ///
        /// </summary>
        [DataField("capacity", required: true)]
        public int Capacity = default;

        /// <summary>
        ///  Rounds that are loaded in the mag.
        /// </summary>
        [DataField("rounds", customTypeSerializer: typeof())]
        public Stack<EntityUid> Rounds = new();

        /// <summary>
        /// Special DataField used to fill a magazine with preset/s cartridge/s.
        /// </summary>
        [DataField("fillWith")]
        public SortedList<EntityUid, int> FillWithDict = new();
    }
}
