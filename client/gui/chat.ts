import guiBrowser from "./cef";


//import { guiBrowser } from ".";
//guiBrowser.execute("Alpine.store('chat').openChat()");
//let guiBrowser = require("./index").guiBrowser

//import guiBrowser from "@/index"

var lastMessageTick:number = 0;
var chatOpen:boolean = false;

mp.events.add("client::chat::sendMessageToServer", sendMessageToServer)
mp.events.add("client::chat::sendMessageToCef", sendMessageToCef)
mp.events.add("client::chat::closeChat", closeChat)
//t
mp.keys.bind(84, false, openChat)


function sendMessageToServer(message:string){
    mp.events.callRemote("server::chat::sendChatMessage", message);
}

function sendMessageToCef(author:string, message:string){
    lastMessageTick = 0;
    guiBrowser.execute("Alpine.store('chat').blur = false");
    guiBrowser.execute(`Alpine.store('chat').usrMsg('${author}', '${message}')`)
}

function closeChat(){
    chatOpen = false;
    mp.gui.cursor.show(false, false);
    guiBrowser.execute("Alpine.store('chat').closeChat()")
}

function openChat(){
    chatOpen = true;
    mp.gui.cursor.show(true, true);
    guiBrowser.execute("Alpine.store('chat').openChat()");
}
mp.events.add("render", () => {
    //lastMessageTick += 1;
    if(lastMessageTick == 1000){
        guiBrowser.execute("Alpine.store('chat').blur = true")
    }
    
    if(lastMessageTick == 3000){
        lastMessageTick = 1000;
    }
    
    if(chatOpen){
        lastMessageTick = 0;
    }
})