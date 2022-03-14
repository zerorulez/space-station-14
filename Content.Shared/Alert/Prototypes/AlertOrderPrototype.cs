using System;
using System.Collections.Generic;
using System.Security;
using Robust.Shared.Prototypes;
using Robust.Shared.Serialization;
using Robust.Shared.Serialization.Manager.Attributes;
using Robust.Shared.Serialization.TypeSerializers.Implementations;
using Robust.Shared.Serialization.TypeSerializers.Implementations.Custom.Prototype;
using Robust.Shared.Serialization.TypeSerializers.Implementations.Generic;
using Robust.Shared.Utility;
using Robust.Shared.ViewVariables;

namespace Content.Shared.Alert
{
    /// <summary>
    /// Defines the order of alerts so they show up in a consistent order.
    /// </summary>
    [Prototype("alertOrder")]
    [DataDefinition]
    public sealed class AlertOrderPrototype : IPrototype, IComparer<AlertPrototype>
    {
        [ViewVariables]
        [DataField("id", required: true)]
        public string ID { get; } = default!;

        [DataField("order", customTypeSerializer: typeof(AlertOrderSerializer))]
        private readonly SortedDictionary<(string?, string?),int> _order = new();

        private int GetOrderIndex(AlertPrototype alert)
        {
            if (_order.TryGetValue((alert.Category.ToString(), null), out var idx))
            {
                return idx;
            }

            if (_order.TryGetValue((null, alert.AlertType.ToString()), out idx))
            {
                return idx;
            }

            return -1;
        }

        public int Compare(AlertPrototype? x, AlertPrototype? y)
        {
            if ((x == null) && (y == null)) return 0;
            if (x == null) return 1;
            if (y == null) return -1;
            var idx = GetOrderIndex(x);
            var idy = GetOrderIndex(y);
            if (idx == -1 && idy == -1)
            {
                // break ties by type value
                return x.AlertType - y.AlertType;
            }

            if (idx == -1) return 1;
            if (idy == -1) return -1;
            var result = idx - idy;
            // not strictly necessary (we don't care about ones that go at the same index)
            // but it makes the sort stable
            if (result == 0)
            {
                // break ties by type value
                return x.AlertType - y.AlertType;
            }

            return result;
        }
    }
}
