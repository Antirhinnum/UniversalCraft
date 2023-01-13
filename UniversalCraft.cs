using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using UniversalCraft.Common.Systems;

namespace UniversalCraft;

public sealed class UniversalCraft : Mod
{
	public override object Call(params object[] args)
	{
		return CallSystem.Call(args);
	}

	internal enum PacketType
	{
		SendNewTilesToServer
	}

	public override void HandlePacket(BinaryReader reader, int whoAmI)
	{
		PacketType type = (PacketType)reader.ReadByte();
		switch (type)
		{
			case PacketType.SendNewTilesToServer:
				int count = reader.Read7BitEncodedInt();
				for (int i = 0; i < count; i++)
				{
					UnlockedStationsSystem.AddTile(reader.Read7BitEncodedInt(), quiet: true);
				}
				NetMessage.SendData(MessageID.WorldData);
				break;

			default:
				break;
		}
	}
}