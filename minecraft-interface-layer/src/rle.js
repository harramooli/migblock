//
// module.exports = {
//
//     runLengthEncode,
//     runLengthDecode
// };

module.exports.encode = function (data) {

    let encodedData = [];
    let currentType = data[0], currentCount = 1;

    for (let i = 1; i < data.length; ++i) {

        if (data[i] == currentType) {

            currentCount++;

        } else {

            encodedData.push(currentType);
            encodedData.push(currentCount);

            currentType = data[i];
            currentCount = 1;
        }
    }

    encodedData.push(currentType);
    encodedData.push(currentCount);

    return encodedData;
}

module.exports.decode = function (data) {

    let decodedData = [];
    let type = 0, count = 0;

    for (let i = 0; i < data.length; i += 2) {

        type = data[i]; count = data[i + 1];

        for (let ii = 0; ii < count; ++ii)
            decodedData.push(type);
    }

    return decodedData;
}
