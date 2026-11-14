# Unity 2D Rotation Using Transformation Matrices

## Project Overview

This project was developed in C# using Unity for a computer graphics class. It uses vector mathematics and transformation matrices to calculate and animate the rotation of a 2D object around a specified pivot point.

The program determines the angle and direction needed to rotate an object from its starting position toward a target position, then animates the rotation over a specified duration.

## Implementation

- Calculates the angle between starting and target positions using the dot product.
- Determines clockwise or counterclockwise rotation using the 2D cross product.
- Uses 4×4 transformation matrices to rotate objects around a specified pivot point.
- Applies translation and rotation matrices to update object positions.
- Implements frame-rate-independent animation using Unity's `Time.deltaTime`.
- Allows users to configure the rotation point and animation duration.

## How It Works

1. Retrieves the initial and target positions of two Unity GameObjects.
2. Calculates the vectors between each position and the rotation point.
3. Determines the required rotation angle using vector mathematics.
4. Calculates the direction of rotation.
5. Applies transformation matrices to rotate the object around the pivot.
6. Gradually updates the object's position until the rotation is complete.

## Technologies Used

- C#
- Unity Engine
- Vector Mathematics
- Linear Algebra
- Transformation Matrices

## Key Concepts

- 2D Rotation
- Dot Product and Cross Product
- Matrix Transformations
- Coordinate Systems
- Real-Time Animation
- Computer Graphics

## Usage

1. Add `InvKinematics.cs` to a Unity project.
2. Attach the script to the GameObject you want to rotate.
3. Assign the starting and ending GameObjects in the Unity Inspector.
4. Configure `about_x` and `about_y` to specify the rotation point.
5. Set `seconds` to a positive value representing the animation duration.
6. Run the Unity scene to observe the rotation.

## Notes

Although the script is named `InvKinematics.cs`, it demonstrates
single-object rotation around a specified pivot rather than
a complete multi-joint inverse kinematics system.
