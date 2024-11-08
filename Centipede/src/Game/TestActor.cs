﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathLibrary;
using Raylib_cs;

namespace Centipede
{
    internal class TestActor : Actor
    {
        struct Movement()
        {

        }
        public float Speed { get; set; } = 100;
        private Color _color = Color.Blue;
        private Color _color1 = Color.Green;

        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);

            //Movement
            Vector2 movementInput = new Vector2();
            movementInput.y -= Raylib.IsKeyDown(KeyboardKey.W);
            movementInput.y += Raylib.IsKeyDown(KeyboardKey.S);
            movementInput.x -= Raylib.IsKeyDown(KeyboardKey.A);
            movementInput.x += Raylib.IsKeyDown(KeyboardKey.D);
            Vector2 deltaMovement = movementInput.Normalized * Speed * (float)deltaTime;

            if (deltaMovement.Magnitude != 0)
                Transform.LocalPosition += (deltaMovement);

            Raylib.DrawRectangleV(Transform.GlobalPosition, (Transform.GlobalScale / 2 * 100), _color);
            
            //Movement
            movementInput.y -= Raylib.IsKeyDown(KeyboardKey.Up);
            movementInput.y += Raylib.IsKeyDown(KeyboardKey.Down);
            movementInput.x -= Raylib.IsKeyDown(KeyboardKey.Left);
            movementInput.x += Raylib.IsKeyDown(KeyboardKey.Right);

            if (deltaMovement.Magnitude != 0)
                Transform.LocalPosition += (deltaMovement);

            Raylib.DrawRectangleV(Transform.GlobalPosition, (Transform.GlobalScale / 2 * 100), _color1);
        }

        public override void OnCollision(Actor other)
        {
            _color = Color.Red;
        }
    }
}
