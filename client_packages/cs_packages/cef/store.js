document.addEventListener('alpine:init', () => {
    Alpine.store('playerInfo', {
        nickname: 'null',
        
    })
    Alpine.store('chat', {
        converstion: [
            {'author' : 'user', 'message' : 'Testowa wiadomość'},
            {'author' : 'User 2', 'message' : 'Wiadomosc 2'},
        ],
        focusChat(){
            focus($refs.textBox)
        }
    })
})