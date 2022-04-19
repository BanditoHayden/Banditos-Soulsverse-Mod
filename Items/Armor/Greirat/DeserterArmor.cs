﻿using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SoulsMod.Items.Armor.Greirat
{
    // The AutoloadEquip attribute automatically attaches an equip texture to this item.
    // Providing the EquipType.Body value here will result in TML expecting X_Arms.png, X_Body.png and X_FemaleBody.png sprite-sheet files to be placed next to the item's main texture.
    [AutoloadEquip(EquipType.Body)]
    public class DeserterArmor : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Common soldier's armor.\nIts insignia is worn beyond recognition. This musty, rusted hunk of metal befits one reduced to thievery\n2% increased melee damage");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        
        public override void SetDefaults()
        {
            Item.width = 18; // Width of the item
            Item.height = 18; // Height of the item
            Item.value = Item.sellPrice(gold: 1); // How many coins the item is worth
            Item.rare = ItemRarityID.Green; // The rarity of the item
            Item.defense = 6; // The amount of defense the item will give when equipped
        }
        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Generic) += 0.02f;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
           .AddIngredient(ItemID.Silk, 12)
           .AddIngredient(ItemID.Chain, 5)
           .AddTile(TileID.Anvils)
           .Register();
        }
        // Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.

    }
}