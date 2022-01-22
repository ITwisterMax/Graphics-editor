using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphics_Editor
{
    public class Shapes
    {
        // Список текущих фигур
        public Dictionary<int, GeneralTool> shapesList;
        // Список отмененных фигур
        private Dictionary<int, GeneralTool> redoShapesList;
        // Количество текущих фигур
        private int shapesNumber;
        // Количество отмененных фигур
        private int redoShapesNumber;                    

        public Shapes()
        {
            shapesList = new Dictionary<int, GeneralTool>();
            redoShapesList = new Dictionary<int, GeneralTool>();
            shapesNumber = 0;
            redoShapesNumber = 0;
        }

        // Добавление фигуры в список
        public void Add(GeneralTool shape)
        {    
            shapesList[++shapesNumber] = shape.Clone();
        }

        // Метод Undo
        public void Undo()
        {
            if (shapesNumber > 0)
            {
                if (GeneralTool.isEnd)
                {
                    redoShapesList[++redoShapesNumber] = shapesList[shapesNumber];
                    shapesList.Remove(shapesNumber);
                    shapesNumber--;
                }
            }
        }

        // Метод Redo
        public void Redo()
        {
            if (redoShapesNumber > 0)
            {
                if (GeneralTool.isEnd)
                {
                    shapesList[++shapesNumber] = redoShapesList[redoShapesNumber];
                    redoShapesList.Remove(redoShapesNumber);
                    redoShapesNumber--;
                }
            }
        }

        // Метод сброса списка Redo
        public void ResetRedo()
        {
            redoShapesList.Clear();
            redoShapesNumber = 0;
        }

        // Отрисовка всего списка фигур
        public void Draw(Graphics g)
        {
            if (GeneralTool.isEnd)
            {
                g.Clear(Color.White);

                foreach (KeyValuePair<int, GeneralTool> pair in shapesList)
                {
                    pair.Value.reDraw(g);
                }
            }
        }
    }
}
