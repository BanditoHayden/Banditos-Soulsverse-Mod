using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using System;
using SoulsMod.Items.Weapons.Melee.Greatswords;
namespace SoulsMod.Projectiles.Greatswords
{

	public class StarscourgeGreatswordSlash : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Starscourge");
			Main.projFrames[Projectile.type] = 3;
		}
		public override void SetDefaults()
		{
			Projectile.width = 100;
			Projectile.height = 100;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.tileCollide = false;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 11;
			Projectile.ignoreWater = true;
		}

		public override void AI()
		{
			Player player = Main.player[Projectile.owner];
			//player.heldProj = Projectile.whoAmI;
			Projectile.frameCounter++;
			if (Projectile.frameCounter >= 4)
			{
				Projectile.frame++;
				Projectile.frameCounter = 0;
			}
			Projectile.rotation = Projectile.velocity.ToRotation();
			Projectile.position = player.Center - new Vector2(Projectile.width / 2, Projectile.height / 2);
			if (Projectile.spriteDirection == -1)
			{
				Projectile.position = player.Center + new Vector2(Projectile.width / 2, Projectile.height / 2);
			}
			if (Projectile.timeLeft == 2)
			{
				Projectile.friendly = false;
			}
		


		} 
	}

}


