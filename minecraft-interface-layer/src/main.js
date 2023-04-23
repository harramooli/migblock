
const mineflayer = require('mineflayer');
const Vec3 = require('vec3');

const runLengthEncoding = require('./rle.js');
const blockTable = require('./blockTable.js');

if (process.argv.length != 6) {

    process.stderr.write("cannot be run directly! || incorrect usage!\n");
    process.exit(-1);
}

const bot = mineflayer.createBot({

    host: process.argv[2],
    port: parseInt(process.argv[3]),
    username: process.argv[4],
    version: process.argv[5]
});


bot.on('chat', (username, message) => {

    process.stdout.write(`chat\n${username}\n${message}\n`);
});

bot.on('spawn', () => {

    let pos = bot.entity.position;
    let yaw = bot.entity.yaw;
    let pitch = bot.entity.pitch;
    process.stdout.write(`spawn\n${pos.x}\n${pos.y}\n${pos.z}\n${yaw}\n${pitch}\n`);
});

bot.on('chunkColumnLoad', (point) => {

    let chunk = bot.world.getColumnAt(point);

    let blockData = [];
    for (let i = 0; i < 4; ++i)
        for (let x = 0; x < 16; ++x)
            for (let y = i * 64; y < (i + 1) * 64; ++y)
                for (let z = 0; z < 16; ++z)
                    blockData.push(
                        blockTable.anvilIdToQublockId(
                                chunk.getBlockType(new Vec3(x, y, z)),
                                chunk.getBlockData(new Vec3(x, y, z))
                        )
                    );

    // blockData = blockTable.anvilToQublock(blockData);
    blockData = runLengthEncoding.encode(blockData);

    process.stderr.write(`chunkLoad\n${point.x}\n${point.z}\n${blockData.toString()}\n`);
});

bot.on('chunkColumnUnload', (point) => {

    process.stderr.write(`chunkUnload\n${point.x}\n${point.z}\n`);
});

bot.on('blockUpdate', (oldBlock, newBlock) => {

    let packet = 'blockUpdate\n';
    packet += `${newBlock.position.x}\n`;
    packet += `${newBlock.position.y}\n`;
    packet += `${newBlock.position.z}\n`;
    packet += `${blockTable.anvilIdToQublockId(newBlock.type, newBlock.metadata)}\n`;

    process.stdout.write(packet);
});

bot.on('move', () => {

    let packet = 'move\n';
    packet += `${bot.entity.position.x}\n`;
    packet += `${bot.entity.position.y}\n`;
    packet += `${bot.entity.position.z}\n`;

    process.stdout.write(packet);
});

//todo: create event handler for this
process.stdin.on('data', (data) => {

    data = data.toString().slice(0, -1).split(' ');

    switch (data[0]) {

        case 'keyUp': case 'keyDown': {

            switch (data[1]) {

                case 'W': bot.setControlState('forward', data[0] != 'keyUp'); break;
                case 'A': bot.setControlState('left', data[0] != 'keyUp'); break;
                case 'S': bot.setControlState('back', data[0] != 'keyUp'); break;
                case 'D': bot.setControlState('right', data[0] != 'keyUp'); break;
                case 'Space': bot.setControlState('jump', data[0] != 'keyUp'); break;
            }

        break; }

        case 'look': {

            bot.look(parseFloat(data[1]), parseFloat(data[2]));

        break; }
    }
});
