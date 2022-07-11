require('gamemode/fly.js')
//require('./nametag.js')
mp.discord.update('Kiedyś wymyśle nazwę', 'sdkasndaksndnacksnkdnasknd')

mp.events.add("playerReady", () => {
    let gui = mp.browsers.new("package://web-gui/index.html#/")
    mp.gui.chat.push("browser")
    //gui.execute("app.togglePlayerInVeh(true)")
    //gui.call('togglePlayerInVeh', true);
    //gui.execute("this.app.$store.state.playerInfo.inVeh = true;")
    //gui.reload(false)
    //gui.execute("app.$router.MainView.alertTest()")
    gui.execute('alert("asndnaksndnaksdanskndkansdnk")')
});