using System;

namespace UniversalCraft.DataStructures
{
	public struct StationInfo
	{
		public ushort type;
		public Func<bool> condition;

		public StationInfo(ushort type, Func<bool> condition)
		{
			this.type = type;
			this.condition = condition;
		}
	}
}