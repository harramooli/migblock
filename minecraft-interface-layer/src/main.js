
const mineflayer = require('mineflayer');
const Vec3 = require('vec3');

const runLengthEncoding = require('./rle.js');
const blockTable = require('./blockTable.js');

if (process.argv.length != 6) {

    process.stderr.write("cannot be run directly! || incorrect usage!\n");
    process.exit(-1);
}

// for (let val of process.argv) console.log(val);

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

    let position = bot.entity.position;
    process.stdout.write(`spawn\n${position.x}\n${position.y}\n${position.z}\n`);
});

bot.on('chunkColumnLoad', (point) => {

    let chunk = bot.world.getColumnAt(point);

    let blockData = [];
    for (let i = 0; i < 4; ++i)
        for (let x = 0; x < 16; ++x)
            for (let y = i * 64; y < (i + 1) * 64; ++y)
            // for (let y = 0; y < 64; ++y)
                for (let z = 0; z < 16; ++z)
                    blockData.push(chunk.getBlockType(new Vec3(x, y, z)));

    blockData = blockTable.anvilToQublock(blockData);
    blockData = runLengthEncoding.encode(blockData);

    process.stdout.write(`chunkLoad\n${point.x}\n${point.z}\n${blockData.toString()}\n`);
});

bot.on('chunkColumnUnload', (point) => {

    process.stdout.write(`chunkUnload\n${point.x}\n${point.z}\n`);
});

//todo: create event handler for this
process.stdin.on('data', (data) => {

    data = data.toString();
    bot.chat(data);
});
