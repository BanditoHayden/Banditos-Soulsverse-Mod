using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace SoulsMod.Items.Armor.Greirat
{
    [AutoloadEquip(EquipType.Legs)]
    public class DeserterTrousers : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Common soldier's trousers.\nThis musty, rusted hunk of metal befits one reduced to thievery.\n2% increased melee damage");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 3;

        }
        public override void SetDefaults()
        {
            Item.width = 18; // Width of the item
            Item.height = 18; // Height of the item
            Item.value = Item.sellPrice(gold: 1); // How many coins the item is worth
            Item.rare = ItemRarityID.Green; // The rarity of the item
            Item.defense = 4; // The amount of defense the item will give when equipped
        }
        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Generic) += 0.02f;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
           .AddIngredient(ItemID.Silk, 4)
           .AddIngredient(ItemID.Chain, 3)
           .AddTile(TileID.Anvils)
           .Register();
        }


    }
}
