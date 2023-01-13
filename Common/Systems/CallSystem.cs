using System;
using Terraria.ModLoader;

namespace UniversalCraft.Common.Systems;

internal sealed class CallSystem : ModSystem
{
	private static bool _noCalls;

	public enum CallType
	{
		AddStation = 0,
		CheckStation = 1
	}

	public override void Load()
	{
		_noCalls = false;
	}

	public override void AddRecipes()
	{
		_noCalls = true;
	}

	public static object Call(params object[] args)
	{
		try
		{
			CallType callType = ParseCall(args[0]);
			switch (callType)
			{
				case CallType.AddStation:
					if (_noCalls)
					{
						throw new Exception("Cannot call AddStation after recipes are added -- use PostSetupContent instead.");
					}
					if (args.Length > 2)
					{
						AddStation(Convert.ToUInt16(args[1]), (Func<bool>)args[2]);
						break;
					}
					AddStation(Convert.ToUInt16(args[1]));
					break;

				case CallType.CheckStation:
					return UnlockedStationsSystem.UnlockedStations.Contains(Convert.ToInt32(args[1]));

				default:
					ModContent.GetInstance<UniversalCraft>().Logger.Warn($"Unknown call message of type \"{args[0]}\"");
					break;
			}

			return null;
		}
		catch (Exception e)
		{
			ModContent.GetInstance<UniversalCraft>().Logger.Error("Call Error: " + e.StackTrace + e.Message);
			return null;
		}
	}

	private static CallType ParseCall(object o)
	{
		if (o is int numeric)
		{
			string name = Enum.GetName(typeof(CallType), numeric);
			if (Enum.TryParse(name, out CallType result))
			{
				return result;
			}
			else
			{
				throw new Exception("Unknown call type numeric value");
			}
		}
		else if (o is string name && Enum.TryParse(name, out CallType result))
		{
			return result;
		}
		else
		{
			throw new Exception("Unknown call type format");
		}
	}

	private static void AddStation(ushort type, Func<bool> condition = null)
	{
		UnlockedStationsSystem.StationInfos.Add(new Custom.StationInfo(type, condition));
	}
}