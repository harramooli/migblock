
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

// // removed cos metadata is needed, so all done in anvilIdToQublockId
// module.exports.anvilToQublock = function (anvilData) {
//
//     let qublockData = [];
//
//     for (let i = 0; i < anvilData.length; ++i) {
//
//         qublockData.push(anvilIdToQublockId(anvilData[i]));
//     }
//
//     return qublockData;
// }

module.exports.anvilIdToQublockId = anvilIdToQublockId;

//this is for: 1.12.2
function anvilIdToQublockId (anvilId, anvilMeta) {

    switch (anvilId) {

        //NOW, using names is very slow, so instead we use ids
        //this just means there is more coding to do for version
        //changes, but it means faster runtime, so its better

        /* AIR -> AIR */ case 0: return 0;
        /* STONE -> STONE */ case 1: return 1;
        /* GRASS -> GRASS */ case 2: return 2;
        /* DIRT -> DIRT */ case 3: switch (anvilMeta) {
            /* NORMAL DIRT */ case 0: return 3;
            /* COARSE DIRT */ case 1: return 404; //add later
            /* PODZOL DIRT */ case 2: return 404; }//add later
        /* COBBLE -> COBBLE */ case 4: return 4;
        /* PLANKS -> PLANKS */ case 5: switch (anvilMeta) {
            /* OAK PLANKS */      case 0: return 404;
            /* SPRUCE PLANKS */   case 1: return 404; //add later
            /* BIRCH PLANKS */    case 2: return 404; //add later
            /* JUNGLE PLANKS */   case 3: return 404; //add later
            /* ACACIA PLANKS */   case 4: return 404; //add later
            /* DARK OAK PLANKS */ case 5: return 404; }//add later

        /* FLOWINGWATER -> FLOWINGWATER */ case 8: return 18;
        /* WATER -> WATER */ case 9: return 17;

        /* SAND -> SAND */ case 12: switch (anvilMeta) {
            /* NORMAL SAND */ case 0: return 9;
            /* RED SAND */    case 1: return 404; }

        /* LOG -> LOG */ case 17: switch (anvilMeta) {
            /* OAK LOG UPDOWN */    case 0: return 7;
            /* SPRUCE LOG UPDOWN */ case 0: return 8;
            /* BIRCH LOG UPDOWN */  case 0: return 6;
            /* JUNGLE LOG UPDOWN */ case 0: return 404;
                /* OAK LOG WESTEAST */    case 0: return 7;
                /* SPRUCE LOG WESTEAST */ case 0: return 8;
                /* BIRCH LOG WESTEAST */  case 0: return 6;
                /* JUNGLE LOG WESTEAST */ case 0: return 404;
            /* OAK LOG NORTHSOUTH */    case 0: return 7;
            /* SPRUCE LOG NORTHSOUTH */ case 0: return 8;
            /* BIRCH LOG NORTHSOUTH */  case 0: return 6;
            /* JUNGLE LOG NORTHSOUTH */ case 0: return 404; }
        /* LEAVES -> LEAVES */ case 18: switch (anvilMeta) {
            /* OAK LEAVES */    case 0: return 14;
            /* SPRUCE LEAVES */ case 1: return 16;
            /* BIRCH LEAVES */  case 2: return 15;
            /* JUNGLE LEAVES */ case 3: return 404;
            /* MISC */          default: return 14; } //lots of decay states

        /* TALLGRASS -> TALLGRASS */ case 31: switch (anvilMeta) {
            /* SHRUB TALLGRASS */  case 0: return 10;
            /* DOUBLE TALLGRASS */ case 1: return 11;
            /* FERN TALLGRASS */   case 2: return 12; }

        /* CACTUS -> CACTUS */ case 81: return 4;

        //unknown? >> for now, solid
        default: return 404;
    }
}
