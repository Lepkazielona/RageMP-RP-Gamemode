"use strict";
var rotation = new mp.Vector3(0, 0, 0);
var isFly = false;
var player = mp.players.local;
var rotation = new mp.Vector3(0, 0, 0);
var speed = 0.5;
var keymap = {
    w: 87,
    s: 83,
    a: 65,
    d: 68,
    q: 81,
    e: 69,
    lshift: 16,
    lctrl: 17
};
mp.events.add('toggle_fly', () => {
    isFly = !isFly;
    player.setCollision(!isFly, !isFly);
    player.freezePosition(isFly);
    mp.gui.chat.push(`fly ${isFly}`);
});
mp.events.add('render', () => {
    if (isFly) {
        if (mp.keys.isDown(keymap.lshift)) {
            speed = 2;
        }
        else if (mp.keys.isDown(keymap.lctrl)) {
            speed = 0.2;
        }
        else
            speed = 0.5;
        if (mp.keys.isDown(keymap.w)) {
            player.setCoordsNoOffset(player.position.x, player.position.y + speed, player.position.z, true, true, true);
        }
        if (mp.keys.isDown(keymap.s)) {
            player.setCoordsNoOffset(player.position.x, player.position.y - speed, player.position.z, true, true, true);
        }
        if (mp.keys.isDown(keymap.a)) {
            player.setCoordsNoOffset(player.position.x + speed, player.position.y, player.position.z, true, true, true);
        }
        if (mp.keys.isDown(keymap.d)) {
            player.setCoordsNoOffset(player.position.x - speed, player.position.y, player.position.z, true, true, true);
        }
        if (mp.keys.isDown(keymap.q)) {
            player.setCoordsNoOffset(player.position.x, player.position.y, player.position.z - speed, true, true, true);
        }
        if (mp.keys.isDown(keymap.e)) {
            player.setCoordsNoOffset(player.position.x, player.position.y, player.position.z + speed, true, true, true);
        }
    }
});
mp.events.add('render', () => {
    mp.game.graphics.drawText(`X: ${player.position.x}`, [0.5, 0.005], {
        font: 7,
        color: [255, 255, 255, 185],
        scale: [0.5, 0.5],
        outline: true
    });
    mp.game.graphics.drawText(`Y: ${player.position.y}`, [0.5, 0.05
    ], {
        font: 7,
        color: [255, 255, 255, 185],
        scale: [0.5, 0.5],
        outline: true
    });
    mp.game.graphics.drawText(`Z: ${player.position.z}`, [0.5, 0.1], {
        font: 7,
        color: [255, 255, 255, 185],
        scale: [0.5, 0.5],
        outline: true
    });
    mp.game.graphics.drawText(`RotX: ${player.getRotation(0).x}`, [0.25, 0.1], {
        font: 7,
        color: [255, 255, 255, 185],
        scale: [0.5, 0.5],
        outline: true
    });
});
