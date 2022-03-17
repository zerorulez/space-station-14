using System.Collections.Generic;
using Content.Server.Weapon.Guns.Components;
using Content.Server.Weapon.Ranged.Barrels.Components;
using Content.Shared.Popups;
using Robust.Shared.Containers;
using Robust.Shared.GameObjects;
using Robust.Shared.Localization;
using Robust.Shared.Prototypes;
using Robust.Shared.Serialization.Manager.Attributes;
using Robust.Shared.Serialization.TypeSerializers.Implementations.Custom.Prototype;

namespace Content.Server.Weapon.Ranged.Ammunition.Components
{
    [RegisterComponent]
    public sealed class MagazineComponent : Component
    {
        /// <summary>
        /// What type of receivers will accept this mag. ie Pistols for pistols Rifle for Rifles
        /// </summary>
        [DataField("magazineType")]
        public string MagazineType = default!;

        /// <summary>
        /// Caliber Type, ie 9x19mm, 5.56x45mm etc.
        /// </summary>
        [DataField("caliber", required: true, customTypeSerializer: typeof())]
        public CaliberComponent Caliber = default!;

        /// <summary>
        ///  Rounds that are loaded in the mag.
        /// </summary>
        [DataField("rounds", customTypeSerializer: typeof())]
        public Stack<EntityUid> Rounds = new();

        /// <summary>
        /// Special datafield used to fill a magazine with preset/s cartridge/s.
        /// </summary>
        [DataField("fillWith")]
        public SortedList<EntityUid, int> FillWithDict = new();

        /// <summary>
        /// Set Maximum capacity ( how many rounds the mag will hold )
        /// </summary>
        [DataField("capacity")]
        public int Capacity;

    }
}
