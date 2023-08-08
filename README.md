# Universal Crafter

![Universal Crafter mod icon](icon.png)

**Universal Crafter** is a tModLoader mod that adds an all-in-one crafting station.

[Download the mod on Steam!](https://steamcommunity.com/sharedfiles/filedetails/?id=2917548365)

## Mod Calls

| Call | Description | Example
| --- | --- | --- |
| `"AddStation", ushort tileId : void` | Registers a tile type to the Universal Crafter. Must be called before `AddRecipes()` is called. | `mod.Call("AddStation", ModContent.TileType<T>());` | 
| `"AddStation", ushort tileId, Func<bool> condition : void` | Registers a tile type to the Universal Crafter. The tile will only be accessible if the passed condition returns `true`. Must be called before `AddRecipes()` is called. | `mod.Call("AddStation", ModContent.TileType<T>(), () => NPC.downedBoss1);` | 
| `"CheckStation", int tileId : bool` | Determines if the Universal Crafter currently functions as the given tile ID. |`if (mod.Call("CheckStation", TileID.Extractinator)) { /* ... */ }` |