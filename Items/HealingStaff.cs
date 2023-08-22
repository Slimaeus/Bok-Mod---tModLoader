using BokMod.ProjectTiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace BokMod.Items;

public class HealingStaff : ModItem
{
    public override void SetDefaults()
    {
        Item.damage = 10;
        Item.DamageType = DamageClass.Magic;
        Item.mana = 0;
        Item.width = 40;
        Item.height = 40;
        Item.useTime = 7;
        Item.useAnimation = 7;
        Item.useStyle = ItemUseStyleID.Shoot;
        Item.knockBack = 10;
        Item.value = 100;
        Item.rare = ItemRarityID.Blue;
        Item.UseSound = SoundID.Item8;
        Item.autoReuse = true;
        Item.shoot = ModContent.ProjectileType<HealingBallProjectTile>();
        Item.shootSpeed = 100;
        Item.ArmorPenetration = 10;
        Item.lifeRegen = 10;
        Item.noMelee = true;
        Item.Hitbox = new Rectangle(0, 0, 20, 20);
        Item.buyPrice(0, 0, 0, 10);
    }
    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        player.Heal(Item.damage);
        return base.Shoot(player, source, position, velocity, type, damage, knockback);
    }
    public override void AddRecipes()
    {
        Recipe recipe = CreateRecipe();
        recipe.AddIngredient(ItemID.Wood, 1);
        recipe.Register();
    }
    public override bool? CanHitNPC(Player player, NPC target)
    {
        return true;
    }
    public override bool CanHitPvp(Player player, Player target)
    {
        return true;
    }
    public override void OnHitPvp(Player player, Player target, Player.HurtInfo hurtInfo)
    {
        target.Heal(Item.damage);
        base.OnHitPvp(player, target, hurtInfo);
    }
    public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
    {
        base.OnHitNPC(player, target, hit, damageDone);
    }
}
