//require('./nametag.js')
require('util/fly')
var cursor = false;

/**
 * Keybindings
 */
 mp.keys.bind(192, false, () => {
    cursor = !cursor
    mp.gui.cursor.show(cursor, cursor)
})


/*
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
*/