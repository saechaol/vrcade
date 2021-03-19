# [VRcade](https://devpost.com/software/vrcade-6fn5vt)
HackReality 2021 Submission. Built in Unity. Collaborators: [Jason X.](https://github.com/JChunX) [Orion Q.](https://github.com/OrionQ) Evan B.

[Demo Video](https://youtu.be/0XjgkMlgZmc)

## Inspiration
What if you wanted to play a tabletop game but you don't have the equipment? VR does it again! Track a surface, any surface, and play surface-based games! Transform your boring old countertop into a billiard table, air hockey table, ping pong table, and more!

## What it does
You can play various games or sports involving a surface! Our main selling point is that you can use your VR controllers to bring a physical surface into VR. This allows you to interact with the game while still maintaining a sense of physical presence. For example, in billiards, the player rests the non-dominant hand on the table to support the cue stick. With table tracking, you can also rest your hand on a tracked surface, increasing the realism. 

## How we built it
The project was made with Unity. We used C# to program the game logic. The Oculus Integration Package and the Mixed Reality Toolkit were used for setting up Unity for virtual reality. For table tracking, we prompt the player to place the controller on the tracked surface in order to spawn calibration markers. Once the markers are placed, we adjust game objects in the scene accordingly such that the virtual surface corresponds in height and location to the tracked surface.

## Challenges we ran into
Midterms and class ate into our time :')

Initially, we had no idea how to collaborate for creating VR experiences. We found that Unity Collab was a great tool that synced our changes automatically. The Oculus Integration Package was hard to use. Many features of the package - player tracking, UI interactions - behaved inconsistently. This led to a search for alternatives. Luckily, Mixed Reality Toolkit (MRTK) was readily accessible and provided all of the utilities we required. We used MRTK in the Billard game to demonstrate the potential of MRTK, and we used Oculus Integration Package for the rest of the scenes. 

## Accomplishments that we're proud of
We have some working games, and we managed to get this far! 

## What we learned
Overall, we believe that we have learned a great deal about virtual reality development. Practically, we have gained tremendous experience in working with Unity, C#, and virtual reality integration tools. We now understand the basics of both game development and virtual reality development. It has definitely been an intense week, but we believe our discoveries and setbacks will make us stronger as developers and as human beans.
