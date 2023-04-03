
#builds the interface layer and pushes it to the unity project(s)

#DO NOT use this to build layer for release, difrent steps will be taken
#to build it in the build scripts in the root of the repo, they will handle
#building this interface layer and packaging it with the releases

echo "checking build dir..."

if [ ! -d ./build/ ]; then

    echo "creating build dir"
    mkdir ./build/
fi

echo "building node project..."

pkg src/main.js -o ./build/mcil

echo "coping compiled binary..."

cp ./build/mcil ../migblock-unity/mcil

echo "cleaning up..."

rm ./build/mcil

echo "done!"
