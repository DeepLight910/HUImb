using HUImb.Items;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using HUImb.Items.accessories;
using HUImb.Items.weapons;
using HUImb.Items.materials;
using HUImb.Items.Potions;
using HUImb.Items.Potions.Ultimate;
using HUImb.Items.Placeable;
using HUImb.Tiles;

namespace HUImb
{
	public class GlobalModSystem : ModSystem
	{
		public override void AddRecipes()
		{

            Recipe.Create(ItemID.Teleporter, 1)
                .AddRecipeGroup(RecipeGroupID.IronBar, 5)
                .AddIngredient(ItemID.Wire, 10)
                .AddIngredient(ItemID.RecallPotion, 4)
                .AddTile(TileID.HeavyWorkBench)
                .Register();

            Recipe.Create(ItemID.Wrench, 1)
                .AddRecipeGroup(RecipeGroupID.IronBar, 3)
                .AddIngredient(ItemID.Wire, 2)
                .AddTile(TileID.Anvils)
                .Register();
            
            Recipe.Create(ItemID.GreenWrench, 1)
                .AddRecipeGroup(RecipeGroupID.IronBar, 3)
                .AddIngredient(ItemID.Wire, 2)
                .AddTile(TileID.Anvils)
                .Register();

            Recipe.Create(ItemID.BlueWrench, 1)
                .AddRecipeGroup(RecipeGroupID.IronBar, 3)
                .AddIngredient(ItemID.Wire, 2)
                .AddTile(TileID.Anvils)
                .Register();

            Recipe.Create(ItemID.YellowWrench, 1)
                .AddRecipeGroup(RecipeGroupID.IronBar, 3)
                .AddIngredient(ItemID.Wire, 2)
                .AddTile(TileID.Anvils)
                .Register();

            Recipe.Create(ItemID.Wire, 100)
                .AddIngredient(ItemID.CopperBar,1)
                .AddTile(TileID.Anvils)
                .Register();

            Recipe.Create(ItemID.Wire, 100)
                .AddIngredient(ItemID.TinBar,1)
                .AddTile(TileID.Anvils)
                .Register();

            Recipe.Create(ItemID.WireCutter,1)
                .AddRecipeGroup(RecipeGroupID.IronBar, 3)
                .AddIngredient(ItemID.Wire, 2)
                .AddTile(TileID.Anvils)
                .Register();

            Recipe.Create(ItemID.MechanicalLens, 1)
                .AddIngredient(ItemID.Wire, 10)
                .AddIngredient(ItemID.Lens, 2)
                .AddTile(TileID.Anvils)
                .Register();

            Recipe.Create(ItemID.LaserRuler, 1)
                .AddRecipeGroup(RecipeGroupID.Wood, 3)
                .AddRecipeGroup(RecipeGroupID.IronBar, 3)
                .AddIngredient(ItemID.Wire, 10)
                .AddTile(TileID.Anvils)
                .Register();

            Recipe.Create(ItemID.TinkerersWorkshop, 1)
                .AddRecipeGroup(RecipeGroupID.Wood, 10)
                .AddIngredient(ItemID.Book, 4)
                .AddIngredient(ItemID.Silk, 4)
                .AddTile(TileID.Sawmill)
                .Register();

            Recipe.Create(ModContent.ItemType<Cellulose>(), 5)
                .AddRecipeGroup("Wood", 2)
                .AddCondition(condition: Condition.NearWater)
                .AddTile(ModContent.TileType<WorkingTable>())
                .Register();

            Recipe.Create(ModContent.ItemType<Clair>())
                .AddIngredient(ItemID.BottledWater)
                .AddIngredient(ModContent.ItemType<Egg>(), 2)
                .AddIngredient(ItemID.Hay)
                .AddTile(TileID.CookingPots)
                .Register();

            Recipe.Create(ItemID.FriedEgg)
                .AddIngredient(ModContent.ItemType<Egg>(), 2)
                .AddTile(TileID.CookingPots)
                .Register();

            Recipe.Create(ModContent.ItemType<SaitamaCloak>())
                .AddIngredient(ItemID.Silk, 15)
                .AddTile(TileID.Loom)
                .Register();

            Recipe.Create(ModContent.ItemType<Paper>())
                .AddIngredient(ModContent.ItemType<Cellulose>(), 3)
                .AddTile(TileID.WorkBenches)
                .Register();

            Recipe.Create(ModContent.ItemType<WorkingTableItem>())
                .AddRecipeGroup("IronBar", 15)
                .AddIngredient(ItemID.WoodenHammer)
                .AddIngredient(ItemID.WireCutter)
                .AddRecipeGroup("Wood", 10)
                .AddTile(TileID.WorkBenches)
                .Register();

            Recipe.Create(ModContent.ItemType<SmokingFlowerItem>())
                .AddIngredient(ItemID.Seed, 5)
                .AddIngredient(ModContent.ItemType<Cigarets>())
                .AddRecipeGroup("Wood", 10)
                .AddTile(ModContent.TileType<WorkingTable>())
                .Register();

            Recipe.Create(ModContent.ItemType<Paper>(), 5)
                .AddIngredient(ItemID.Book)
                .Register();

            Recipe.Create(ItemID.Book)
                .AddIngredient(ModContent.ItemType<Paper>(), 7)
                .AddIngredient(ItemID.Silk, 2)
                .AddTile(TileID.WorkBenches)
                .Register();

            Recipe.Create(ItemID.FishermansGuide)
                .AddIngredient(ModContent.ItemType<Paper>(), 12)
                .AddIngredient(ItemID.Silk, 2)
                .AddIngredient(ItemID.Bass, 15)
                .AddTile(TileID.TinkerersWorkbench)
                .Register();

            Recipe.Create(ItemID.Stopwatch)
                .AddRecipeGroup("IronBar", 5)
                .AddIngredient(ItemID.Glass, 5)
                .AddIngredient(ItemID.Chain, 2)
                .AddTile(TileID.TinkerersWorkbench)
                .Register();

            Recipe.Create(ItemID.DPSMeter)
                .AddIngredient(ItemID.BluePaint, 3)
                .AddIngredient(ItemID.Chain, 15)
                .AddIngredient(ItemID.Wire, 5)
                .AddIngredient (ItemID.Ruby)
                .AddTile(TileID.TinkerersWorkbench)
                .Register();

            Recipe.Create(ItemID.LifeformAnalyzer)
                .AddRecipeGroup("IronBar", 5)
                .AddIngredient(ItemID.Wire, 20)
                .AddIngredient(ItemID.Radar)
                .AddTile(TileID.TinkerersWorkbench)
                .Register();

            Recipe.Create(ItemID.TallyCounter)
                .AddRecipeGroup("IronBar", 5)
                .AddIngredient(ItemID.Wire, 3)
                .AddIngredient(ItemID.GoldCoin, 15)
                .AddIngredient(ModContent.ItemType<Paper>(), 5)
                .AddTile(TileID.TinkerersWorkbench)
                .Register();

            Recipe.Create(ItemID.WeatherRadio)
                .AddRecipeGroup("IronBar", 5)
                .AddIngredient(ItemID.DontStarveShaderItem)
                .AddIngredient(ItemID.Compass)
                .AddTile(TileID.TinkerersWorkbench)
                .Register();

            Recipe.Create(ItemID.Compass)
                .AddIngredient(ItemID.WaterBucket, 5)
                .AddRecipeGroup("IronBar", 5)
                .AddRecipeGroup("Wood", 5)
			    .AddIngredient(ItemID.MeteoriteBar, 3)
                .AddTile(TileID.TinkerersWorkbench)
                .Register();

            Recipe.Create(ItemID.DepthMeter)
                .AddRecipeGroup("IronBar", 10)
                .AddIngredient(ItemID.Wire, 10)
                .AddTile(TileID.TinkerersWorkbench)
                .Register();

            Recipe.Create(ModContent.ItemType<MramorSteak>())
                .AddIngredient(ItemID.Marble, 25)
                .AddTile(TileID.CookingPots)
                .Register();

            Recipe.Create(ItemID.BoneWelder)
                .AddIngredient(ItemID.Bone, 30)
                .AddIngredient(ItemID.WorkBench)
                .AddTile(TileID.Anvils)
                .Register();

            Recipe.Create(ItemID.BottomlessBucket)
			    .AddIngredient(ItemID.WaterBucket, 10)
			    .AddIngredient(ItemID.LunarBar, 10)
			    .AddTile(TileID.Anvils)
			    .Register();
			
			Recipe.Create(ItemID.BottomlessLavaBucket)
			    .AddIngredient(ItemID.LavaBucket, 10)
			    .AddIngredient(ItemID.LunarBar, 10)
			    .AddTile(TileID.Anvils)
			    .Register();
			
			Recipe.Create(ItemID.BottomlessHoneyBucket)
			    .AddIngredient(ItemID.HoneyBucket, 10)
			    .AddIngredient(ItemID.LunarBar, 10)
			    .AddTile(TileID.Anvils)
			    .Register();
			
			Recipe.Create(ItemID.MetalDetector)
			    .AddRecipeGroup("IronBar", 5)
			    .AddRecipeGroup("Wood", 1)
                .AddIngredient(ItemID.GoldOre, 5)
			    .AddIngredient(ItemID.Wire, 5)
                .AddTile(TileID.TinkerersWorkbench)
                .Register();

            Recipe.Create(ItemID.MetalDetector)
                .AddRecipeGroup("IronBar", 5)
                .AddRecipeGroup("Wood", 1)
                .AddIngredient(ItemID.PlatinumOre, 5)
                .AddIngredient(ItemID.Wire, 5)
                .AddTile(TileID.TinkerersWorkbench)
                .Register();

            Recipe.Create(ModContent.ItemType<OldNail>())
                .AddIngredient(ItemID.Starfury)
                .AddIngredient(ItemID.DemoniteBar, 15)
                .AddTile(TileID.Anvils)
                .Register();

            Recipe.Create(ModContent.ItemType<OldNail>())
                .AddIngredient(ItemID.Starfury)
                .AddIngredient(ItemID.CrimtaneBar, 15)
                .AddTile(TileID.Anvils)
                .Register();

            Recipe.Create(ModContent.ItemType<SharpenedNail>())
                .AddIngredient(ModContent.ItemType<OldNail>())
                .AddIngredient(ItemID.HellstoneBar, 15)
                .AddTile(TileID.Anvils)
                .Register();

            Recipe.Create(ModContent.ItemType<ChanalledNail>())
                .AddIngredient(ModContent.ItemType<SharpenedNail>())
                .AddIngredient(ItemID.MythrilBar, 10)
                .AddTile(TileID.MythrilAnvil)
                .Register();

            Recipe.Create(ModContent.ItemType<ChanalledNail>())
                .AddIngredient(ModContent.ItemType<SharpenedNail>())
                .AddIngredient(ItemID.OrichalcumBar, 10)
                .AddTile(TileID.MythrilAnvil)
                .Register();

            Recipe.Create(ModContent.ItemType<CoiledNail>())
                .AddIngredient(ModContent.ItemType<ChanalledNail>())
                .AddIngredient(ItemID.HallowedBar, 10)
                .AddTile(TileID.MythrilAnvil)
                .Register();

            Recipe.Create(ModContent.ItemType<PureNail>())
                .AddIngredient(ModContent.ItemType<CoiledNail>())
                .AddIngredient(ItemID.ShroomiteBar, 10)
                .AddTile(TileID.MythrilAnvil)
                .Register();

            Recipe.Create(ItemID.Extractinator)
                .AddRecipeGroup("IronBar", 6)
                .AddRecipeGroup("Wood", 15)
                .AddIngredient(ItemID.MudBlock, 15)
                .AddTile(TileID.Anvils)
                .Register();

            Recipe.Create(ItemID.SliceOfCake)
                .AddIngredient(ItemID.MilkCarton, 3)
                .AddIngredient(ItemID.Hay, 5)
                .AddIngredient(ModContent.ItemType<Egg>(), 5)
                .AddTile(TileID.Anvils)
                .Register();

            Recipe.Create(ModContent.ItemType<Cigarets>())
                .AddIngredient(ModContent.ItemType<Paper>(), 10)
                .AddIngredient(ItemID.Mushroom, 10)
                .AddIngredient(ItemID.GlowingMushroom, 10)
                .AddTile(ModContent.TileType<WorkingTable>())
                .Register();

            Recipe.Create(ModContent.ItemType<CheeseClair>())
                .AddIngredient(ModContent.ItemType<Clair>(), 3)
                .AddIngredient(ItemID.MilkCarton, 5)
                .AddTile(TileID.CookingPots)
                .Register();

            Recipe.Create(ModContent.ItemType<SurvivalTest>())
                .AddIngredient(ModContent.ItemType<Vengera>(), 3)
                .AddIngredient(ModContent.ItemType<StrangeNote>())
                .AddTile(TileID.TinkerersWorkbench)
                .Register();

            Recipe.Create(ModContent.ItemType<SyringeGun>())
                .AddIngredient(ItemID.LesserHealingPotion, 30)
                .AddIngredient(ItemID.HealingPotion, 5)
                .AddIngredient(ItemID.HellstoneBar, 15)
                .AddTile(TileID.Anvils)
                .Register();

            Recipe.Create(ModContent.ItemType<ArcanumBlade>())
                .AddIngredient(ModContent.ItemType<CrystalMana>(), 100)
                .AddRecipeGroup("IronBar", 13)
                .AddTile(TileID.Anvils)
                .Register();

            Recipe.Create(ModContent.ItemType<DistantStrike>())
                .AddRecipeGroup("IronBar", 13)
                .AddIngredient(ItemID.IllegalGunParts, 5)
                .AddIngredient(ItemID.HallowedBar, 20)
                .AddIngredient(ItemID.Bomb, 33)
                .AddTile(TileID.MythrilAnvil)
                .Register();

            Recipe.Create(ModContent.ItemType<ManaCrystalizer>())
                .AddIngredient(ItemID.ManaCrystal, 1)
                .AddRecipeGroup("IronBar", 3)
                .AddIngredient(ItemID.Meteorite, 15)
                .AddTile(TileID.Anvils)
                .Register();

            Recipe.Create(ModContent.ItemType<UltimateInfinityPotion>(), 1)
                .AddIngredient(ItemID.Daybloom, 100)
                .AddIngredient(ItemID.Moonglow, 100)
                .AddIngredient(ItemID.Blinkroot, 100)
                .AddIngredient(ItemID.Waterleaf, 100)
                .AddIngredient(ItemID.Fireblossom, 100)
                .AddIngredient(ItemID.BottledWater, 15)
                .AddTile(TileID.MythrilAnvil)
                .Register();

            Recipe.Create(ModContent.ItemType<BowTie>())
                .AddIngredient(ItemID.WoodenBow, 1)
                .AddRecipeGroup("IronBar", 5)
                .AddIngredient(ItemID.Silk, 10)
                .AddRecipeGroup(RecipeGroupID.Butterflies, 3)
                .AddTile(TileID.Anvils)
                .Register();


            if (ModLoader.TryGetMod("CalamityMod", out Mod Calamity))
			{
				Recipe.Create(ModContent.ItemType<UltimateInfinityPotion>(), 1)
				    .AddIngredient(Calamity.Find<ModItem>("BloodOrb").Type, 100)
				    .AddIngredient(ItemID.BottledWater, 3)
				    .AddTile(TileID.AlchemyTable)
				    .Register();

				Recipe.Create(ModContent.ItemType < KombatMadnessPotion>(), 1)
				    .AddIngredient(Calamity.Find<ModItem>("BloodOrb").Type, 10)
                    .AddIngredient(ItemID.BottledWater, 1)
                    .AddTile(ModContent.TileType<WorkingTable>())
                    .Register();

                Recipe.Create(ModContent.ItemType<MoonWand>(), 1)
                    .AddIngredient(ItemID.FallenStar, 50)
                    .AddIngredient(ItemID.FragmentNebula, 60)
                    .AddIngredient(Calamity.Find<ModItem>("RuinousSoul").Type, 20)
                    .AddIngredient(ItemID.Sapphire, 10)
                    .AddTile(TileID.LunarCraftingStation)
                    .Register();

				Recipe.Create(ItemID.Extractinator)
				    .AddRecipeGroup("IronBar", 6)
				    .AddRecipeGroup("Wood", 15)
				    .AddIngredient(ItemID.MudBlock, 15)
				    .AddTile(TileID.Anvils)
				    .Register();

				Recipe.Create(ModContent.ItemType<ZodiacSickle>())
					.AddIngredient(ModContent.ItemType<ZodiacHeart>())
					.AddIngredient(ItemID.DeathSickle)
					.AddIngredient(ModContent.ItemType<Vengera>(), 5)
					.AddIngredient(Calamity.Find<ModItem>("AureusCell"), 10)
					.AddTile(TileID.MythrilAnvil)
					.Register();

				Recipe.Create(ModContent.ItemType<GraveThrower>())
				    .AddIngredient(ItemID.LunarBar, 120)
				    .AddIngredient(ItemID.Tombstone, 25)
				    .AddIngredient(ItemID.CandyCornRifle, 1)
				    .AddIngredient(ItemID.IllegalGunParts, 3)
				    .AddCondition(Condition.InGraveyard)
				    .AddTile(TileID.LunarCraftingStation)
				    .Register();

				Recipe.Create(ModContent.ItemType<QuestItemMef>())
					.AddIngredient(ItemID.CrystalShard, 50)
					.AddIngredient(ItemID.PixieDust, 25)
					.AddIngredient(ItemID.GoldDust, 99)
					.AddIngredient(ItemID.GlowingMushroom, 99)
					.AddCondition(Condition.InGlowshroom)
					.AddTile(ModContent.TileType<WorkingTable>())
					.Register();

                Recipe.Create(ModContent.ItemType<SunSword>())
                    .AddIngredient(Calamity.Find<ModItem>("LivingShard"), 10)
                    .AddIngredient(ModContent.ItemType<ZodiacStar>(), 3)
                    .AddIngredient(ItemID.PixieDust, 25)
                    .AddIngredient(ItemID.Seedler)
                    .AddTile(TileID.MythrilAnvil)
                    .Register();

                Recipe.Create(ModContent.ItemType<SaturnRing>())
                    .AddIngredient(Calamity.Find<ModItem>("UnholyEssence"), 10)
                    .AddIngredient(ModContent.ItemType<ZodiacStar>(), 5)
                    .AddIngredient(ItemID.MagicMissile)
                    .AddTile(TileID.LunarCraftingStation)
                    .Register();


            }
            else
			{

				Recipe.Create(ModContent.ItemType<KombatMadnessPotion>(), 1)
				    .AddIngredient(ItemID.Daybloom, 1)
				    .AddIngredient(ItemID.Fireblossom, 2)
				    .AddIngredient(ItemID.BottledWater, 1)
                    .AddTile(TileID.AlchemyTable)
                    .Register();

				Recipe.Create(ModContent.ItemType<MoonWand>(), 1)
				    .AddIngredient(ItemID.FallenStar, 25)
				    .AddIngredient(ItemID.FragmentNebula, 15)
				    .AddIngredient(ItemID.LunarBar, 40)
				    .AddIngredient(ItemID.Sapphire, 12)
				    .AddTile(TileID.LunarCraftingStation)
				    .Register();
				
            }
		}
	}
}