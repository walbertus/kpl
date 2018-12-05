﻿using System;
using test1.Common;
using System.Collections.Generic;
using Gdk;

namespace test1.Draw.Object
{
    public class Group : ObjectBase
    {
        List<ObjectBase> objectList;

        public Group(PointD startPoint, PointD endPoint)
        {
            Init();
            objectList = new List<ObjectBase>();
        }

        public override void Scale(PointD newPoint, int position)
        {
            foreach(ObjectBase obj in objectList)
            {
                obj.Scale(newPoint, position);
            }
        }

        public override void Draw(Window window)
        {
            foreach (ObjectBase obj in objectList)
            {
                obj.Draw(window);
            }
        }

        public override void Select()
        {
            foreach (ObjectBase obj in objectList)
            {
                obj.Select();
            }
        }

        public override void Deselect()
        {
            foreach (ObjectBase obj in objectList)
            {
                obj.Deselect();
            }
        }

        public override void ChangeColor(int r, int g, int b)
        {
            foreach (ObjectBase obj in objectList)
            {
                obj.ChangeColor(r, g, b);
            }
        }

        public override void Translate(double x, double y)
        {
            foreach (ObjectBase obj in objectList)
            {
                obj.Translate(x, y);
            }
        }

        public override bool IsContain(PointD point)
        {
            foreach (ObjectBase obj in objectList)
            {
                if (obj.IsContain(point))
                {
                    return true;
                }
            }
            return false;
        }

        protected override void CreatePoints(PointD startPoint, PointD endPoint)
        {

        }
    }
}