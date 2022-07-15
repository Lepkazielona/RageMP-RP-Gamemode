/*
 * 
 * RageMP script, not cef 
 * 
 */


mp.events.add('playerReady', () => {
    let gui = mp.browsers.new('package://cef/gui.html');
    gui.execute('app.$data.message = "Hello Rage"');
})