using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace BokMod.ProjectTiles;

public class HealingBallProjectTile : ModProjectile
{
    public override void SetDefaults()
    {
        Projectile.DamageType = DamageClass.Magic;
        Projectile.width = 20;
        Projectile.height = 20;
        Projectile.Hitbox = new Rectangle(0, 0, 20, 20);
        Projectile.friendly = true;
        Projectile.aiStyle = 0;
        Projectile.hostile = false;
        Projectile.penetrate = 10;
        Projectile.timeLeft = 600;
        Projectile.light = 0;
        Projectile.ignoreWater = true;
        Projectile.tileCollide = true;
    }
}
