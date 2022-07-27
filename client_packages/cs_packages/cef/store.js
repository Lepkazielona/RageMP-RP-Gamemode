document.addEventListener('alpine:init', () => {
    Alpine.store('playerInfo', {
        nickname: 'null',
        
    })
  
    
    Alpine.store('chat', {
        blur: true,
        converstion: [
            //{'author' : 'user', 'message' : 'Testowa wiadomość', 'type': 'usermsg'},
            //{'author' : 'User 2', 'message' : 'Wiadomosc 2', 'type': 'usermsg'},
            //{'message' : "ANNOUNCEMENT", 'type': 'nouser'}
        ],
        focusChat() {
            document.getElementById('textbox').focus()
        },
        newMessage(nickname, message) {
            this.converstion.push({ 'author': nickname, 'message': message})
        },
        clearChat() {
            this.converstion = []
            this.converstion.push({message: "test", type: "nouser"})
        }
    })
})