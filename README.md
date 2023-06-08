# IzyJam-SliceItAll
Clone game for Slice It All
Unity version: **2020.3.25f1**

**Gameplay**: Tap to flip the knife and slice amazing obstacles in juiciest way! Cut or slice everything and become slice master!

Download the latest **Android** build using the following QR Code:

![Android Build](/qrcode-android-build.png)

## GameLoop

1. Knife starts stuck on the floor;
2. A message "Touch to flip" is displayed;
3. Knife jumps and starts to flip every time the player touches the screen;
4. If no touch is made, the knife will fall down on the ground and the game is over;
5. The main goal is to best calculate when touch the screen so the knife can land in specific spots and hit (slice) specifics objects.
6. In the level's end, there is the "Multiplier Tower":
    6.1. Contains multiple vertical sections varying in its height;
    6.2. Each section contains a multiplier number;
    6.3. When the knife hits any section the game is finished and the Score is multiplied by its number;
    6.2. The goal is to hit the biggest number (the smallest section).

## CI/CD

Continuous Integration and Continuous Delivery are done using [GitHub Actions for Unity](https://github.com/game-ci/unity-actions), provided by the [GameCI](https://game.ci/).

You can play the last WebGL build on [github-pages](https://hyagooliveira.github.io/IzyJam-SliceItAll/).