@Call 08016634  FE6
.thumb
@r0 temp(ret rom item struct)
@r1 temp
@r2 temp
@r3 unit
@r4 count << 8 | itemID
@r5 temp(unit copy)

PUSH {r6}

ldrb r0, [r0, #0x0]
cmp r0 ,r2
blt CanNotUsed

@フラグチェックでr1を潰してしまうため
mov r6, #0xff
and r6 ,r4

@copy Unit RAM Struct
mov r5,r3 

@武器を利用できるようなので、追加判定を行う.
ldr r4,WeaponLockEx_Table
sub r4,#0x08

Loop:
add r4,#0x08

ldrb r0,[r4,#0x00]
cmp  r0,#0x00
beq  NotCanUsed

cmp  r0,r6
bne  Loop

CheckUnit:
ldrb r0,[r4,#0x01]
cmp  r0,#0x00
beq  CheckClass

ldr  r2,[r5,#0x00]
ldrb r2,[r2,#0x04]
cmp  r0,r2
bne  Loop

CheckClass:
ldrb r0,[r4,#0x02]
cmp  r0,#0x00
beq  CheckLV

ldr  r2,[r5,#0x04]
ldrb r2,[r2,#0x04]
cmp  r0,r2
bne  Loop

CheckLV:
ldrb r0,[r4,#0x03]
cmp  r0,#0x00
beq  CheckFlag

ldrb r2,[r5,#0x08]
cmp  r0,r2
bgt  Loop

CheckFlag:
ldrh r0,[r4,#0x04]
cmp  r0,#0x00
beq  CanUsed

ldr  r3, =#0x0806BA5C   @FE6 CheckFlag
mov  r14, r3
.short 0xF800
cmp  r0,#0x00
beq  Loop

b    CanUsed            @利用可能

@マッチしなかった場合、そのアイテムが特殊アイテムかどうかを評価します.
NotCanUsed:
ldr r4,WeaponLockEx_Table
sub r4,#0x08

NotCanUsedLoop:
add r4,#0x08

ldrb r0,[r4,#0x00]
cmp  r0,#0x00
beq  CanUsed

cmp  r0,r6
beq  CanNotUsed       @特定の条件を満たしていないと使えない武器なので利用できない
b    NotCanUsedLoop



CanNotUsed:           @利用不可
mov r0,#0x00
b   Exit

CanUsed:              @利用可能
mov r0,#0x01

Exit:
pop {r6}
pop {r5,r4}
pop {r1}
bx r1

.ltorg
.align
WeaponLockEx_Table:
@POIN WeaponLockEx_Table
