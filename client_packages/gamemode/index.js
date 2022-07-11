require('gamemode/fly.js')
//require('./nametag.js')
mp.discord.update('Kiedyś wymyśle nazwę', 'sdkasndaksndnacksnkdnasknd')

mp.events.add("playerReady", () => {
    let gui = mp.browsers.new("package://web-gui/index.html#/gui")
    mp.gui.chat.push("browser")
    //gui.call('playerInCar', true)
    //gui.execute('setPlayerInCar(true)');
    gui.execute('playerInCar = true')
});