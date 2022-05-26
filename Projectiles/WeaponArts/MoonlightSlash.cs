﻿using Terraria.GameContent.Creative;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;

namespace SoulsMod.Projectiles.WeaponArts
{
    public class MoonlightSlash : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 6;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
        }
        public override void SetDefaults()
        {
            Projectile.width = 70;
            Projectile.height = 70;
            Projectile.aiStyle = -1;
            Projectile.hostile = false;
            Projectile.friendly = true;
            Projectile.penetrate = 100;
            Projectile.timeLeft = 70;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.tileCollide = false;

        }



        public override void AI()
        {
            Projectile.ai[0] += 1f;
            if (Projectile.ai[0] >= 1f)
            {
                Projectile.velocity *= 1.05f;
            }
            if (Projectile.ai[0] >= 60f)
            {
                Projectile.velocity *= 0.01f;
            }
			Projectile.direction = Projectile.spriteDirection = Projectile.velocity.X > 0f ? 1 : -1;
            Projectile.rotation = Projectile.velocity.ToRotation();
			if (Projectile.velocity.Y > 16f)
			{
                Projectile.velocity.Y = 16f;
			}
			// Since our sprite has an orientation, we need to adjust rotation to compensate for the draw flipping.
			if (Projectile.spriteDirection == -1)
			{
                Projectile.rotation += MathHelper.Pi;

			}
		}
	}
}

