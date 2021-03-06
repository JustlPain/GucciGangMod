﻿using System;
using UnityEngine;

namespace GGM
{
    public static class Layer
    {
        public static readonly LayerMask AABB = 2048;
        public static readonly LayerMask AABBHit = AABB | EnemyHitBox;
        public const int AABBN = 11;
        public static readonly LayerMask Attack = 65536;
        public static readonly LayerMask AttackAABB = Attack | AABB;
        public static readonly LayerMask AttackAABBHit = Attack | AABB | EnemyHitBox;
        public static readonly LayerMask AttackHit = Attack | EnemyHitBox;
        public const int AttackN = 16;
        public static readonly LayerMask Default = 1;
        public const int DefaultN = 0;
        public static readonly LayerMask Enemy = 1024;
        public static readonly LayerMask EnemyAABB = Enemy | AABB;
        public static readonly LayerMask EnemyAABBHit = Enemy | AABB | EnemyHitBox;
        public static readonly LayerMask EnemyAttack = Enemy | Attack;
        public static readonly LayerMask EnemyAttackAABB = Enemy | Attack | AABB;
        public static readonly LayerMask EnemyAttackBox = 262144;
        public const int EnemyAttackBoxN = 18;
        public static readonly LayerMask EnemyAttackHit = Enemy | Attack | EnemyHitBox;
        public static readonly LayerMask EnemyHit = Enemy | EnemyHitBox;
        public static readonly LayerMask EnemyHitBox = 524288;
        public const int EnemyHitBoxN = 19;
        public const int EnemyN = 10;
        public static readonly LayerMask EnemyNetworkObject = Enemy | NetworkObject;
        public static readonly LayerMask EnemyNetworkObjectAttack = Enemy | NetworkObject | Attack;
        public static readonly LayerMask EnemyNetworkObjectHit = Enemy | NetworkObject | EnemyHitBox;
        public static readonly LayerMask EnemyPlayers = Enemy | Players;
        public static readonly LayerMask EnemyPlayersAABB = Enemy | Players | AABB;
        public static readonly LayerMask EnemyPlayersAABBHit = Enemy | Players | AABB | EnemyHitBox;
        public static readonly LayerMask EnemyPlayersAttack = Enemy | Players | Attack;
        public static readonly LayerMask EnemyPlayersAttackHit = Enemy | Players | Attack | EnemyHitBox;
        public static readonly LayerMask EnemyPlayersHit = Enemy | Players | EnemyHitBox;
        public static readonly LayerMask EnemyPlayersNetworkObject = Enemy | Players | NetworkObject;
        public static readonly LayerMask EnemyPlayersNetworkObjectAABB = Enemy | Players | NetworkObject | AABB;
        public static readonly LayerMask EnemyPlayersNetworkObjectAABBHit = Enemy | Players | NetworkObject | AABB | EnemyHitBox;
        public static readonly LayerMask EnemyPlayersNetworkObjectAttack = Enemy | Players | NetworkObject | Attack;
        public static readonly LayerMask EnemyPlayersNetworkObjectAttackAABB = Enemy | Players | NetworkObject | Attack | AABB;
        public static readonly LayerMask EnemyPlayersNetworkObjectAttackAABBHit = Enemy | Players | NetworkObject | Attack | AABB | EnemyHitBox;
        public static readonly LayerMask EnemyPlayersNetworkObjectAttackHit = Enemy | Players | NetworkObject | Attack | EnemyHitBox;
        public static readonly LayerMask FX = 4096;
        public const int FXN = 12;
        public static readonly LayerMask Ground = 512;
        public static readonly LayerMask GroundAABB = Ground | AABB;
        public static readonly LayerMask GroundAABBHit = Ground | AABB | EnemyHitBox;
        public static readonly LayerMask GroundAttack = Ground | Attack;
        public static readonly LayerMask GroundAttackHit = Ground | Attack | EnemyHitBox;
        public static readonly LayerMask GroundEnemy = Ground | Enemy;
        public static readonly LayerMask GroundEnemyAABB = Ground | Enemy | AABB;
        public static readonly LayerMask GroundEnemyAABBHit = Ground | Enemy | AABB | EnemyHitBox;
        public static readonly LayerMask GroundEnemyAttack = Ground | Enemy | Attack;
        public static readonly LayerMask GroundEnemyAttackHit = Ground | Enemy | Attack | EnemyHitBox;
        public static readonly LayerMask GroundEnemyHit = Ground | Enemy | EnemyHitBox;
        public static readonly LayerMask GroundEnemyNetworkObject = Ground | Enemy | NetworkObject;
        public static readonly LayerMask GroundEnemyNetworkObjectHit = Ground | Enemy | NetworkObject | EnemyHitBox;
        public static readonly LayerMask GroundEnemyPlayers = Ground | Enemy | Players;
        public static readonly LayerMask GroundEnemyPlayersAABBHit = Ground | Enemy | Players | AABB | EnemyHitBox;
        public static readonly LayerMask GroundEnemyPlayersAttackAABB = Ground | Enemy | Players | Attack | AABB;
        public static readonly LayerMask GroundEnemyPlayersAttackAABBHit = Ground | Enemy | Players | Attack | AABB | EnemyHitBox;
        public static readonly LayerMask GroundEnemyPlayersAttackHit = Ground | Enemy | Players | Attack | EnemyHitBox;
        public static readonly LayerMask GroundEnemyPlayersHit = Ground | Enemy | Players | EnemyHitBox;
        public static readonly LayerMask GroundEnemyPlayersNetworkObject = Ground | Enemy | Players | NetworkObject;
        public static readonly LayerMask GroundEnemyPlayersNetworkObjectAABB = Ground | Enemy | Players | NetworkObject | AABB;
        public static readonly LayerMask GroundEnemyPlayersNetworkObjectAABBHit = Ground | Enemy | Players | NetworkObject | AABB | EnemyHitBox;
        public static readonly LayerMask GroundEnemyPlayersNetworkObjectAttack = Ground | Enemy | Players | NetworkObject | Attack;
        public static readonly LayerMask GroundEnemyPlayersNetworkObjectAttackAABB = Ground | Enemy | Players | NetworkObject | Attack | AABB;
        public static readonly LayerMask GroundEnemyPlayersNetworkObjectAttackAABBHit = Ground | Enemy | Players | NetworkObject | Attack | AABB | EnemyHitBox;
        public static readonly LayerMask GroundEnemyPlayersNetworkObjectAttackHit = Ground | Enemy | Players | NetworkObject | Attack | EnemyHitBox;
        public static readonly LayerMask GroundEnemyPlayersNetworkObjectHit = Ground | Enemy | Players | NetworkObject | EnemyHitBox;
        public static readonly LayerMask GroundHit = Ground | EnemyHitBox;
        public const int GroundN = 9;
        public static readonly LayerMask GroundNetworkObject = Ground | NetworkObject;
        public static readonly LayerMask GroundNetworkObjectHit = Ground | NetworkObject | EnemyHitBox;
        public static readonly LayerMask GroundPlayers = Ground | Players;
        public static readonly LayerMask GroundPlayersAABB = Ground | Players | AABB;
        public static readonly LayerMask GroundPlayersAABBHit = Ground | Players | AABB | EnemyHitBox;
        public static readonly LayerMask GroundPlayersAttack = Ground | Players | Attack;
        public static readonly LayerMask GroundPlayersAttackAABB = Ground | Players | Attack | AABB;
        public static readonly LayerMask GroundPlayersAttackAABBHit = Ground | Players | Attack | AABB | EnemyHitBox;
        public static readonly LayerMask GroundPlayersAttackHit = Ground | Players | Attack | EnemyHitBox;
        public static readonly LayerMask GroundPlayersHit = Ground | Players | EnemyHitBox;
        public static readonly LayerMask GroundPlayersNetworkObject = Ground | Players | NetworkObject;
        public static readonly LayerMask GroundPlayersNetworkObjectAABB = Ground | Players | NetworkObject | AABB;
        public static readonly LayerMask GroundPlayersNetworkObjectAABBHit = Ground | Players | Attack | AABB | EnemyHitBox;
        public static readonly LayerMask GroundPlayersNetworkObjectAttack = Ground | Players | NetworkObject;
        public static readonly LayerMask GroundPlayersNetworkObjectAttackHit = Ground | NetworkObject | Players | Attack | EnemyHitBox;
        public static readonly LayerMask GroundPlayersNetworkObjectHit = Ground | Players | NetworkObject | EnemyHitBox;
        public static readonly LayerMask Ignore_Raycast = 4;
        public const int Ignore_RaycastN = 2;
        public static readonly LayerMask InnerContact = 16384;
        public const int InnerContactN = 14;
        public static readonly LayerMask NetworkObject = 8192;
        public static readonly LayerMask NetworkObjectAABB = NetworkObject | AABB;
        public static readonly LayerMask NetworkObjectAABBHit = NetworkObject | AABB | EnemyHitBox;
        public static readonly LayerMask NetworkObjectAttack = NetworkObject | Attack;
        public static readonly LayerMask NetworkObjectAttackAABB = NetworkObject | Attack | AABB;
        public static readonly LayerMask NetworkObjectAttackAABBHit = NetworkObject | Attack | AABB | EnemyHitBox;
        public static readonly LayerMask NetworkObjectAttackHit = NetworkObject | Attack | EnemyHitBox;
        public static readonly LayerMask NetworkObjectHit = NetworkObject | EnemyHitBox;
        public const int NetworkObjectN = 13;
        public static readonly LayerMask noPhysics = 32768;
        public const int noPhysicsN = 15;
        public static readonly LayerMask PlayerHitBox = 131072;
        public const int PlayerHitBoxN = 17;
        public static readonly LayerMask Players = 256;
        public static readonly LayerMask PlayersAABB = Players | AABB;
        public static readonly LayerMask PlayersAABBHit = Players | AABB | EnemyHitBox;
        public static readonly LayerMask PlayersAttack = Players | Attack;
        public static readonly LayerMask PlayersAttackAABB = Players | Attack | AABB;
        public static readonly LayerMask PlayersAttackAABBHit = Players | Attack | AABB | EnemyHitBox;
        public static readonly LayerMask PlayersAttackHit = Players | Attack | EnemyHitBox;
        public static readonly LayerMask PlayersHit = Players | EnemyHitBox;
        public const int PlayersN = 8;
        public static readonly LayerMask PlayersNetworkObject = Players | NetworkObject;
        public static readonly LayerMask PlayersNetworkObjectAABB = Players | NetworkObject | AABB;
        public static readonly LayerMask PlayersNetworkObjectAABBHit = Players | NetworkObject | AABB | EnemyHitBox;
        public static readonly LayerMask PlayersNetworkObjectAttack = Players | NetworkObject | Attack;
        public static readonly LayerMask PlayersNetworkObjectAttackAABB = Players | NetworkObject | Attack | AABB;
        public static readonly LayerMask PlayersNetworkObjectAttackAABBHit = Players | NetworkObject | Attack | AABB | EnemyHitBox;
        public static readonly LayerMask PlayersNetworkObjectAttackHit = Players | NetworkObject | Attack | EnemyHitBox;
        public static readonly LayerMask PlayersNetworkObjectHit = Players | NetworkObject | EnemyHitBox;
        public static readonly LayerMask TransparentFX = 2;
        public const int TransparentFXN = 1;
        public static readonly LayerMask UI = 32;
        public const int UIN = 5;
        public static readonly LayerMask Water = 16;
        public const int WaterN = 4;
    }
}