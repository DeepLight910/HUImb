using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.Localization;

namespace HUImb.Tiles
{
    public class SmokingFlower : ModTile
    {
        public override void SetStaticDefaults()
        {
            // Properties
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileID.Sets.Clock[Type] = true;

            // Placement
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
            TileObjectData.newTile.Height = 5;
            TileObjectData.newTile.CoordinateHeights = new[] { 16, 16, 16, 16, 16 };
            TileObjectData.addTile(Type);

            // Etc
            AddMapEntry(new Color(200, 200, 200), Language.GetText("Mods.HUImb.Items.SmokingFlowerItem.DisplayName")); // We don't need to call SetDefault() on CreateMapEntryName()'s return value if we have .lang files.
        }

        public override bool RightClick(int x, int y)
        {
            
            Main.NewText(Language.GetTextValue("Mods.HUImb.Items.SmokingFlowerItem.Chat.RMBuse"));
            Main.NewText(Language.GetTextValue("Mods.HUImb.Items.SmokingFlowerItem.Chat.RMBuse2"));
            return true;
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }
    }
}