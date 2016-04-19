using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;

namespace Blocks_2._0
{
    public partial class BlockControl : UserControl
    {
        PictureBox[,] _picList;
        Point[,] item = new Point[19, 4];
        public int[,,,] _tricks;
        public int[,] _back;
        bool _buttomReached;
        int _shape, _xLoc, _yLoc, _orient, _score;
        KeyEventArgs _keyEvent;

        public BlockControl()
        {
            try
            {
                InitializeComponent();
                this.Dock = DockStyle.Fill;
                this.blockPanel.Dock = DockStyle.Fill;
                this.blockPanel.BackColor = Color.Black;

                _back = new int[,] //[col, row]
                { 
                    {0,0,0,0,0,0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0,0,0,0,0,0}
                };

                _tricks = new int[,,,] //{row, col}
                { 
                    {{{0,0}, {0,1}, {0,2}, {0,3}}, {{0,0}, {1,0}, {2,0}, {3,0}},
                     {{0,0}, {0,1}, {0,2}, {0,3}}, {{0,0}, {1,0}, {2,0}, {3,0}}}, //Bar
                    {{{0,0}, {1,0}, {0,1}, {1,1}}, {{0,0}, {1,0}, {0,1}, {1,1}},
                     {{0,0}, {1,0}, {0,1}, {1,1}}, {{0,0}, {1,0}, {0,1}, {1,1}}}, //Block
                    {{{0,0}, {0,1}, {1,1}, {1,2}}, {{1,0}, {2,0}, {0,1}, {1,1}},
                     {{0,0}, {0,1}, {1,1}, {1,2}}, {{1,0}, {2,0}, {0,1}, {1,1}}}, //Z-Shape.1
                    {{{0,0}, {1,0}, {1,1}, {1,2}}, {{2,0}, {0,1}, {1,1}, {2,1}},
                     {{0,0}, {0,1}, {0,2}, {1,2}}, {{0,0}, {1,0}, {2,0}, {0,1}}}, //L-Shape.1
                    {{{1,0}, {0,1}, {1,1}, {0,2}}, {{0,0}, {1,0}, {1,1}, {2,1}},
                     {{1,0}, {0,1}, {1,1}, {0,2}}, {{0,0}, {1,0}, {1,1}, {2,1}}}, //Z-Shape.2
                    {{{0,0}, {1,0}, {0,1}, {0,2}}, {{0,0}, {1,0}, {2,0}, {2,1}},
                     {{1,0}, {1,1}, {1,2}, {0,2}}, {{0,0}, {0,1}, {1,1}, {2,1}}}, //L-Shape.2
                    {{{0,0}, {1,0}, {2,0}, {1,1}}, {{1,0}, {0,1}, {1,1}, {1,2}},
                     {{1,0}, {0,1}, {1,1}, {2,1}}, {{0,0}, {0,1}, {1,1}, {0,2}}} //T-Shape
                };

                _buttomReached = true;
                _picList = new PictureBox[12, 12]; //[row, col]
                _shape = 0;
                _xLoc = 0;
                _yLoc = 0;
                _orient = 0;
                _score = 0;
                scoreDisplay.Text = string.Format("Score: " + _score);
                stopButton.Enabled = false;
                speedButton.Enabled = false;
                turnButton.Enabled = false;
                leftButton.Enabled = false;
                rightButton.Enabled = false;

                for (int i = 0; i < 12; i++)
                {
                    for (int j = 0; j < 12; j++)
                    {
                        var pic = new PictureBox();
                        pic.BackColor = Color.DarkBlue;
                        pic.Location = new Point(i * 40, j * 40);
                        pic.Size = new Size(40, 40);
                        pic.BorderStyle = BorderStyle.FixedSingle;
                        _picList[i, j] = pic;
                    }
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError("BlockControl.Constructor failed. \r\n{0}", ex);
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            try
            {
                if(_buttomReached == true)
                {
                    InitBlocks();
                    _buttomReached = false;
                    startButton.Enabled = false;
                    stopButton.Enabled = true;
                    speedButton.Enabled = true;
                    turnButton.Enabled = true;
                    leftButton.Enabled = true;
                    rightButton.Enabled = true;
                }
                timer.Interval = 800;
                timer.Start();
            }
            catch(Exception ex)
            {
                Trace.TraceError("startButton_Click() failed. \r\n{0}", ex);
            }
        }
        
        private void stopButton_Click(object sender, EventArgs e)
        {
            try
            {
                CleanPlate();
            }
            catch(Exception ex)
            {
                Trace.TraceError("stopButton_Click() failed. \r\n{0}", ex);
            }
        }

        public void CleanPlate()
        {
            try
            {
                timer.Stop();
                blockPlate.Controls.Clear();
                for (int i = 0; i < 12; i++)
                    for (int j = 0; j < 12; j++)
                        _back[i, j] = 0;
                _buttomReached = true;
                startButton.Enabled = true;
                stopButton.Enabled = false;
                stopButton.Enabled = false;
                speedButton.Enabled = false;
                turnButton.Enabled = false;
                leftButton.Enabled = false;
                rightButton.Enabled = false;
                _score = 0;
                scoreDisplay.Text = string.Format("Score: " + _score);
            }
            catch (Exception ex)
            {
                Trace.TraceError("CleanPlate() failed. \r\n{0}", ex);
            }
        }

        public void InitBlocks()
        {
            try
            {
                Random r = new Random();
                int shape = r.Next(7);
                int loc = 0;
                _shape = shape;

                do
                {
                    loc = r.Next(12);
                }
                while (CheckBlank(loc, 0, 0) == false);
                _xLoc = loc;
                _yLoc = 0;
                _orient = 0;
                DrawBlocks();
            }
            catch (Exception ex)
            {
                Trace.TraceError("DrawBlocks() failed. \r\n{0}", ex);
            }
        }

        public bool CheckBlank(int xLoc, int yLoc, int orient)
        {
            try
            {
                for (int blockNum = 0; blockNum < 4; blockNum++)
                {
                    var row = _tricks[_shape, orient, blockNum, 0] + xLoc;
                    var col = _tricks[_shape, orient, blockNum, 1] + yLoc;
                    if (row < 0 || row >= 12 || col < 0 || col >= 12)
                        return false;
                    else if (_back[col, row] == 1)
                        return false;
                }
                return true;
            }
            catch(Exception ex)
            {
                Trace.TraceError("CheckBlank() failed. \r\n{0}", ex);
                return false;
            }
        }
        
        public void MoveBlocks()
        {
            try
            {
                if (_yLoc + 1 < 12)
                {
                    RemoveBlocks();
                    bool check = CheckBlank(_xLoc, _yLoc + 1, _orient);
                    if (check == true)
                    {
                        _yLoc++;
                        DrawBlocks();
                    }
                    else
                    {
                        DrawBlocks();
                        RearrangePlate();
                        Reinitial();
                    }
                }
                else
                {
                    DrawBlocks();
                    RearrangePlate();
                    Reinitial();
                }   
            }
            catch(Exception ex)
            {
                Trace.TraceError("MoveBlocks() failed. \r\n{0}", ex);
            }
        }

        public void Reinitial()
        {
            try
            {
                var checkVer = VerticalCheck();
                if (checkVer != false)
                {
                    timer.Stop();
                    _buttomReached = true;
                    InitBlocks();
                    timer.Interval = 800;
                    timer.Start();
                }
                else
                {
                    timer.Stop();
                    MessageBox.Show("You Lose!");
                    CleanPlate();
                }
            }
            catch(Exception ex)
            {
                Trace.TraceError("Reinitial() failed. \r\n{0}", ex);
            }
        }

        public void RearrangePlate()
        {
            var checkHol = HorizontalCheck();
            var count = checkHol.Count;
            if (count != 0)
            {
                for (int ct = 0; ct < count; ct++)
                {
                    if(checkHol[ct] > 0)
                    {
                        for (int col = checkHol[ct]; col > 0; col--)
                            for (int row = 0; row < 12; row++)
                                _back[col, row] = _back[col - 1, row];
                        for (int row = 0; row < 12; row++)
                            _back[0, row] = 0;
                    }
                    else
                    {
                        if (checkHol[count - 1] == 0)
                            for (int row = 0; row < 12; row++)
                                _back[0, row] = 0;
                    }
                }
                this.blockPlate.Controls.Clear();
                for (int i = 0; i < 12; i++)
                    for (int j = 0; j < 12; j++)
                        if (_back[j, i] == 1)
                            this.blockPlate.Controls.Add(_picList[i, j]);
                _score++;
                scoreDisplay.Text = string.Format("Score: " + _score);
            }
        }

        public void RightMoveBlocks()
        {
            try
            {
                if (_xLoc + 1 < 12)
                {
                    RemoveBlocks();
                    bool check = CheckBlank(_xLoc + 1, _yLoc, _orient);
                    if (check == true)
                        _xLoc++;
                    DrawBlocks();
                }
                timer.Interval = 800;
                timer.Start();
            }
            catch (Exception ex)
            {
                Trace.TraceError("MoveBlocks() failed. \r\n{0}", ex);
            }
        }

        public void LeftMoveBlocks()
        {
            try
            {
                if (_xLoc - 1 >= 0)
                {
                    RemoveBlocks();
                    bool check = CheckBlank(_xLoc - 1, _yLoc, _orient);
                    if (check == true)
                        _xLoc--;
                    DrawBlocks();
                }
                timer.Interval = 800;
                timer.Start();
            }
            catch (Exception ex)
            {
                Trace.TraceError("MoveBlocks() failed. \r\n{0}", ex);
            }
        }
        
        private void RollBlocks()
        {
            try
            {
                RemoveBlocks();
                int orient = _orient;
                if (_orient < 3)
                    orient++;
                else
                    orient = 0;
                bool check = CheckBlank(_xLoc, _yLoc, orient);
                if (check == true)
                    _orient = orient;
                DrawBlocks();
                timer.Interval = 800;
                timer.Start();
                timer.Interval = 800;
                timer.Start();
            }
            catch (Exception ex)
            {
                Trace.TraceError("RollBlocks() failed. \r\n{0}", ex);
            }
        }

        private void SpeedUpBlocks()
        {
            try
            {
                timer.Stop();
                timer.Interval = 50;
                timer.Start();
            }
            catch(Exception ex)
            {
                Trace.TraceError("SpeedUpBlocks() failed. \r\n{0}", ex);
            }
        }

        public void DrawBlocks()
        {
            try
            {
                for (int blockNum = 0; blockNum < 4; blockNum++)
                {
                    var row = _tricks[_shape, _orient, blockNum, 0] + _xLoc;
                    var col = _tricks[_shape, _orient, blockNum, 1] + _yLoc;
                    _back[col, row] = 1;
                    this.blockPlate.Controls.Add(_picList[row, col]);
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError("DrawBlocks() failed. \r\n{0}", ex);
            }
        }

        public void RemoveBlocks()
        {
            try
            {
                for(int blockNum = 0; blockNum < 4; blockNum++)
                {
                    var row = _tricks[_shape, _orient, blockNum, 0] + _xLoc;
                    var col = _tricks[_shape, _orient, blockNum, 1] + _yLoc;
                    _back[col, row] = 0;
                    this.blockPlate.Controls.Remove(_picList[row, col]);
                }
            }
            catch(Exception ex)
            {
                Trace.TraceError("RemoveBlocks() failed. \r\n{0}", ex);
            }
        }

        private bool VerticalCheck()
        {
            try
            {
                for(int i = 0; i < 12; i++)
                {
                    if (_back[0, i] == 1)
                        return false;
                }
                return true;
            }
            catch(Exception ex)
            {
                Trace.TraceError("VerticalCheck() failed. \r\n{0}", ex);
                return false;
            }
        }

        private List<int> HorizontalCheck()
        {
            try
            {
                var list = new List<int>();
                var count = 0;
                for (int i = 11; i >= 0; i--)
                {
                    for (int j = 0; j < 12; j++)
                    {
                        if (_back[i, j] == 1)
                            count++;
                    }
                    if (count == 12) list.Add(i);
                    count = 0;
                }
                return list;
            }
            catch (Exception ex)
            {
                Trace.TraceError("HorizontalCheck() failed. \r\n{0}", ex);
                return new List<int>();
            }
        }

        private void turnButton_Click(object sender, EventArgs e)
        {
            try
            {
                timer.Stop();
                RollBlocks();
            }
            catch(Exception ex)
            {
                Trace.TraceError("turnButton_Click() failed. \r\n{0}", ex);
            }
        }

        private void leftButton_Click(object sender, EventArgs e)
        {
            try
            {
                timer.Stop();
                LeftMoveBlocks();
            }
            catch (Exception ex)
            {
                Trace.TraceError("leftButton_Click() failed. \r\n{0}", ex);
            }
        }

        private void speedButton_Click(object sender, EventArgs e)
        {
            try
            {
                timer.Stop();
                SpeedUpBlocks();
            }
            catch (Exception ex)
            {
                Trace.TraceError("leftButton_Click() failed. \r\n{0}", ex);
            }
        }

        private void rightButton_Click(object sender, EventArgs e)
        {
            try
            {
                timer.Stop();
                RightMoveBlocks();
            }
            catch (Exception ex)
            {
                Trace.TraceError("rightButton_Click() failed. \r\n{0}", ex);
            }
        }

        private void BlockControl_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                this.OnKeyDown(e);
                _keyEvent = e;
                timer.Stop();
                if (e.KeyValue == 37)
                    LeftMoveBlocks();
                else if (e.KeyValue == 38)
                    RollBlocks();
                else if (e.KeyValue == 39)
                    RightMoveBlocks();
                else if (e.KeyValue == 40)
                    MoveBlocks();
            }
            catch(Exception ex)
            {
                Trace.TraceError("BlockControl_KeyDown() failed. \r\n{0}", ex);
            }
        }

        private void BlockControl_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 40)
                {
                    timer.Stop();
                    timer.Interval = 1000;
                    timer.Start();
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError("BlockControl_KeyUp() failed. \r\n{0}", ex);
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                MoveBlocks();
            }
            catch(Exception ex)
            {
                Trace.TraceError("timer_Tick() failed. \r\n{0}", ex);
            }
        }
    }
}
