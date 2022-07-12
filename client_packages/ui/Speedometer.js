"use strict";
let vehSpeed = mp.players.local.vehicle.getSpeed();
mp.events.add('render', () => {
    mp.gui.chat.push(String(Math.ceil(vehSpeed * (vehSpeed / 20) * 2)));
});
