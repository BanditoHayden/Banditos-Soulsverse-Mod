﻿using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SoulsMod.Items.Armor.Faraam
{
    // The AutoloadEquip attribute automatically attaches an equip texture to this item.
    // Providing the EquipType.Body value here will result in TML expecting X_Arms.png, X_Body.png and X_FemaleBody.png sprite-sheet files to be placed next to the item's main texture.
    [AutoloadEquip(EquipType.Head)]
    public class FaraamHelm : ModItem
    {
        public override void SetStaticDefaults()
        {

            DisplayName.SetDefault("Faraam Helm");
            Tooltip.SetDefault("This is a modded body armor.");


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


        // Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.

    }
}