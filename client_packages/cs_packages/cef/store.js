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
        message: '',
        closeChat(){
            this.message = ""
            $ref.textbox.blur()
            document.getElementById('textbox').blur()
        },
        openChat(){
            this.blur = false;
            document.getElementById('textbox').focus()
        },
        clearChat(){
          this.message = ''
        },
        focusChat() {
            document.getElementById('textbox').focus()
        },
        usrMsg(nickname, message) {
            this.converstion.push({ 'author': nickname, 'message': message, 'type': 'usermsg' })
        },
        clearChat() {
            this.converstion = []
            this.converstion.push({message: "test", type: "nouser"})
        }
    })
})