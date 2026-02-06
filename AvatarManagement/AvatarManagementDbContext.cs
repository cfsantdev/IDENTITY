using AvatarManagement.Entities.Configurations;
using Entities.AvatarManagement;
using Entities.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace AvatarManagement
{
    public class AvatarManagementDbContext : BaseDbContext<AvatarManagementDbContext>
    {
        public AvatarManagementDbContext(DbContextOptions<AvatarManagementDbContext> options)
            : base(options)
        {
        }

        public DbSet<Avatar> Avatar { get; set; }
        public DbSet<Animation> Animation { get; set; }
        public DbSet<AnimationState> AnimationState { get; set; }
        public DbSet<AnimationStateItem> AnimationStateItem { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("public");

            this.OnModelCreatingDefaultAvatar(modelBuilder);
        }

        private void OnModelCreatingDefaultAvatar(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AvatarConfiguration());

            // Avatar
            this.OnModelCreatingDefaultAvatar(modelBuilder, out Guid avatarId);

            // Animation
            this.OnModelCreatingDefaultAvatarAnimation(modelBuilder, avatarId, out Guid animationId);

            // Idle Animation State And Frames
            this.OnModelCreatingDefaultAvatarAnimationStateIdle(modelBuilder, animationId, out Guid animationStateIdleId);
            this.OnModelCreatingDefaultAvatarAnimationStateIdleZero(modelBuilder, animationStateIdleId);
            this.OnModelCreatingDefaultAvatarAnimationStateIdleOne(modelBuilder, animationStateIdleId);
            this.OnModelCreatingDefaultAvatarAnimationStateIdleTwo(modelBuilder, animationStateIdleId);
            this.OnModelCreatingDefaultAvatarAnimationStateIdleThree(modelBuilder, animationStateIdleId);
            this.OnModelCreatingDefaultAvatarAnimationStateIdleFour(modelBuilder, animationStateIdleId);
            this.OnModelCreatingDefaultAvatarAnimationStateIdleFive(modelBuilder, animationStateIdleId);
            this.OnModelCreatingDefaultAvatarAnimationStateIdleSix(modelBuilder, animationStateIdleId);
            this.OnModelCreatingDefaultAvatarAnimationStateIdleSeven(modelBuilder, animationStateIdleId);
            this.OnModelCreatingDefaultAvatarAnimationStateIdleEight(modelBuilder, animationStateIdleId);
            this.OnModelCreatingDefaultAvatarAnimationStateIdleNine(modelBuilder, animationStateIdleId);
            this.OnModelCreatingDefaultAvatarAnimationStateIdleTen(modelBuilder, animationStateIdleId);
            this.OnModelCreatingDefaultAvatarAnimationStateIdleEleven(modelBuilder, animationStateIdleId);

            // Front Animation State And Frames
            this.OnModelCreatingDefaultAvatarAnimationStateFront(modelBuilder, animationId, out Guid animationStateFrontId);
            this.OnModelCreatingDefaultAvatarAnimationStateFrontZero(modelBuilder, animationStateFrontId);
            this.OnModelCreatingDefaultAvatarAnimationStateFrontOne(modelBuilder, animationStateFrontId);
            this.OnModelCreatingDefaultAvatarAnimationStateFrontTwo(modelBuilder, animationStateFrontId);
            this.OnModelCreatingDefaultAvatarAnimationStateFrontThree(modelBuilder, animationStateFrontId);
            this.OnModelCreatingDefaultAvatarAnimationStateFrontFour(modelBuilder, animationStateFrontId);
            this.OnModelCreatingDefaultAvatarAnimationStateFrontFive(modelBuilder, animationStateFrontId);
            this.OnModelCreatingDefaultAvatarAnimationStateFrontSix(modelBuilder, animationStateFrontId);
            this.OnModelCreatingDefaultAvatarAnimationStateFrontSeven(modelBuilder, animationStateFrontId);

            // Back Animation State And Frames
            this.OnModelCreatingDefaultAvatarAnimationStateBack(modelBuilder, animationId, out Guid animationStateBackId);
            this.OnModelCreatingDefaultAvatarAnimationStateBackZero(modelBuilder, animationStateBackId);
            this.OnModelCreatingDefaultAvatarAnimationStateBackOne(modelBuilder, animationStateBackId);
            this.OnModelCreatingDefaultAvatarAnimationStateBackTwo(modelBuilder, animationStateBackId);
            this.OnModelCreatingDefaultAvatarAnimationStateBackThree(modelBuilder, animationStateBackId);
            this.OnModelCreatingDefaultAvatarAnimationStateBackFour(modelBuilder, animationStateBackId);
            this.OnModelCreatingDefaultAvatarAnimationStateBackFive(modelBuilder, animationStateBackId);
            this.OnModelCreatingDefaultAvatarAnimationStateBackSix(modelBuilder, animationStateBackId);
            this.OnModelCreatingDefaultAvatarAnimationStateBackSeven(modelBuilder, animationStateBackId);

            // Right Animation State And Frames
            this.OnModelCreatingDefaultAvatarAnimationStateRight(modelBuilder, animationId, out Guid animationStateRightId);
            this.OnModelCreatingDefaultAvatarAnimationStateRightZero(modelBuilder, animationStateRightId);
            this.OnModelCreatingDefaultAvatarAnimationStateRightOne(modelBuilder, animationStateRightId);
            this.OnModelCreatingDefaultAvatarAnimationStateRightTwo(modelBuilder, animationStateRightId);
            this.OnModelCreatingDefaultAvatarAnimationStateRightThree(modelBuilder, animationStateRightId);
            this.OnModelCreatingDefaultAvatarAnimationStateRightFour(modelBuilder, animationStateRightId);
            this.OnModelCreatingDefaultAvatarAnimationStateRightFive(modelBuilder, animationStateRightId);
            this.OnModelCreatingDefaultAvatarAnimationStateRightSix(modelBuilder, animationStateRightId);
            this.OnModelCreatingDefaultAvatarAnimationStateRightSeven(modelBuilder, animationStateRightId);

            // Left Animation State And Frames
            this.OnModelCreatingDefaultAvatarAnimationStateLeft(modelBuilder, animationId, out Guid animationStateLeftId);
            this.OnModelCreatingDefaultAvatarAnimationStateLeftZero(modelBuilder, animationStateLeftId);
            this.OnModelCreatingDefaultAvatarAnimationStateLeftOne(modelBuilder, animationStateLeftId);
            this.OnModelCreatingDefaultAvatarAnimationStateLeftTwo(modelBuilder, animationStateLeftId);
            this.OnModelCreatingDefaultAvatarAnimationStateLeftThree(modelBuilder, animationStateLeftId);
            this.OnModelCreatingDefaultAvatarAnimationStateLeftFour(modelBuilder, animationStateLeftId);
            this.OnModelCreatingDefaultAvatarAnimationStateLeftFive(modelBuilder, animationStateLeftId);
            this.OnModelCreatingDefaultAvatarAnimationStateLeftSix(modelBuilder, animationStateLeftId);
            this.OnModelCreatingDefaultAvatarAnimationStateLeftSeven(modelBuilder, animationStateLeftId);
        }

        // Avatar
        private void OnModelCreatingDefaultAvatar(ModelBuilder modelBuilder, out Guid avatarId)
        {
            avatarId = Guid.NewGuid();

            modelBuilder.Entity<Avatar>().HasMany(x => x.AnimationCollection).WithOne(x => x.Avatar);

            modelBuilder.Entity<Avatar>().HasData(new Avatar
            {
                Id = avatarId,
                OwnerId = Guid.Empty,
                PublisherId = Guid.Empty,
                Insertion = DateTime.UtcNow,
                W = 14,
                H = 24,
                V = 1,
                Src = "profile"
            });
        }

        // Animation
        private void OnModelCreatingDefaultAvatarAnimation(ModelBuilder modelBuilder, Guid avatarId, out Guid animationId)
        {
            animationId = Guid.NewGuid();

            modelBuilder.Entity<Animation>().HasOne(x => x.Avatar).WithMany(x => x.AnimationCollection);

            modelBuilder.Entity<Animation>().HasData(new Animation
            {
                Id = animationId,
                OwnerId = Guid.Empty,
                PublisherId = Guid.Empty,
                Insertion = DateTime.UtcNow,
                AvatarId = avatarId,
                Src = "profile",
                IdleStateAnimationTimer = 100
            });
        }

        // Idle
        private void OnModelCreatingDefaultAvatarAnimationStateIdle(ModelBuilder modelBuilder, Guid animationId, out Guid animationStateIdleId)
        {
            animationStateIdleId = Guid.NewGuid();

            modelBuilder.Entity<AnimationState>().HasOne(x => x.Animation).WithMany(x => x.AnimationStateCollection);

            modelBuilder.Entity<AnimationState>().HasData(new AnimationState
            {
                Id = animationStateIdleId,
                OwnerId = Guid.Empty,
                PublisherId = Guid.Empty,
                Insertion = DateTime.UtcNow,
                AnimationId = animationId,
                Index = 0,
                Name = "IDLE"
            });
        }

        private void OnModelCreatingDefaultAvatarAnimationStateIdleZero(ModelBuilder modelBuilder, Guid animationStateIdleId)
        {
            Guid animationStateIdleItemZeroId = Guid.NewGuid();

            modelBuilder.Entity<AnimationStateItem>().HasOne(x => x.AnimationState).WithMany(x => x.AnimationStateItemCollection);

            modelBuilder.Entity<AnimationStateItem>().HasData(new AnimationStateItem
            {
                Id = animationStateIdleItemZeroId,
                OwnerId = Guid.Empty,
                PublisherId = Guid.Empty,
                Insertion = DateTime.UtcNow,
                AnimationStateId = animationStateIdleId,
                Index = 0,
                W = 14,
                H = 24,
                X = 25,
                Y = 20
            });
        }

        private void OnModelCreatingDefaultAvatarAnimationStateIdleOne(ModelBuilder modelBuilder, Guid animationStateIdleId)
        {
            Guid animationStateIdleItemOneId = Guid.NewGuid();

            modelBuilder.Entity<AnimationStateItem>().HasData(new AnimationStateItem
            {
                Id = animationStateIdleItemOneId,
                OwnerId = Guid.Empty,
                PublisherId = Guid.Empty,
                Insertion = DateTime.UtcNow,
                AnimationStateId = animationStateIdleId,
                Index = 1,
                W = 14,
                H = 24,
                X = 25,
                Y = 82
            });
        }

        private void OnModelCreatingDefaultAvatarAnimationStateIdleTwo(ModelBuilder modelBuilder, Guid animationStateIdleId)
        {
            Guid animationStateIdleItemTwoId = Guid.NewGuid();

            modelBuilder.Entity<AnimationStateItem>().HasData(new AnimationStateItem
            {
                Id = animationStateIdleItemTwoId,
                OwnerId = Guid.Empty,
                PublisherId = Guid.Empty,
                Insertion = DateTime.UtcNow,
                AnimationStateId = animationStateIdleId,
                Index = 2,
                W = 14,
                H = 24,
                X = 25,
                Y = 148
            });
        }

        private void OnModelCreatingDefaultAvatarAnimationStateIdleThree(ModelBuilder modelBuilder, Guid animationStateIdleId)
        {
            Guid animationStateIdleItemThreeId = Guid.NewGuid();

            modelBuilder.Entity<AnimationStateItem>().HasData(new AnimationStateItem
            {
                Id = animationStateIdleItemThreeId,
                OwnerId = Guid.Empty,
                PublisherId = Guid.Empty,
                Insertion = DateTime.UtcNow,
                AnimationStateId = animationStateIdleId,
                Index = 3,
                W = 14,
                H = 24,
                X = 25,
                Y = 212
            });
        }

        private void OnModelCreatingDefaultAvatarAnimationStateIdleFour(ModelBuilder modelBuilder, Guid animationStateIdleId)
        {
            Guid animationStateIdleItemFourId = Guid.NewGuid();

            modelBuilder.Entity<AnimationStateItem>().HasData(new AnimationStateItem
            {
                Id = animationStateIdleItemFourId,
                OwnerId = Guid.Empty,
                PublisherId = Guid.Empty,
                Insertion = DateTime.UtcNow,
                AnimationStateId = animationStateIdleId,
                Index = 4,
                W = 14,
                H = 24,
                X = 25,
                Y = 276
            });
        }

        private void OnModelCreatingDefaultAvatarAnimationStateIdleFive(ModelBuilder modelBuilder, Guid animationStateIdleId)
        {
            Guid animationStateIdleItemFiveId = Guid.NewGuid();

            modelBuilder.Entity<AnimationStateItem>().HasData(new AnimationStateItem
            {
                Id = animationStateIdleItemFiveId,
                OwnerId = Guid.Empty,
                PublisherId = Guid.Empty,
                Insertion = DateTime.UtcNow,
                AnimationStateId = animationStateIdleId,
                Index = 5,
                W = 14,
                H = 24,
                X = 25,
                Y = 338
            });
        }

        private void OnModelCreatingDefaultAvatarAnimationStateIdleSix(ModelBuilder modelBuilder, Guid animationStateIdleId)
        {
            Guid animationStateIdleItemSixId = Guid.NewGuid();

            modelBuilder.Entity<AnimationStateItem>().HasData(new AnimationStateItem
            {
                Id = animationStateIdleItemSixId,
                OwnerId = Guid.Empty,
                PublisherId = Guid.Empty,
                Insertion = DateTime.UtcNow,
                AnimationStateId = animationStateIdleId,
                Index = 6,
                W = 14,
                H = 24,
                X = 25,
                Y = 404
            });
        }

        private void OnModelCreatingDefaultAvatarAnimationStateIdleSeven(ModelBuilder modelBuilder, Guid animationStateIdleId)
        {
            Guid animationStateIdleItemSevenId = Guid.NewGuid();

            modelBuilder.Entity<AnimationStateItem>().HasData(new AnimationStateItem
            {
                Id = animationStateIdleItemSevenId,
                OwnerId = Guid.Empty,
                PublisherId = Guid.Empty,
                Insertion = DateTime.UtcNow,
                AnimationStateId = animationStateIdleId,
                Index = 7,
                W = 14,
                H = 24,
                X = 25,
                Y = 468
            });
        }

        private void OnModelCreatingDefaultAvatarAnimationStateIdleEight(ModelBuilder modelBuilder, Guid animationStateIdleId)
        {
            Guid animationStateIdleItemEightId = Guid.NewGuid();

            modelBuilder.Entity<AnimationStateItem>().HasData(new AnimationStateItem
            {
                Id = animationStateIdleItemEightId,
                OwnerId = Guid.Empty,
                PublisherId = Guid.Empty,
                Insertion = DateTime.UtcNow,
                AnimationStateId = animationStateIdleId,
                Index = 8,
                W = 14,
                H = 24,
                X = 25,
                Y = 533
            });
        }

        private void OnModelCreatingDefaultAvatarAnimationStateIdleNine(ModelBuilder modelBuilder, Guid animationStateIdleId)
        {
            Guid animationStateIdleItemNineId = Guid.NewGuid();

            modelBuilder.Entity<AnimationStateItem>().HasData(new AnimationStateItem
            {
                Id = animationStateIdleItemNineId,
                OwnerId = Guid.Empty,
                PublisherId = Guid.Empty,
                Insertion = DateTime.UtcNow,
                AnimationStateId = animationStateIdleId,
                Index = 9,
                W = 14,
                H = 24,
                X = 25,
                Y = 597
            });
        }

        private void OnModelCreatingDefaultAvatarAnimationStateIdleTen(ModelBuilder modelBuilder, Guid animationStateIdleId)
        {
            Guid animationStateIdleItemTenId = Guid.NewGuid();

            modelBuilder.Entity<AnimationStateItem>().HasData(new AnimationStateItem
            {
                Id = animationStateIdleItemTenId,
                OwnerId = Guid.Empty,
                PublisherId = Guid.Empty,
                Insertion = DateTime.UtcNow,
                AnimationStateId = animationStateIdleId,
                Index = 10,
                W = 14,
                H = 24,
                X = 25,
                Y = 660
            });
        }

        private void OnModelCreatingDefaultAvatarAnimationStateIdleEleven(ModelBuilder modelBuilder, Guid animationStateIdleId)
        {
            Guid animationStateIdleItemElevenId = Guid.NewGuid();

            modelBuilder.Entity<AnimationStateItem>().HasData(new AnimationStateItem
            {
                Id = animationStateIdleItemElevenId,
                OwnerId = Guid.Empty,
                PublisherId = Guid.Empty,
                Insertion = DateTime.UtcNow,
                AnimationStateId = animationStateIdleId,
                Index = 11,
                W = 14,
                H = 24,
                X = 25,
                Y = 724
            });
        }

        // Front
        private void OnModelCreatingDefaultAvatarAnimationStateFront(ModelBuilder modelBuilder, Guid animationId, out Guid animationStateFrontId)
        {
            animationStateFrontId = Guid.NewGuid();

            modelBuilder.Entity<AnimationState>().HasData(new AnimationState
            {
                Id = animationStateFrontId,
                OwnerId = Guid.Empty,
                PublisherId = Guid.Empty,
                Insertion = DateTime.UtcNow,
                AnimationId = animationId,
                Index = 1,
                Name = "FRONT"
            });
        }

        private void OnModelCreatingDefaultAvatarAnimationStateFrontZero(ModelBuilder modelBuilder, Guid animationStateFrontId)
        {
            Guid animationStateFrontItemZeroId = Guid.NewGuid();

            modelBuilder.Entity<AnimationStateItem>().HasData(new AnimationStateItem
            {
                Id = animationStateFrontItemZeroId,
                OwnerId = Guid.Empty,
                PublisherId = Guid.Empty,
                Insertion = DateTime.UtcNow,
                AnimationStateId = animationStateFrontId,
                Index = 0,
                W = 14,
                H = 24,
                X = 25,
                Y = 275
            });
        }

        private void OnModelCreatingDefaultAvatarAnimationStateFrontOne(ModelBuilder modelBuilder, Guid animationStateFrontId)
        {
            Guid animationStateItemId = Guid.NewGuid();

            modelBuilder.Entity<AnimationStateItem>().HasData(new AnimationStateItem
            {
                Id = animationStateItemId,
                OwnerId = Guid.Empty,
                PublisherId = Guid.Empty,
                Insertion = DateTime.UtcNow,
                AnimationStateId = animationStateFrontId,
                Index = 1,
                W = 14,
                H = 24,
                X = 90,
                Y = 275
            });
        }

        private void OnModelCreatingDefaultAvatarAnimationStateFrontTwo(ModelBuilder modelBuilder, Guid animationStateFrontId)
        {
            Guid animationStateItemId = Guid.NewGuid();

            modelBuilder.Entity<AnimationStateItem>().HasData(new AnimationStateItem
            {
                Id = animationStateItemId,
                OwnerId = Guid.Empty,
                PublisherId = Guid.Empty,
                Insertion = DateTime.UtcNow,
                AnimationStateId = animationStateFrontId,
                Index = 2,
                W = 14,
                H = 24,
                X = 154,
                Y = 275
            });
        }

        private void OnModelCreatingDefaultAvatarAnimationStateFrontThree(ModelBuilder modelBuilder, Guid animationStateFrontId)
        {
            Guid animationStateItemId = Guid.NewGuid();

            modelBuilder.Entity<AnimationStateItem>().HasData(new AnimationStateItem
            {
                Id = animationStateItemId,
                OwnerId = Guid.Empty,
                PublisherId = Guid.Empty,
                Insertion = DateTime.UtcNow,
                AnimationStateId = animationStateFrontId,
                Index = 3,
                W = 14,
                H = 24,
                X = 218,
                Y = 275
            });
        }

        private void OnModelCreatingDefaultAvatarAnimationStateFrontFour(ModelBuilder modelBuilder, Guid animationStateFrontId)
        {
            Guid animationStateItemId = Guid.NewGuid();

            modelBuilder.Entity<AnimationStateItem>().HasData(new AnimationStateItem
            {
                Id = animationStateItemId,
                OwnerId = Guid.Empty,
                PublisherId = Guid.Empty,
                Insertion = DateTime.UtcNow,
                AnimationStateId = animationStateFrontId,
                Index = 4,
                W = 14,
                H = 24,
                X = 281,
                Y = 275
            });
        }

        private void OnModelCreatingDefaultAvatarAnimationStateFrontFive(ModelBuilder modelBuilder, Guid animationStateFrontId)
        {
            Guid animationStateItemId = Guid.NewGuid();

            modelBuilder.Entity<AnimationStateItem>().HasData(new AnimationStateItem
            {
                Id = animationStateItemId,
                OwnerId = Guid.Empty,
                PublisherId = Guid.Empty,
                Insertion = DateTime.UtcNow,
                AnimationStateId = animationStateFrontId,
                Index = 5,
                W = 14,
                H = 24,
                X = 345,
                Y = 275
            });
        }

        private void OnModelCreatingDefaultAvatarAnimationStateFrontSix(ModelBuilder modelBuilder, Guid animationStateFrontId)
        {
            Guid animationStateItemId = Guid.NewGuid();

            modelBuilder.Entity<AnimationStateItem>().HasData(new AnimationStateItem
            {
                Id = animationStateItemId,
                OwnerId = Guid.Empty,
                PublisherId = Guid.Empty,
                Insertion = DateTime.UtcNow,
                AnimationStateId = animationStateFrontId,
                Index = 6,
                W = 14,
                H = 24,
                X = 410,
                Y = 275
            });
        }

        private void OnModelCreatingDefaultAvatarAnimationStateFrontSeven(ModelBuilder modelBuilder, Guid animationStateFrontId)
        {
            Guid animationStateItemId = Guid.NewGuid();

            modelBuilder.Entity<AnimationStateItem>().HasData(new AnimationStateItem
            {
                Id = animationStateItemId,
                OwnerId = Guid.Empty,
                PublisherId = Guid.Empty,
                Insertion = DateTime.UtcNow,
                AnimationStateId = animationStateFrontId,
                Index = 7,
                W = 14,
                H = 24,
                X = 473,
                Y = 275
            });
        }

        // BACK
        private void OnModelCreatingDefaultAvatarAnimationStateBack(ModelBuilder modelBuilder, Guid animationId, out Guid animationStateBackId)
        {
            animationStateBackId = Guid.NewGuid();

            modelBuilder.Entity<AnimationState>().HasData(new AnimationState
            {
                Id = animationStateBackId,
                OwnerId = Guid.Empty,
                PublisherId = Guid.Empty,
                Insertion = DateTime.UtcNow,
                AnimationId = animationId,
                Index = 2,
                Name = "BACK"
            });
        }
        
        private void OnModelCreatingDefaultAvatarAnimationStateBackZero(ModelBuilder modelBuilder, Guid animationStateBackId)
        {
            Guid animationStateItemId = Guid.NewGuid();

            modelBuilder.Entity<AnimationStateItem>().HasData(new AnimationStateItem
            {
                Id = animationStateItemId,
                OwnerId = Guid.Empty,
                PublisherId = Guid.Empty,
                Insertion = DateTime.UtcNow,
                AnimationStateId = animationStateBackId,
                Index = 0,
                W = 14,
                H = 24,
                X = 25,
                Y = 338
            });
        }

        private void OnModelCreatingDefaultAvatarAnimationStateBackOne(ModelBuilder modelBuilder, Guid animationStateBackId)
        {
            Guid animationStateItemId = Guid.NewGuid();

            modelBuilder.Entity<AnimationStateItem>().HasData(new AnimationStateItem
            {
                Id = animationStateItemId,
                OwnerId = Guid.Empty,
                PublisherId = Guid.Empty,
                Insertion = DateTime.UtcNow,
                AnimationStateId = animationStateBackId,
                Index = 1,
                W = 14,
                H = 24,
                X = 90,
                Y = 338
            });
        }

        private void OnModelCreatingDefaultAvatarAnimationStateBackTwo(ModelBuilder modelBuilder, Guid animationStateBackId)
        {
            Guid animationStateItemId = Guid.NewGuid();

            modelBuilder.Entity<AnimationStateItem>().HasData(new AnimationStateItem
            {
                Id = animationStateItemId,
                OwnerId = Guid.Empty,
                PublisherId = Guid.Empty,
                Insertion = DateTime.UtcNow,
                AnimationStateId = animationStateBackId,
                Index = 2,
                W = 14,
                H = 24,
                X = 154,
                Y = 338
            });
        }

        private void OnModelCreatingDefaultAvatarAnimationStateBackThree(ModelBuilder modelBuilder, Guid animationStateBackId)
        {
            Guid animationStateItemId = Guid.NewGuid();

            modelBuilder.Entity<AnimationStateItem>().HasData(new AnimationStateItem
            {
                Id = animationStateItemId,
                OwnerId = Guid.Empty,
                PublisherId = Guid.Empty,
                Insertion = DateTime.UtcNow,
                AnimationStateId = animationStateBackId,
                Index = 3,
                W = 14,
                H = 24,
                X = 218,
                Y = 338
            });
        }

        private void OnModelCreatingDefaultAvatarAnimationStateBackFour(ModelBuilder modelBuilder, Guid animationStateBackId)
        {
            Guid animationStateItemId = Guid.NewGuid();

            modelBuilder.Entity<AnimationStateItem>().HasData(new AnimationStateItem
            {
                Id = animationStateItemId,
                OwnerId = Guid.Empty,
                PublisherId = Guid.Empty,
                Insertion = DateTime.UtcNow,
                AnimationStateId = animationStateBackId,
                Index = 4,
                W = 14,
                H = 24,
                X = 281,
                Y = 338
            });
        }

        private void OnModelCreatingDefaultAvatarAnimationStateBackFive(ModelBuilder modelBuilder, Guid animationStateBackId)
        {
            Guid animationStateItemId = Guid.NewGuid();

            modelBuilder.Entity<AnimationStateItem>().HasData(new AnimationStateItem
            {
                Id = animationStateItemId,
                OwnerId = Guid.Empty,
                PublisherId = Guid.Empty,
                Insertion = DateTime.UtcNow,
                AnimationStateId = animationStateBackId,
                Index = 5,
                W = 14,
                H = 24,
                X = 346,
                Y = 338
            });
        }

        private void OnModelCreatingDefaultAvatarAnimationStateBackSix(ModelBuilder modelBuilder, Guid animationStateBackId)
        {
            Guid animationStateItemId = Guid.NewGuid();

            modelBuilder.Entity<AnimationStateItem>().HasData(new AnimationStateItem
            {
                Id = animationStateItemId,
                OwnerId = Guid.Empty,
                PublisherId = Guid.Empty,
                Insertion = DateTime.UtcNow,
                AnimationStateId = animationStateBackId,
                Index = 6,
                W = 14,
                H = 24,
                X = 410,
                Y = 338
            });
        }

        private void OnModelCreatingDefaultAvatarAnimationStateBackSeven(ModelBuilder modelBuilder, Guid animationStateBackId)
        {
            Guid animationStateItemId = Guid.NewGuid();

            modelBuilder.Entity<AnimationStateItem>().HasData(new AnimationStateItem
            {
                Id = animationStateItemId,
                OwnerId = Guid.Empty,
                PublisherId = Guid.Empty,
                Insertion = DateTime.UtcNow,
                AnimationStateId = animationStateBackId,
                Index = 7,
                W = 14,
                H = 24,
                X = 474,
                Y = 338
            });
        }

        private void OnModelCreatingDefaultAvatarAnimationStateRight(ModelBuilder modelBuilder, Guid animationId, out Guid animationStateRightId)
        {
            animationStateRightId = Guid.NewGuid();

            modelBuilder.Entity<AnimationState>().HasData(new AnimationState
            {
                Id = animationStateRightId,
                OwnerId = Guid.Empty,
                PublisherId = Guid.Empty,
                Insertion = DateTime.UtcNow,
                AnimationId = animationId,
                Index = 3,
                Name = "RIGHT"
            });
        }

        private void OnModelCreatingDefaultAvatarAnimationStateRightZero(ModelBuilder modelBuilder, Guid animationStateRightId)
        {
            Guid animationStateItemId = Guid.NewGuid();

            modelBuilder.Entity<AnimationStateItem>().HasData(new AnimationStateItem
            {
                Id = animationStateItemId,
                OwnerId = Guid.Empty,
                PublisherId = Guid.Empty,
                Insertion = DateTime.UtcNow,
                AnimationStateId = animationStateRightId,
                Index = 0,
                W = 14,
                H = 24,
                X = 25,
                Y = 404
            });
        }

        private void OnModelCreatingDefaultAvatarAnimationStateRightOne(ModelBuilder modelBuilder, Guid animationStateRightId)
        {
            Guid animationStateItemId = Guid.NewGuid();

            modelBuilder.Entity<AnimationStateItem>().HasData(new AnimationStateItem
            {
                Id = animationStateItemId,
                OwnerId = Guid.Empty,
                PublisherId = Guid.Empty,
                Insertion = DateTime.UtcNow,
                AnimationStateId = animationStateRightId,
                Index = 1,
                W = 14,
                H = 24,
                X = 90,
                Y = 404
            });
        }

        private void OnModelCreatingDefaultAvatarAnimationStateRightTwo(ModelBuilder modelBuilder, Guid animationStateRightId)
        {
            Guid animationStateItemId = Guid.NewGuid();

            modelBuilder.Entity<AnimationStateItem>().HasData(new AnimationStateItem
            {
                Id = animationStateItemId,
                OwnerId = Guid.Empty,
                PublisherId = Guid.Empty,
                Insertion = DateTime.UtcNow,
                AnimationStateId = animationStateRightId,
                Index = 2,
                W = 14,
                H = 24,
                X = 154,
                Y = 404
            });
        }

        private void OnModelCreatingDefaultAvatarAnimationStateRightThree(ModelBuilder modelBuilder, Guid animationStateRightId)
        {
            Guid animationStateItemId = Guid.NewGuid();

            modelBuilder.Entity<AnimationStateItem>().HasData(new AnimationStateItem
            {
                Id = animationStateItemId,
                OwnerId = Guid.Empty,
                PublisherId = Guid.Empty,
                Insertion = DateTime.UtcNow,
                AnimationStateId = animationStateRightId,
                Index = 3,
                W = 14,
                H = 24,
                X = 218,
                Y = 404
            });
        }

        private void OnModelCreatingDefaultAvatarAnimationStateRightFour(ModelBuilder modelBuilder, Guid animationStateRightId)
        {
            Guid animationStateItemId = Guid.NewGuid();

            modelBuilder.Entity<AnimationStateItem>().HasData(new AnimationStateItem
            {
                Id = animationStateItemId,
                OwnerId = Guid.Empty,
                PublisherId = Guid.Empty,
                Insertion = DateTime.UtcNow,
                AnimationStateId = animationStateRightId,
                Index = 4,
                W = 14,
                H = 24,
                X = 281,
                Y = 404
            });
        }

        private void OnModelCreatingDefaultAvatarAnimationStateRightFive(ModelBuilder modelBuilder, Guid animationStateRightId)
        {
            Guid animationStateItemId = Guid.NewGuid();

            modelBuilder.Entity<AnimationStateItem>().HasData(new AnimationStateItem
            {
                Id = animationStateItemId,
                OwnerId = Guid.Empty,
                PublisherId = Guid.Empty,
                Insertion = DateTime.UtcNow,
                AnimationStateId = animationStateRightId,
                Index = 5,
                W = 14,
                H = 24,
                X = 346,
                Y = 404
            });
        }

        private void OnModelCreatingDefaultAvatarAnimationStateRightSix(ModelBuilder modelBuilder, Guid animationStateRightId)
        {
            Guid animationStateItemId = Guid.NewGuid();

            modelBuilder.Entity<AnimationStateItem>().HasData(new AnimationStateItem
            {
                Id = animationStateItemId,
                OwnerId = Guid.Empty,
                PublisherId = Guid.Empty,
                Insertion = DateTime.UtcNow,
                AnimationStateId = animationStateRightId,
                Index = 6,
                W = 14,
                H = 24,
                X = 410,
                Y = 404
            });
        }

        private void OnModelCreatingDefaultAvatarAnimationStateRightSeven(ModelBuilder modelBuilder, Guid animationStateRightId)
        {
            Guid animationStateItemId = Guid.NewGuid();

            modelBuilder.Entity<AnimationStateItem>().HasData(new AnimationStateItem
            {
                Id = animationStateItemId,
                OwnerId = Guid.Empty,
                PublisherId = Guid.Empty,
                Insertion = DateTime.UtcNow,
                AnimationStateId = animationStateRightId,
                Index = 7,
                W = 14,
                H = 24,
                X = 474,
                Y = 404
            });
        }

        private void OnModelCreatingDefaultAvatarAnimationStateLeft(ModelBuilder modelBuilder, Guid animationId, out Guid animationStateLeftId) {
            animationStateLeftId = Guid.NewGuid();

            modelBuilder.Entity<AnimationState>().HasData(new AnimationState
            {
                Id = animationStateLeftId,
                OwnerId = Guid.Empty,
                PublisherId = Guid.Empty,
                Insertion = DateTime.UtcNow,
                AnimationId = animationId,
                Index = 4,
                Name = "LEFT"
            });
        }

        private void OnModelCreatingDefaultAvatarAnimationStateLeftZero(ModelBuilder modelBuilder, Guid animationStateLeftId)
        {
            Guid animationStateItemId = Guid.NewGuid();

            modelBuilder.Entity<AnimationStateItem>().HasData(new AnimationStateItem
            {
                Id = animationStateItemId,
                OwnerId = Guid.Empty,
                PublisherId = Guid.Empty,
                Insertion = DateTime.UtcNow,
                AnimationStateId = animationStateLeftId,
                Index = 0,
                W = 14,
                H = 24,
                X = 26,
                Y = 468
            });
        }

        private void OnModelCreatingDefaultAvatarAnimationStateLeftOne(ModelBuilder modelBuilder, Guid animationStateLeftId)
        {
            Guid animationStateItemId = Guid.NewGuid();

            modelBuilder.Entity<AnimationStateItem>().HasData(new AnimationStateItem
            {
                Id = animationStateItemId,
                OwnerId = Guid.Empty,
                PublisherId = Guid.Empty,
                Insertion = DateTime.UtcNow,
                AnimationStateId = animationStateLeftId,
                Index = 1,
                W = 14,
                H = 24,
                X = 90,
                Y = 467
            });
        }

        private void OnModelCreatingDefaultAvatarAnimationStateLeftTwo(ModelBuilder modelBuilder, Guid animationStateLeftId)
        {
            Guid animationStateItemId = Guid.NewGuid();

            modelBuilder.Entity<AnimationStateItem>().HasData(new AnimationStateItem
            {
                Id = animationStateItemId,
                OwnerId = Guid.Empty,
                PublisherId = Guid.Empty,
                Insertion = DateTime.UtcNow,
                AnimationStateId = animationStateLeftId,
                Index = 2,
                W = 14,
                H = 24,
                X = 153,
                Y = 468
            });
        }

        private void OnModelCreatingDefaultAvatarAnimationStateLeftThree(ModelBuilder modelBuilder, Guid animationStateLeftId)
        {
            Guid animationStateItemId = Guid.NewGuid();

            modelBuilder.Entity<AnimationStateItem>().HasData(new AnimationStateItem
            {
                Id = animationStateItemId,
                OwnerId = Guid.Empty,
                PublisherId = Guid.Empty,
                Insertion = DateTime.UtcNow,
                AnimationStateId = animationStateLeftId,
                Index = 3,
                W = 14,
                H = 24,
                X = 218,
                Y = 468
            });
        }

        private void OnModelCreatingDefaultAvatarAnimationStateLeftFour(ModelBuilder modelBuilder, Guid animationStateLeftId)
        {
            Guid animationStateItemId = Guid.NewGuid();

            modelBuilder.Entity<AnimationStateItem>().HasData(new AnimationStateItem
            {
                Id = animationStateItemId,
                OwnerId = Guid.Empty,
                PublisherId = Guid.Empty,
                Insertion = DateTime.UtcNow,
                AnimationStateId = animationStateLeftId,
                Index = 4,
                W = 14,
                H = 24,
                X = 282,
                Y = 468
            });
        }

        private void OnModelCreatingDefaultAvatarAnimationStateLeftFive(ModelBuilder modelBuilder, Guid animationStateLeftId)
        {
            Guid animationStateItemId = Guid.NewGuid();

            modelBuilder.Entity<AnimationStateItem>().HasData(new AnimationStateItem
            {
                Id = animationStateItemId,
                OwnerId = Guid.Empty,
                PublisherId = Guid.Empty,
                Insertion = DateTime.UtcNow,
                AnimationStateId = animationStateLeftId,
                Index = 5,
                W = 14,
                H = 24,
                X = 346,
                Y = 468
            });
        }

        private void OnModelCreatingDefaultAvatarAnimationStateLeftSix(ModelBuilder modelBuilder, Guid animationStateLeftId)
        {
            Guid animationStateItemId = Guid.NewGuid();

            modelBuilder.Entity<AnimationStateItem>().HasData(new AnimationStateItem
            {
                Id = animationStateItemId,
                OwnerId = Guid.Empty,
                PublisherId = Guid.Empty,
                Insertion = DateTime.UtcNow,
                AnimationStateId = animationStateLeftId,
                Index = 6,
                W = 14,
                H = 24,
                X = 409,
                Y = 468
            });
        }

        private void OnModelCreatingDefaultAvatarAnimationStateLeftSeven(ModelBuilder modelBuilder, Guid animationStateLeftId)
        {
            Guid animationStateItemId = Guid.NewGuid();

            modelBuilder.Entity<AnimationStateItem>().HasData(new AnimationStateItem
            {
                Id = animationStateItemId,
                OwnerId = Guid.Empty,
                PublisherId = Guid.Empty,
                Insertion = DateTime.UtcNow,
                AnimationStateId = animationStateLeftId,
                Index = 7,
                W = 14,
                H = 24,
                X = 474,
                Y = 468
            });
        }
    }
}
