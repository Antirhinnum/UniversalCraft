using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using ReLogic.Content;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Drawing;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniversalCraft.Common.GlobalTiles;

/// <summary>
/// Handles tile glowmasks.<br />
/// Uses an IL edit so vanilla's code can be used.
/// </summary>
[Autoload(Side = ModSide.Client)]
public class GlowMaskTile : GlobalTile
{
	/// <summary>
	/// A set of all the glow masks for any tile that uses them.
	/// </summary>
	private static Dictionary<int, Asset<Texture2D>> GlowAssets { get; set; }

	private static HashSet<int> UseGlowTexture { get; set; }

	/// <remarks>
	/// Vanilla only ever checks that <see cref="Main.tileGlowMask"/>[] != -1, so any other negative value allows drawing to continue into the glow mask code.<br />
	/// Vanilla also uses -2 for <see cref="TileID.Crystals"/> and handles special logic based on the tile ID.
	/// </remarks>
	private const int _specialHandlingGlowMask = -2;

	public override void Load()
	{
		GlowAssets = new();
		UseGlowTexture = new();
		IL_TileDrawing.DrawSingleTile += HandleModdedGlowMasks_Patch;
	}

	public override void Unload()
	{
		foreach (int key in GlowAssets?.Keys)
		{
			GlowAssets[key] = null;
		}

		GlowAssets = null;
		UseGlowTexture = null;
		IL_TileDrawing.DrawSingleTile -= HandleModdedGlowMasks_Patch;
	}

	public override void SetStaticDefaults()
	{
		foreach (ModTile modTile in Mod.GetContent<ModTile>())
		{
			if (ModContent.RequestIfExists(modTile.Texture + "_Glow", out Asset<Texture2D> glowAsset))
			{
				GlowAssets[modTile.Type] = glowAsset;
				Main.tileGlowMask[modTile.Type] = _specialHandlingGlowMask;
			}
		}
	}

	private void HandleModdedGlowMasks_Patch(ILContext il)
	{
		ILCursor c = new(il);

		// First parameter and what we need to change.
		// This shouldn't ever change.
		const int DrawDataArgID = 1;

		// Move closer to the target point.
		// Match:
		//        double num9 = Main.timeForVisualEffects * 0.08;
		if (!c.TryGotoNext(MoveType.After,
				i => i.MatchLdsfld<Main>(nameof(Main.timeForVisualEffects))
			))
		{
			throw new Exception($"Patch failed: {nameof(HandleModdedGlowMasks_Patch)}");
		}

		// Get the local ID for the 'color2' variable.
		// Match:
		//		Color color2 = Color.White;
		int colorLocalID = -1;
		if (!c.TryGotoNext(MoveType.After,
				i => i.MatchCall<Color>("get_" + nameof(Color.White)),
				i => i.MatchStloc(out colorLocalID)
			))
		{
			throw new Exception($"Patch failed: {nameof(HandleModdedGlowMasks_Patch)}");
		}

		// Hijack the glow mask and color right after the color is defined.
		c.Emit(OpCodes.Ldarg, DrawDataArgID);
		c.Emit(OpCodes.Ldloca, colorLocalID);
		c.EmitDelegate(HandleModdedGlowMasks);
	}

	private static void HandleModdedGlowMasks(TileDrawInfo drawData, ref Color glowColor)
	{
		if (!GlowAssets.ContainsKey(drawData.typeCache))
		{
			return;
		}

		// For some reason, drawTexture is used instead of glowTexture and a local Color is used instead of glowColor.
		drawData.drawTexture = GlowAssets[drawData.typeCache].Value;
		glowColor = Color.White;
	}

	/// <summary>
	/// Change the given tile type to use the glowTexture field when drawing.<br />
	/// This method is less capable than the normal one, but accounts for sprite effects.<br />
	/// This never be set for solid tiles.
	/// </summary>
	public static void SetToUseGlowTexture(int type)
	{
		if (Main.dedServ)
			return;

		Main.tileGlowMask[type] = -1;
		UseGlowTexture.Add(type);
	}

	public override void DrawEffects(int i, int j, int type, SpriteBatch spriteBatch, ref TileDrawInfo drawData)
	{
		if (!UseGlowTexture.Contains(type) || !GlowAssets.TryGetValue(type, out Asset<Texture2D> glowAsset))
		{
			return;
		}

		drawData.glowTexture = glowAsset.Value;
		drawData.glowColor = Color.White;
		drawData.glowSourceRect = new(drawData.tileFrameX, drawData.tileFrameY, drawData.tileWidth, drawData.tileHeight);
	}
}