using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace BokMod.Accessories;

[AutoloadEquip(EquipType.Shoes)]
public class GodSpeedBoot : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }
    public override void SetDefaults()
    {
        Item.width = 20;
        Item.height = 20;
        Item.value = 10000;
        Item.rare = ItemRarityID.Purple;
        Item.accessory = true;
    }
    public override bool CanEquipAccessory(Player player, int slot, bool modded)
    {
        return true;
    }

    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        player.moveSpeed *= 2;
        player.accRunSpeed *= 2;
        player.eyeColor = Color.Blue;
        player.noFallDmg = true;
    }
    public override void AddRecipes()
    {
        Recipe recipe = CreateRecipe();
        recipe.AddIngredient(ItemID.Wood, 1);
        recipe.Register();
    }
}
