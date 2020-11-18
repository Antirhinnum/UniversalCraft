using System;
using Terraria.ModLoader;

namespace UniversalCraft
{
	public class UniversalCraft : Mod
	{
		public static UniversalCraft instance;

		public UniversalCraft()
		{
		}

		public override void Load()
		{
			instance = ModContent.GetInstance<UniversalCraft>();
		}

		public override void Unload()
		{
			instance = null;
		}

		public override object Call(params object[] args)
		{
			CallType callType = (CallType)Convert.ToByte(args[0]);
			switch (callType)
			{
				case CallType.AddTile:
					break;
				default:
					break;
			}
			return base.Call(args);
		}
	}

	public enum CallType : byte
	{
		AddTile
	}
}