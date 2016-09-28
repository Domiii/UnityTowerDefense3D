TODO
* implement Behaviors:
** Idle (do nothing)
** AutoAttack, Move, MoveAndAttack, HuntTarget
* PlayerBrain behaviors: AutoAttack, Move, AttackTarget
* CreepBrain behaviors: AutoAttack, MoveAndAttack
* highlight player's current target
* add Healthbar to Units (slider; billboard; but where to display?)
* highlight Unit on mouse hover
** Different highlights for allied and hostile
** http://answers.unity3d.com/questions/232180/best-way-to-highlight-an-object-on-mouse-over.html
* Creep, CreepSpawn and UnitAI
* Creep type #1: small box (medium range, medium CD, low damage)
* Creep type #2: big box (low range, low CD, medium damage, spawns small boxes upon death)
* reset game on player death
* let HQ heal player
* creep waves (random spawn within SpawnZone; some randomness to creep health)
* new bullet: explosive attack
* new bullet: stun attack
* Unit attack supports different TargetType (ShootEnemy, ShootAlly)
* new bullet for ShootAlly: heal nearby ally
* navigation help: arrow pointing to enemy HQ
* Towers
* auto attack (when player idle, start automatically attacking nearby enemies)
* TODO: More exciting things to do on the map to make it more alive, more interactive
* add TargetType.Ground & new bullet: mine
* speech bubbles



DONE
* setup basic level, w/ PlayerHQ, EnemyHQ and Player
* Navmesh + Player navigation
* Camera controls - [tilt] up+down, [zoom] scrollwheel
* Action handling (Move, Attack, Idle)
* Player can attack enemy HQ