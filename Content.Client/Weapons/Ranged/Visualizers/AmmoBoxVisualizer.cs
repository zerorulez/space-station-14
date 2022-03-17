using Robust.Client.GameObjects;

namespace Content.Client.Weapons.Ranged.Barrels.Visualizers;

public sealed class AmmoBoxVisualizer :  AppearanceVisualizer
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

        if (!component.TryGetData(CartrdigeVisualLayers.BoltOpen, out bool boltOpen))
        {
            return;
        }

        if (boltOpen)
        {
            sprite.LayerSetState(RangedBarrelVisualLayers.Bolt, "bolt-open");
        }
        else
        {
            sprite.LayerSetState(RangedBarrelVisualLayers.Bolt, "bolt-closed");
        }
    }

    public enum AmmoBoxVisualLayers : byte
    {
        Box,
        Cartridge,
        Label,
    }
}
