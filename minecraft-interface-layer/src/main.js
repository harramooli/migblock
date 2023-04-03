
const mineflayer = require('mineflayer');

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

    // if (username == bot.username) return;
    //
    // bot.chat(`hello ${username}`);

    process.stdout.write(`${username} ${message} \n`);
});

process.stdin.on('data', (data) => {

    data = data.toString().toUpperCase();
    bot.chat(data);
});
