import "./chat"

var guiBrowser = mp.browsers.new("package://assets/html/MainGui.html");
//export default guiBrowser;
var localPlayer = mp.players.local;
//Object.assign(global, guiBrowser);

mp.events.add("playerReady", () => {
    mp.gui.chat.activate(false);
    mp.gui.chat.show(false);
    //guiBrowser.markAsChat();
    guiBrowser.execute(`Alpine.store('playerInfo').nickname = ${localPlayer.name}`);
})