using System;
using System.Collections;
using System.Drawing;
using System.Timers;

namespace Snake
{
    class Palette
    {
        private int _width = 20;//宽度
        private int _height = 20;//长度
        private Color _bgColor;//
        private Graphics _gpPalette;//
        private ArrayList _blocks;//
        private Direction _direction;//
        private Timer timerBlock;//
        private Block _food;//
        private int _size = 20;//
        private int _level = 1;//
        private bool _isGameOver = false;
        private int[] _speed = { 500, 450, 400, 350, 300, 250, 200, 150, 100, 50 };

        public Palette(int width, int height, int size, Color bgColor, Graphics g, int lvl)
        {
            this._width = width;
            this._height = height;
            this._bgColor = bgColor;
            this._gpPalette = g;
            this._size = size;
            this._level = lvl;
            this._blocks = new ArrayList();
            this._blocks.Insert(0, (new Block(Color.Red, this._size, new Point(width / 2, height / 2))));
            this._direction = Direction.Right;
        }

        public Direction Direction;
        //开始游戏
        public void Start()
        {
            this._food = GetFood();//
            //初始化计时器
            timerBlock = new System.Timers.Timer(_speed[this._level]);
            timerBlock.Elapsed += new System.Timers.ElapsedEventHandler(OnBlockTimedEvent);
            timerBlock.AutoReset = true;
            timerBlock.Start();
        }
        //
        private void OnBlockTimedEvent(object sourse, ElapsedEventArgs e)
        {
            this.Move();//
            if (this.CheckDead())
            {
                this.timerBlock.Stop();
                this.timerBlock.Dispose();
                System.Windows.Forms.MessageBox.Show("Score:" + this._blocks.Count, "Game Over");
            }
        }
        //
        private bool CheckDead()
        {
            Block head = (Block)(this._blocks[0]);//
            //
            if (head.Point.X < 0 || head.Point.Y < 0 || head.Point.X >= this._width || head.Point.Y >= this._height)
                return true;
            for (int i = 1; i < this._blocks.Count; i++)//
            {
                Block b = (Block)this._blocks[i];
                if (head.Point.X == b.Point.X && head.Point.Y == b.Point.Y)
                {
                    this._isGameOver = true;
                    return true;
                }
            }
            this._isGameOver = false;
            return false;
        }
        //
        private Block GetFood()
        {
            Block food = null;
            Random r = new Random();
            bool redo = false;
            while (true)
            {
                redo = false;
                int x = r.Next(this._width);
                int y = r.Next(this._height);
                for (int i = 0; i < this._blocks.Count; i++)
                {
                    Block b = (Block)(this._blocks[i]);
                    if (b.Point.X == x && b.Point.Y == y)
                    {
                        redo = true;
                    }
                }
                if (redo == false)
                {
                    food = new Block(Color.Black, this._size, new Point(x, y));
                    break;
                }
            }
            return food;
        }
        //
        private void Move()
        {
            Point p;
            Block head = (Block)(this._blocks[0]);
            if (this._direction == Direction.Up)
                p = new Point(head.Point.X, head.Point.Y - 1);
            else if (this._direction == Direction.Down)
                p = new Point(head.Point.X, head.Point.Y + 1);
            else if (this._direction == Direction.Left)
                p = new Point(head.Point.X - 1, head.Point.Y);
            else
                p = new Point(head.Point.X + 1, head.Point.Y);
            //
            Block b = new Block(Color.Red, this._size, p);
            //
            if (this._food.Point != p)
                this._blocks.RemoveAt(this._blocks.Count - 1);
            else
                this._food = this.GetFood();
            //
            this._blocks.Insert(0, b);
            this.PaintPalette(this._gpPalette);
        }
        //
        public void PaintPalette(Graphics gp)
        {
            gp.Clear(this._bgColor);
            this._food.Paint(gp);
            foreach (Block b in this._blocks)
                b.Paint(gp);
        }
    }
    //
    public enum Direction
    {
        Left,
        Right,
        Up,
        Down
    }
}
