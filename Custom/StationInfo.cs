using System;

namespace UniversalCraft.Custom;

public readonly struct StationInfo
{
    public readonly ushort type;
    public readonly Func<bool> condition;

    public StationInfo(ushort type, Func<bool> condition = null)
    {
        this.type = type;
        this.condition = condition;
    }
}