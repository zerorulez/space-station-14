using Content.Client.Cabinet;
using Content.Client.Weapons.Ranged.Components;
using Content.Shared.Cabinet;
using Robust.Client.GameObjects;

namespace Content.Client.Weapons.Ranged;

public sealed class MagazineSystem : VisualizerSystem<MagazineVisualsComponent>
{

  public override void Initialize()
  {
    base.Initialize();

    var sprite = IoCManager.Resolve<IEntityManager>().GetComponent<ISpriteComponent>(entity);

    if (sprite.LayerMapTryGet(MagazineVisualLayers.Count, out _))
    {
      sprite.LayerSetState(MagazineVisualLayers.Count, $"{_magState}-{_magSteps-1}");
      sprite.LayerSetVisible(MagazineVisualLayers.Count, false);
    }

    if (sprite.LayerMapTryGet(MagazineVisualLayers.CountUnshaded, out _))
    {
      sprite.LayerSetState(MagazineVisualLayers.CountUnshaded, $"{_magState}-unshaded-{_magSteps-1}");
      sprite.LayerSetVisible(MagazineVisualLayers.CountUnshaded, false);
    }
  }

  // always show base
  // if count is 0 disable layer
  // if magtype is set show. change if changed.
  protected override void OnAppearanceChange(EntityUid uid, MagazineVisualsComponent component, ref AppearanceChangeEvent args)
  {
    // tl;dr
    // 1.If no mag then hide it OR
    // 2. If step 0 isn't visible then hide it (mag or unshaded)
    // 3. Otherwise just do mag / unshaded as is
    var sprite = IoCManager.Resolve<IEntityManager>().GetComponent<ISpriteComponent>(component.Owner);

    component.TryGetData(MagazineBarrelVisuals.CountLoaded, out _magLoaded);

    if (_magLoaded)
    {
        if (!component.TryGetData(AmmoVisuals.AmmoMax, out int capacity))
        {
            return;
        }
        if (!component.TryGetData(AmmoVisuals.AmmoCount, out int current))
        {
            return;
        }

        var step = ContentHelpers.RoundToLevels(current, capacity, _magSteps);

        if (step == 0 && !_zeroVisible)
        {
            if (sprite.LayerMapTryGet(MagazineVisualLayers.Count, out _))
            {
                sprite.LayerSetVisible(MagazineVisualLayers.Count, false);
            }

            if (sprite.LayerMapTryGet(MagazineVisualLayers.CountUnshaded, out _))
            {
                sprite.LayerSetVisible(MagazineVisualLayers.CountUnshaded, false);
            }

            return;
        }

        if (sprite.LayerMapTryGet(MagazineVisualLayers.Count, out _))
        {
            sprite.LayerSetVisible(MagazineVisualLayers.Count, true);
            sprite.LayerSetState(MagazineVisualLayers.Count, $"{_magState}-{step}");
        }

        if (sprite.LayerMapTryGet(MagazineVisualLayers.CountUnshaded, out _))
        {
            sprite.LayerSetVisible(MagazineVisualLayers.CountUnshaded, true);
            sprite.LayerSetState(MagazineVisualLayers.CountUnshaded, $"{_magState}-unshaded-{step}");
        }
    }
    else
    {
        if (sprite.LayerMapTryGet(MagazineVisualLayers.Count, out _))
        {
            sprite.LayerSetVisible(MagazineVisualLayers.Count, false);
        }

        if (sprite.LayerMapTryGet(MagazineVisualLayers.CountUnshaded, out _))
        {
            sprite.LayerSetVisible(MagazineVisualLayers.CountUnshaded, false);
        }
    }
  }
}
public enum MagazineVisualLayers
{
  Base,
  WitnessHoles,
  MagType
}
/// Visual label/marking that tells the user what ammo is prepacked in the mag
/// CEV-Eris uses:
/// Red: Lethal
/// Blue: Rubber
/// Orange: Practice/Blanks
/// Green: High Velocity
/// White: Flash
