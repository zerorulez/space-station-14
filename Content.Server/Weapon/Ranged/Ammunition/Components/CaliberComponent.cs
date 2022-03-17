namespace Content.Server.Weapon.Ranged.Ammunition.Components;

/// <summary>
///  Component for declaring the Caliber of ammo supported in barrels/barrel extensions etc.
/// </summary>
[RegisterComponent]
[Friend(typeof(GunSystem))]
public sealed class CaliberComponent : Component
{
    /// <summary>
    /// Caliber ID ie 12 Gauge, .45 ACP etc.
    /// </summary>
    [DataField("id", required: true)]
    public string ID { get; } = default!;

}

