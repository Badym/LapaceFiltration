.code
ApplyLaplaceFilterAsm proc
    ; RCX - input
    ; RDX - output
    ; R8  - width
    ; R9  - height
    ; [RSP+20h] - start
    ; [RSP+28h] - end

    push rsi
    push rdi
    push rbx

    mov rsi, rcx            ; rsi = input
    mov rdi, rdx            ; rdi = output
    mov rbx, r8             ; rbx = width
    mov rax, r9             ; rax = height
    imul rbx, rax           ; rbx = width * height
    imul rbx, 3             ; rbx = width * height * 3

    xor rcx, rcx            ; rcx = 0 (index)

copy_loop:
    cmp rcx, rbx            ; compare index with width * height * 3
    jge end_loop            ; if index >= width * height * 3, jump to end_loop

    mov al, byte ptr [rsi + rcx] ; load byte from input
    mov byte ptr [rdi + rcx], al ; store byte to output

    inc rcx                 ; increment index
    jmp copy_loop           ; repeat loop

end_loop:
    pop rbx
    pop rdi
    pop rsi

    ret
ApplyLaplaceFilterAsm endp
end
