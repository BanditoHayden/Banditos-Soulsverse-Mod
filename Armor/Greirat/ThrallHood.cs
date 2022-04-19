using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace SoulsMod.Items.Armor.Greirat
{
    [AutoloadEquip(EquipType.Head)]
    public class ThrallHood : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Hood used to cover the head of lesser folk who were set to work as slaves throughout Lothric.\nAlso occasionally used to shame and humiliate criminals.\n2% increased melee damage");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 3;

        }
        public override void SetDefaults()
        {
            Item.width = 18; // Width of the item
            Item.height = 18; // Height of the item
            Item.value = Item.sellPrice(gold: 1); // How many coins the item is worth
            Item.rare = ItemRarityID.Green; // The rarity of the item
            Item.defense = 2; // The amount of defense the item will give when equipped
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<DeserterArmor>() && legs.type == ModContent.ItemType<DeserterTrousers>();
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Increases movement speed by 10%"; // This is the setbonus tooltip
            player.moveSpeed += 0.1f;
        }
        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Generic) += 0.02f;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
           .AddIngredient(ItemID.Silk, 2)
           .AddIngredient(ItemID.Chain, 1)
           .AddTile(TileID.Anvils)
           .Register();
        }

    }
}
