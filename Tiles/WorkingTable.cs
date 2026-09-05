using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace HUImb.Tiles
{
    public class WorkingTable : ModTile
    {
        public override void SetStaticDefaults()
        {
            // Properties
            
            Main.tileTable[Type] = false;
            Main.tileSolidTop[Type] = false;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;
            Main.tileFrameImportant[Type] = true;
            TileID.Sets.DisableSmartCursor[Type] = true;
            TileID.Sets.IgnoredByNpcStepUp[Type] = true; // This line makes NPCs not try to step up this tile during their movement. Only use this for furniture with solid tops.

            // Placement
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
            TileObjectData.newTile.CoordinateHeights = new[] { 18, 18, 18 };
            TileObjectData.addTile(Type);

            AddMapEntry(new Color(200, 200, 200), Language.GetText("Mods.HUImb.Items.WorkingTableItem.DisplayName"));
        }

        public override void NumDust(int x, int y, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }

        
    }
}