
//atm the table is just setup to split solids and air
//so we can get some simple terrain displaying

//later will add all block types and states here
    //will have to figure out how to access metadata
        //maybe just getBlock? and then anvilData[i].name?
        //will have to see

//in 1.13+ we will use states/idk
//  block.metadata MIGHT still be valid, check this out when we get to it

//  obv put that info in the convert table when its made /\ that stuff
//  for future when we make 1.13 client

//you can use this to check ids and stuff as well: https://prismarinejs.github.io/minecraft-data/

module.exports.anvilToQublock = function (anvilData) {

    let qublockData = [];

    for (let i = 0; i < anvilData.length; ++i) {

        qublockData.push(anvilIdToQublockId(anvilData[i]));
    }

    return qublockData;
}

module.exports.anvilIdToQublockId = anvilIdToQublockId;

function anvilIdToQublockId (anvilId) {

    switch (anvilId) {

        //NOW, using names is very slow, so instead we use ids
        //this just means there is more coding to do for version
        //changes, but it means faster runtime, so its better

        /* AIR -> AIR */ case 0: return 0;

        //unknown? >> for now, solid
        default: return 1;
    }
}
