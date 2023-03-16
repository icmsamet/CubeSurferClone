March - 2023
# CubeSurferClone
 
Hello!

This project is a clone of the popular mobile game "Cube Surfer" that I created using the Unity game engine. The purpose of this project was to experiment with different mechanics in Unity and also practice making a fun game.
Unity 2021.3.11f1

## About Game
Cube Surfer is an endless runner game where players move on a cube and try to make it bigger by overcoming obstacles on the way. Players use swipe gestures to move the cube and try to cover as much distance as possible without colliding with the obstacles on the road.

## Used Assets
- Dotween Pro [LINK](https://assetstore.unity.com/packages/tools/visual-scripting/dotween-pro-32416)
- Odin Inspector [LINK](https://assetstore.unity.com/packages/tools/utilities/odin-inspector-and-serializer-89041)
- Dreamteck Spline [LINK](https://assetstore.unity.com/packages/tools/utilities/dreamteck-splines-61926)
- Joystick Pack [LINK](https://assetstore.unity.com/packages/tools/input-management/joystick-pack-107631)

## About Project
This project was developed using the Unity game engine and the C# programming language. The game's models used simple objects in Unity, based on a simple concept where players move the cube and try to climb as high as possible without colliding with obstacles.

The project folder contains all the source code and assets used in the game. By opening the game in Unity, you can examine the project files and edit them to add or modify game features. The game also includes two editors to shorten the Level Design process, one for Collectable Objects and the other for Obstacle Objects.

![EditorGif](https://user-images.githubusercontent.com/76155610/223783092-4f793f8d-1083-459b-86eb-d02fe1d5ddb4.gif)

## Collect Editor
For the editor to work, there needs to be a "Spline" in the scene.

![Collect Editor Notice!](https://user-images.githubusercontent.com/76155610/223788465-1de41cc8-6f97-4e5f-b218-c90cf9516c5f.png)

After adding a "Spline" to the scene, the editor becomes usable.

![Collect Editor](https://user-images.githubusercontent.com/76155610/223789167-e442ae06-4e1d-49c9-9eca-8b7fa6af6d9a.png)

With "Chose Collect Color", we can add a collectible object to the scene with the selected color. After adding the object to the scene, the added object data appears as a tab.

![Collect Tab](https://user-images.githubusercontent.com/76155610/223792791-9714f27d-9002-41fd-9645-5e0ee9eb233a.png)

Here, we can change the color, position, and rotation of the object. We can also make bulk changes by selecting multiple objects.

![Collect Editor Stack](https://user-images.githubusercontent.com/76155610/223793316-baab11db-9ac4-440e-8a15-577d3e97f0a2.png)

## Obstacle Editor
For the editor to work, there needs to be a "Spline" in the scene.

![Obstacle Editor Notice!](https://user-images.githubusercontent.com/76155610/223794073-8da9e2da-31b8-483b-a510-119ea496b9ec.png)

After adding a "Spline" to the scene, the editor becomes usable.

![Obstacle Editor](https://user-images.githubusercontent.com/76155610/223794210-de6b108a-41c5-4d8b-ac32-cc56cdd42e1c.png)

With "Chose Obstacle Type", we can add an obstacle object to the scene with the selected type. After adding the object to the scene, the added object data appears as a tab.

![Obstacle Tab](https://user-images.githubusercontent.com/76155610/223796097-f88d7859-aa60-4bfb-a98a-9de02b9b4e79.png)

Here, we can change the color, position, rotation, and type of the obstacle object. We can also make bulk changes by selecting multiple objects.

![Obstacle Editor Stack](https://user-images.githubusercontent.com/76155610/223796966-b25c0b22-767e-44d2-80d3-cd8f00d5f53d.png)

## Level

After adding any object from the editor, a "Level" component is added on top of the "Spline" object. We can add a level end and change the level number through this component.

![Ekran görüntüsü 2023-03-08 212827](https://user-images.githubusercontent.com/76155610/223802907-3885e6ae-e64d-4ba0-9d5e-1cde1b983c77.png)

## Level End

We can edit the level end through the "Level End" component.

![Ekran görüntüsü 2023-03-08 213120](https://user-images.githubusercontent.com/76155610/223803608-c3ad4f42-6d73-4bae-bf8e-8e20b6cf51f5.png)

The "Level End" component has several variables that we can use to customize the end of the level.

![Level](https://user-images.githubusercontent.com/76155610/223804748-83843ada-8e4a-4efc-81b6-9b84cd797041.gif)
