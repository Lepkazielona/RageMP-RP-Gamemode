"use strict";
/// Web Gui here
mp.events.add('playerReady', () => {
    let browser = mp.browsers.new("package://web-gui/dist/index.html#/gui");
    browser.execute("setSpeed(150)");
});
