using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace UniversalCraft
{
	public class UniversalCraft : Mod
	{
		public static UniversalCraft instance;
		public static List<StationInfo> moddedStations;

		private const string UNKNOWN_MESSAGE_KEY = "Mods.UniversalCraft.Misc.UnknownMessage";

		public UniversalCraft()
		{
		}

		public override void Load()
		{
			instance = ModContent.GetInstance<UniversalCraft>();
			moddedStations = new List<StationInfo>();
		}

		public override void Unload()
		{
			instance = null;
			moddedStations = null;
		}

		public override object Call(params object[] args)
		{
			try
			{
				CallType callType = (CallType)Convert.ToByte(args[0]);
				switch (callType)
				{
					case CallType.AddStation:
						AddStation(args);
						break;

					default:
						instance.Logger.Warn(Language.GetTextValue(UNKNOWN_MESSAGE_KEY, args[0]));
						break;
				}

				return base.Call(args);
			}
			catch (Exception e)
			{
				Logger.Error("Call Error: " + e.StackTrace + e.Message);

				return "Failure, see logs";
			}
		}

		private void AddStation(object[] args)
		{
			ushort type = Convert.ToUInt16(args[1]);
			Func<bool> condition = (Func<bool>)args[2];

			for (int i = 0; i < moddedStations.Count; i++)
			{
				StationInfo info = moddedStations[i];
				if (info.type == type)
				{
					info.condition = new Func<bool>(() => condition.Invoke() || info.condition.Invoke());
					return;
				}
			}

			moddedStations.Add(new StationInfo(type, condition));
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(instance);
			recipe.AddIngredient(ItemID.DirtBlock, 10);
			recipe.AddTile(TileID.DiamondGemspark);
			recipe.SetResult(ItemID.DiablolistBanner);
			recipe.AddRecipe();
		}

		public override void PostSetupContent()
		{
			//this.Call(0, TileID.DiamondGemspark, new Func<bool>(() => Main.dayTime));
		}
	}

	public enum CallType : byte
	{
		AddStation
	}

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