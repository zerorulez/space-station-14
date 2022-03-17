using System.Collections.Generic;
using Robust.Shared.GameObjects;
using Robust.Shared.Serialization.Manager.Attributes;

namespace Content.Client.Weapons.Ranged.Components;

[RegisterComponent]
public sealed class MagazineVisualsComponent : Component
{
    [DataField("base")]
    public string Base = "base"; // empty mag png that everything else builds off of. defaults to base.png

    [DataField("witnessHoles")] // magState but renamed to actual name of the holes
    public Dictionary<int,string> WitnessHoles = default!;

    [DataField("witnessHolesCount")] // magSteps but named properly
    private int _witnessHolesCount;
}
