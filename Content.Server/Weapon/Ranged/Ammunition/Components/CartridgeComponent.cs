using Content.Server.Weapon.Ranged;
using Content.Shared.Damage.Prototypes;
using Content.Shared.Sound;
using Robust.Shared.Serialization.TypeSerializers.Implementations.Custom.Prototype.List;
using Robust.Shared.Utility;

namespace Content.Server.Weapon.Guns.Components;

/// <summary>
/// A Component that describes a type of ammunition or round
/// </summary>
[RegisterComponent]
[Friend(typeof(GunSystem))]
 public sealed class CartridgeComponent : Component
{
    /// <summary>
    /// If this Cartridge has a "case" ie a brass/steel case that holds primer+powder+bullet
    /// by default true as a large amount of ammo types have casings.
    /// </summary>
    [DataField("hasCasing")]
    public bool HasCasing { get; } = true;

    /// <summary>
    /// Damage Types the bullet will inflict upon hit.
    /// </summary>
    [DataField("damageTypes", required:true, customTypeSerializer: typeof(PrototypeIdListSerializer<DamageTypePrototype>))]
    public List<DamageTypePrototype> DamageTypes { get; } = default!;

    /// <summary>
    /// Damage Groups the bullet will inflict upon hit.
    /// </summary>
    [DataField("damageGroup", required:true, customTypeSerializer: typeof(PrototypeIdListSerializer<DamageTypePrototype>))]
    public List<DamageTypePrototype> DamageGroups { get; } = default!;

    /// <summary>
    /// How fast the projectile travels
    /// </summary>
    [DataField("velocity")]
    public float Velocity { get; } = 20f;

    /// <summary>
    /// Special Modifier for cartridges like buckshot or hollow point, which can fire many projectiles.
    /// If this is greater than 1, the ShotSpread is used to vary projectile distance.
    /// </summary>
    [DataField("projectileCount")]
    public int ProjectileCount { get; }

    /// <summary>
    ///  How far apart each projectile is if multiple are shot
    ///  TODO make barrel attachments like chokes affect this spread.
    /// </summary>
    [DataField("projectileSpread")]
    public float ProjectileSpread { get; }

    /// <summary>
    /// Sprite that is spawned on the muzzle when the gun is fired
    /// </summary>
    [DataField("muzzleFlash")]
    public ResourcePath? MuzzleFlashSprite = new("Objects/Weapons/Ranged/default_muzzle.png");

    /// <summary>
    /// Sprite that is spawned as the projectile when fired
    /// </summary>
    [DataField("projectileSprite")]
    public ResourcePath? ProjectileSprite = new("Objects/Weapons/Ranged/Ammunition/default_projectile.png");

    /// <summary>
    /// Sound that plays when a cartridge is ejected. defaults to Casing Eject as most rounds are brass casings
    /// </summary>
    [DataField("ejectSoundCollection")]
    public SoundSpecifier EjectSound { get; } = new SoundCollectionSpecifier("CasingEject");

}
