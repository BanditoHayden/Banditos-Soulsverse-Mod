using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace SoulsMod.Projectiles.WeaponArts
{
    public class BlackHole : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 18;
            Projectile.height = 18;
          
            Projectile.hostile = false;
            Projectile.penetrate = 200;
            Projectile.timeLeft = 120;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.tileCollide = true;
            Projectile.scale = 1f;
        }
        public float pullforce = .5f;
        public float hSpeed;
        public float vSpeed;
        public float direction;
        public NPC test;
        int dusttime;
        public override void AI()
        {
            Dust dust2 = Dust.NewDustDirect(Projectile.position, Projectile.height, Projectile.width, 62, Projectile.velocity.X * .2f, Projectile.velocity.Y * .2f, 200, Scale: 1.2f);
            dusttime++;
            if (dusttime >= 3)
            {
                for (int i = 0; i < 5; i++)
                {
                    float X = Projectile.Center.X - Projectile.velocity.X / 5f * (float)i;
                    float Y = Projectile.Center.Y - Projectile.velocity.Y / 5f * (float)i;


                    int dust = Dust.NewDust(new Vector2(X, Y), 1, 1, 109, 0, 0, 100, default, 1f);
                    Main.dust[dust].position.X = X;
                    Main.dust[dust].position.Y = Y;
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 0f;


                }
            }
            
            Projectile.ai[0] += 1f;
            pullforce = Projectile.damage / 200f;
            for (int i = 0; i < 200; i++)
            {
                test = Main.npc[i];
                if (!test.boss && test.active && test.knockBackResist != 0f && !test.friendly)
                {
                    direction = (Projectile.Center - test.Center).ToRotation();
                    hSpeed = (float)Math.Cos(direction) * pullforce;
                    vSpeed = (float)Math.Sin(direction) * pullforce;
                    test.velocity += new Vector2(hSpeed, vSpeed);
                }
            }
        }
    }
}
