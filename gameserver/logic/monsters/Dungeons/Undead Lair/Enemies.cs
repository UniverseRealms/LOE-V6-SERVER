﻿using gameserver.logic.behaviors;
using gameserver.logic.loot;
using gameserver.logic.transitions;

namespace gameserver.logic
{
    partial class BehaviorDb
    {
        private _ UndeadLair = () => Behav()
            .Init("Septavius the Ghost God",
                new State(
                    new RealmPortalDrop(),
                    new State(
                        new PlayerWithinTransition(8, "transition1")
                        ),
                    new State(
                        new AddCond(ConditionEffectIndex.Invulnerable),
                        new Flashing(0x00FF00, 0.25, 12),
                        new Wander(1),
                        new State("transition1",
                            new TimedTransition(3000, "spiral")
                            ),
                        new State("transition2",
                            new TimedTransition(3000, "ring")
                            ),
                        new State("transition3",
                            new TimedTransition(3000, "quiet")
                            ),
                        new State("transition4",
                            new TimedTransition(3000, "spawn")
                            )
                        ),
                    new State("spiral",
                        new Spawn("Lair Ghost Archer", 1, 1),
                        new Spawn("Lair Ghost Knight", 2, 2),
                        new Spawn("Lair Ghost Mage", 1, 1),
                        new Spawn("Lair Ghost Rogue", 2, 2),
                        new Spawn("Lair Ghost Paladin", 1, 1),
                        new Spawn("Lair Ghost Warrior", 2, 2),
                        new Shoot(10, 3, angleOffset: 0, coolDownOffset: 0, coolDown: 1000),
                        new Shoot(10, 3, angleOffset: 24, coolDownOffset: 200, coolDown: 1000),
                        new Shoot(10, 3, angleOffset: 48, coolDownOffset: 400, coolDown: 1000),
                        new Shoot(10, 3, angleOffset: 72, coolDownOffset: 600, coolDown: 1000),
                        new Shoot(10, 3, angleOffset: 96, coolDownOffset: 800, coolDown: 1000),
                        new TimedTransition(10000, "transition2")
                        ),
                    new State("ring",
                        new Wander(1),
                        new Shoot(10, 12, index: 4, coolDown: 2000),
                        new TimedTransition(10000, "transition3")
                        ),
                    new State("quiet",
                        new Wander(1),
                        new Shoot(10, 8, index: 1, coolDown: 1000),
                        new Shoot(10, 8, index: 1, coolDownOffset: 500, angleOffset: 22.5, coolDown: 1000),
                        new Shoot(8, 3, shootAngle: 20, index: 2, coolDown: 2000),
                        new TimedTransition(10000, "transition4")
                        ),
                    new State("spawn",
                        new Wander(1),
                        new Spawn("Ghost Mage of Septavius", 2, 2),
                        new Spawn("Ghost Rogue of Septavius", 2, 2),
                        new Spawn("Ghost Warrior of Septavius", 2, 2),
                        new Reproduce("Ghost Mage of Septavius", max: 2, coolDown: 1000),
                        new Reproduce("Ghost Rogue of Septavius", max: 2, coolDown: 1000),
                        new Reproduce("Ghost Warrior of Septavius", max: 2, coolDown: 1000),
                        new Shoot(8, 3, shootAngle: 10, index: 1, coolDown: 1000),
                        new TimedTransition(10000, "transition1")
                        )
                ),
                new Threshold(0.32, /* Maximum 3 wis, minimum 0 wis */
                    new ItemLoot("Potion of Wisdom", 1)
                ),
                new Threshold(0.1,
                    new ItemLoot("Doom Bow", 0.012),
                      new ItemLoot("Interregnum", 0.001),
                        new ItemLoot("Edictum Praetoris", 0.001),
                          new ItemLoot("Memento Mori", 0.001),
                            new ItemLoot("Toga Picta", 0.001),
                    new ItemLoot("Wine Cellar Incantation", 0.005),
                    new TierLoot(3, ItemType.Ring, 0.2),
                    new TierLoot(4, ItemType.Ring, 0.1),
                    new TierLoot(7, ItemType.Weapon, 0.2),
                    new TierLoot(8, ItemType.Weapon, 0.1),
                    new TierLoot(3, ItemType.Ability, 0.2),
                    new TierLoot(4, ItemType.Ability, 0.15),
                    new TierLoot(5, ItemType.Ability, 0.1)
                ),
                new Threshold(0.2
                )
            )
            .Init("Ghost Mage of Septavius",
                new State(
                    new Prioritize(
                        new Protect(0.625, "Septavius the Ghost God", protectRange: 6),
                        new Chase(0.75, range: 7)
                        ),
                    new Wander(2.5),
                    new Shoot(8, 1, coolDown: 1000)
                    ),
                new ItemLoot("Health Potion", 0.25),
                new ItemLoot("Magic Potion", 0.25)
            )
            .Init("Ghost Rogue of Septavius",
                new State(
                    new Chase(0.75, range: 1),
                    new Wander(2.5),
                    new Shoot(8, 1, coolDown: 1000)
                    ),
                new ItemLoot("Health Potion", 0.25),
                new ItemLoot("Magic Potion", 0.25)
            )
            .Init("Ghost Warrior of Septavius",
                new State(
                    new Chase(0.75, range: 1),
                    new Wander(2.5),
                    new Shoot(8, 1, coolDown: 1000)
                    ),
                new ItemLoot("Health Potion", 0.25),
                new ItemLoot("Magic Potion", 0.25)
            )
            .Init("Lair Ghost Archer",
                new State(
                    new Prioritize(
                        new Protect(0.625, "Septavius the Ghost God", protectRange: 6),
                        new Chase(0.75, range: 7)
                        ),
                    new Wander(0.25),
                    new Shoot(8, 1, coolDown: 1000)
                    ),
                new ItemLoot("Health Potion", 0.25),
                new ItemLoot("Magic Potion", 0.25)
            )
            .Init("Lair Ghost Knight",
                new State(
                    new Chase(0.75, range: 1),
                    new Wander(2.5),
                    new Shoot(8, 1, coolDown: 1000)
                    ),
                new ItemLoot("Health Potion", 0.25),
                new ItemLoot("Magic Potion", 0.25)
            )
            .Init("Lair Ghost Mage",
                new State(
                    new Prioritize(
                        new Protect(0.625, "Septavius the Ghost God", protectRange: 6),
                        new Chase(0.75, range: 7)
                        ),
                    new Wander(2.5),
                    new Shoot(8, 1, coolDown: 1000)
                    ),
                new ItemLoot("Health Potion", 0.25),
                new ItemLoot("Magic Potion", 0.25)
            )
            .Init("Lair Ghost Paladin",
                new State(
                    new Chase(0.75, range: 1),
                    new Wander(0.25),
                    new Shoot(8, 1, coolDown: 1000),
                    new Heal(5, 75, "Lair Ghosts", 5000)
                    ),
                new ItemLoot("Health Potion", 0.25),
                new ItemLoot("Magic Potion", 0.25)
            )
            .Init("Lair Ghost Rogue",
                new State(
                    new Chase(0.75, range: 1),
                    new Wander(2.5),
                    new Shoot(8, 1, coolDown: 1000)
                    ),
                new ItemLoot("Health Potion", 0.25),
                new ItemLoot("Magic Potion", 0.25)
            )
            .Init("Lair Ghost Warrior",
                new State(
                    new Chase(0.75, range: 1),
                    new Wander(2.5),
                    new Shoot(8, 1, coolDown: 1000)
                    ),
                new ItemLoot("Health Potion", 0.25),
                new ItemLoot("Magic Potion", 0.25)
            )

            .Init("Lair Skeleton",
                new State(
                    new Shoot(6),
                    new Prioritize(
                        new Chase(1, range: 1),
                        new Wander(4)
                        )
                    ),
                new ItemLoot("Health Potion", 0.05),
                new ItemLoot("Magic Potion", 0.05)
            )
            .Init("Lair Skeleton King",
                new State(
                    new Shoot(10, 3, shootAngle: 10),
                    new Prioritize(
                        new Chase(1, range: 7),
                        new Wander(4)
                        )
                    ),
                new TierLoot(5, ItemType.Armor, 0.2),
                new Threshold(0.5,
                    new TierLoot(6, ItemType.Weapon, 0.2),
                    new TierLoot(7, ItemType.Weapon, 0.1),
                    new TierLoot(8, ItemType.Weapon, 0.05),
                    new TierLoot(6, ItemType.Armor, 0.1),
                    new TierLoot(7, ItemType.Armor, 0.05),
                    new TierLoot(3, ItemType.Ring, 0.1),
                    new TierLoot(3, ItemType.Ability, 0.1)
                    )
            )
            .Init("Lair Skeleton Mage",
                new State(
                    new Shoot(10),
                    new Prioritize(
                        new Chase(1, range: 7),
                        new Wander(4)
                        )
                    ),
                new ItemLoot("Health Potion", 0.05),
                new ItemLoot("Magic Potion", 0.05)
            )
            .Init("Lair Skeleton Swordsman",
                new State(
                    new Shoot(5),
                    new Prioritize(
                        new Chase(1, range: 1),
                        new Wander(4)
                        )
                    ),
                new ItemLoot("Health Potion", 0.05),
                new ItemLoot("Magic Potion", 0.05)
            )
            .Init("Lair Skeleton Veteran",
                new State(
                    new Shoot(5),
                    new Prioritize(
                        new Chase(1, range: 1),
                        new Wander(4)
                        )
                    ),
                new ItemLoot("Health Potion", 0.05),
                new ItemLoot("Magic Potion", 0.05)
            )
            .Init("Lair Mummy",
                new State(
                    new Shoot(10),
                    new Prioritize(
                        new Chase(0.9, range: 7),
                        new Wander(4)
                        )
                    ),
                new ItemLoot("Health Potion", 0.05),
                new ItemLoot("Magic Potion", 0.05)
            )
            .Init("Lair Mummy King",
                new State(
                    new Shoot(10),
                    new Prioritize(
                        new Chase(0.9, range: 7),
                        new Wander(4)
                        )
                    ),
                new ItemLoot("Health Potion", 0.05),
                new ItemLoot("Magic Potion", 0.05)
            )
            .Init("Lair Mummy Pharaoh",
                new State(
                    new Shoot(10),
                    new Prioritize(
                        new Chase(0.9, range: 7),
                        new Wander(4)
                        )
                    ),
                new TierLoot(5, ItemType.Armor, 0.2),
                new Threshold(0.5,
                    new TierLoot(6, ItemType.Weapon, 0.2),
                    new TierLoot(7, ItemType.Weapon, 0.1),
                    new TierLoot(8, ItemType.Weapon, 0.05),
                    new TierLoot(6, ItemType.Armor, 0.1),
                    new TierLoot(7, ItemType.Armor, 0.05),
                    new TierLoot(3, ItemType.Ring, 0.1),
                    new TierLoot(3, ItemType.Ability, 0.1)
                    )
            )

            .Init("Lair Big Brown Slime",
                new State(
                    new Shoot(10, 3, shootAngle: 10, coolDown: 500),
                    new Wander(1),
                    new TransformOnDeath("Lair Little Brown Slime", 1, 6, 1)
                    // new SpawnOnDeath("Lair Little Brown Slime", 1.0, 6)
                    )
            )
            .Init("Lair Little Brown Slime",
                new State(
                    new Shoot(10, 3, shootAngle: 10, coolDown: 500),
                    new Protect(0.1, "Lair Big Brown Slime", sightRange: 5, protectRange: 2),
                    new Wander(1)
                    ),
                new ItemLoot("Health Potion", 0.05),
                new ItemLoot("Magic Potion", 0.05)
            )
            .Init("Lair Big Black Slime",
                new State(
                    new Shoot(10, coolDown: 1000),
                    new Wander(1),
                    new TransformOnDeath("Lair Little Black Slime", 1, 4, 1)
                    //new SpawnOnDeath("Lair Medium Black Slime", 1.0, 4)
                    )
            )
            .Init("Lair Medium Black Slime",
                new State(
                    new Shoot(10, coolDown: 1000),
                    new Wander(1),
                    new TransformOnDeath("Lair Little Black Slime", 1, 4, 1)
                    // new SpawnOnDeath("Lair Little Black Slime", 1.0, 4)
                    )
            )
            .Init("Lair Little Black Slime",
                new State(
                    new Shoot(10, coolDown: 1000),
                    new Wander(1)
                    ),
                new ItemLoot("Health Potion", 0.05),
                new ItemLoot("Magic Potion", 0.05)
            )

            .Init("Lair Construct Giant",
                new State(
                    new Prioritize(
                        new Chase(0.8, range: 7),
                        new Wander(4)
                        ),
                    new Shoot(10, 3, shootAngle: 20, coolDown: 1000),
                    new Shoot(10, index: 1, coolDown: 1000)
                    ),
                new TierLoot(5, ItemType.Armor, 0.2),
                new Threshold(0.5,
                    new TierLoot(6, ItemType.Weapon, 0.2),
                    new TierLoot(7, ItemType.Weapon, 0.1),
                    new TierLoot(8, ItemType.Weapon, 0.05),
                    new TierLoot(6, ItemType.Armor, 0.1),
                    new TierLoot(7, ItemType.Armor, 0.05),
                    new TierLoot(3, ItemType.Ring, 0.1),
                    new TierLoot(3, ItemType.Ability, 0.1)
                    )
            )
            .Init("Lair Construct Titan",
                new State(
                    new Prioritize(
                        new Chase(0.8, range: 7),
                        new Wander(4)
                        ),
                    new Shoot(10, 3, shootAngle: 20, coolDown: 1000),
                    new Shoot(10, 3, shootAngle: 20, index: 1, coolDownOffset: 100, coolDown: 2000)
                    ),
                new TierLoot(5, ItemType.Armor, 0.2),
                new Threshold(0.5,
                    new TierLoot(6, ItemType.Weapon, 0.2),
                    new TierLoot(7, ItemType.Weapon, 0.1),
                    new TierLoot(8, ItemType.Weapon, 0.05),
                    new TierLoot(6, ItemType.Armor, 0.1),
                    new TierLoot(7, ItemType.Armor, 0.05),
                    new TierLoot(3, ItemType.Ring, 0.1),
                    new TierLoot(3, ItemType.Ability, 0.1)
                    )
            )

            .Init("Lair Brown Bat",
                new State(
                    new Wander(0.1),
                    new Charge(3, 8, 2000),
                    new Shoot(3, coolDown: 1000)
                    ),
                new ItemLoot("Health Potion", 0.05),
                new ItemLoot("Magic Potion", 0.05)
            )
            .Init("Lair Ghost Bat",
                new State(
                    new Wander(0.1),
                    new Charge(3, 8, 2000),
                    new Shoot(3, coolDown: 1000)
                    ),
                new ItemLoot("Health Potion", 0.05),
                new ItemLoot("Magic Potion", 0.05)
            )

            .Init("Lair Reaper",
                new State(
                    new Shoot(3),
                    new Chase(1.3, range: 1),
                    new Wander(1)
                    ),
                new TierLoot(5, ItemType.Armor, 0.2),
                new Threshold(0.5,
                    new TierLoot(6, ItemType.Weapon, 0.2),
                    new TierLoot(7, ItemType.Weapon, 0.1),
                    new TierLoot(8, ItemType.Weapon, 0.05),
                    new TierLoot(6, ItemType.Armor, 0.1),
                    new TierLoot(7, ItemType.Armor, 0.05),
                    new TierLoot(3, ItemType.Ring, 0.1),
                    new TierLoot(3, ItemType.Ability, 0.1)
                    )
            )
            .Init("Lair Vampire",
                new State(
                    new Shoot(10, coolDown: 500),
                    new Shoot(3, coolDown: 1000),
                    new Chase(1.3, range: 1),
                    new Wander(1)
                    ),
                new ItemLoot("Health Potion", 0.05),
                new ItemLoot("Magic Potion", 0.05)
            )
            .Init("Lair Vampire King",
                new State(
                    new Shoot(10, coolDown: 500),
                    new Shoot(3, coolDown: 1000),
                    new Chase(1.3, range: 1),
                    new Wander(1)
                    ),
                new TierLoot(5, ItemType.Armor, 0.2),
                new Threshold(0.5,
                    new TierLoot(6, ItemType.Weapon, 0.2),
                    new TierLoot(7, ItemType.Weapon, 0.1),
                    new TierLoot(8, ItemType.Weapon, 0.05),
                    new TierLoot(6, ItemType.Armor, 0.1),
                    new TierLoot(7, ItemType.Armor, 0.05),
                    new TierLoot(3, ItemType.Ring, 0.1),
                    new TierLoot(3, ItemType.Ability, 0.1)
                    )
            )

            .Init("Lair Grey Spectre",
                new State(
                    new Wander(1),
                    new Shoot(10, coolDown: 1000),
                    new Grenade(2.5, 50, 8, coolDown: 1000)
                    )
            )
            .Init("Lair Blue Spectre",
                new State(
                    new Wander(1),
                    new Shoot(10, coolDown: 1000),
                    new Grenade(2.5, 70, 8, coolDown: 1000)
                    )
            )
            .Init("Lair White Spectre",
                new State(
                    new Wander(1),
                    new Shoot(10, coolDown: 1000),
                    new Grenade(2.5, 90, 8, coolDown: 1000)
                    ),
                new Threshold(0.5,
                    new TierLoot(4, ItemType.Ability, 0.15)
                    )
            )
           .Init("Lair Burst Trap",
                new State(
                    new State("FinnaBustANut",
                    new PlayerWithinTransition(3, "Aaa")
                        ),
                    new State("Aaa",
                       new Shoot(8.4, shoots: 12, index: 0),
                       new Suicide()
                    )))
           .Init("Lair Blast Trap",
                new State(
                    new State("FinnaBustANut",
                    new PlayerWithinTransition(3, "Aaa")
                        ),
                    new State("Aaa",
                       new Shoot(25, index: 0, shoots: 12, coolDown: 3000),
                       new Suicide()
                    ))

            );
    }
}