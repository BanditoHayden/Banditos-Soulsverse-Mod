using Terraria.GameContent.Creative;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace SoulsMod.Projectiles.WeaponArts
{
    public class Halo : ModProjectile
    {
        public bool stopped = false;
        public override void SetDefaults()
        {
            Projectile.width = 40;
            Projectile.height = 40;
            Projectile.aiStyle = -1;
            Projectile.hostile = false;
            Projectile.friendly = true;
            Projectile.penetrate = 100;
            Projectile.timeLeft = 200;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.tileCollide = false;
            
        }
        public override void AI()
        {
            Projectile.ai[0] += 1f;
            if (Projectile.ai[0] >= 1f)
            {
                Projectile.velocity *= 1.01f;
            }
            if (Projectile.ai[0] >= 30f)
            {
                Projectile.velocity *= 0.96f;
            }
            if (Projectile.ai[0] >= 60f)
            {
                Projectile.velocity *= 1.10f;
            }
        }
    }
}
