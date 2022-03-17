using Content.Shared.Weapons.Ranged.Barrels.Components;
using JetBrains.Annotations;
using Robust.Client.GameObjects;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;

namespace Content.Client.Weapons.Ranged.Barrels.Visualizers
{
    [UsedImplicitly]
    public sealed class CartridgeVisualizer : AppearanceVisualizer
    {
        public override void InitializeEntity(EntityUid entity)
        {
            base.InitializeEntity(entity);
            var sprite = IoCManager.Resolve<IEntityManager>().GetComponent<ISpriteComponent>(entity);
            sprite.LayerSetState(RangedBarrelVisualLayers.Bolt, "bolt-open");
        }

        public override void OnChangeData(AppearanceComponent component)
        {
            base.OnChangeData(component);
            var sprite = IoCManager.Resolve<IEntityManager>().GetComponent<ISpriteComponent>(component.Owner);

            if (!component.TryGetData(AmmoVisuals.Spent, out bool spent))
            {
                return;
            }

            sprite.LayerSetState(CartridgeVisualLayers.Spent, spent ? "spent" : "base");
        }
    }

    public enum CartridgeVisualLayers : byte
    {
        Head, //Used for stuff that has a half metallic half paper/plastic casing like shotgun cartridges.
        Casing, //Standard full casing, usually brass/steel/plastic
        TypeProjectile, // visual showing what this cartridge will fire.
        Spent, // visual that the cartridge has been used.
    }
}
