;
;orignal FEditorAdv and EA
;https://feuniverse.us/t/hybrid-classes-and-animations/845/19
;
@thumb
@org $0801876C
;
;@r0=char data ptr
push	{lr}
bl		$080168D0
lsl		r0,r0,#0x18
lsr		r0,r0,#0x18
ldr		r1,=$0x080161B8	;@am lazy
ldr		r1,[r1]
mov		r2,#0x24
mul		r0,r2
add		r0,r1
ldr		r0,[r0,#0x8]		;@weapon abilities
mov		r1,#0x2				;@magic?
and		r0,r1
lsr		r0,r0,#0x1
pop		{r1}
bx		r1
